using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;

namespace Chesset_01
{
    public delegate void setText(string r);
    public delegate void itemClick(int i, int j);
    public partial class Form1 : Form
    {
        Cout cout = new Cout(Player.player1);
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    cout.items[i, j].picBox.Click += Item_Click;

                    this.panel1.Controls.Add(cout.items[i, j].picBox);

                }
            }

        }
        enum GameMode { onePlayer, TwoPlayer };
        GameMode gameMode;

        private void Item_Click3(int i, int j)
        {
            this.Invoke(new itemClick(Item_Click2), new object[] { i, j });
        }
        private void Item_Click2(int i, int j)
        {
            if (cout.noSelectedItem == true)
            {
                // MessageBox.Show(i.ToString() + j.ToString());
                if (cout.items[i, j].Select(cout.currentPlayer) !=   null)
                {

                    cout.noSelectedItem = false;
                    cout.SelectedItem = cout.items[i, j];
                }
            }
            else if (cout.items[i, j].player == cout.currentPlayer)
            {
                cout.SelectedItem.reSelect();
                cout.SelectedItem = cout.items[i, j];
                cout.items[i, j].Select(cout.currentPlayer);
                cout.noSelectedItem = false;
            }
            else
            {


                this.panel1.Controls.Remove(cout.items[i, j].picBox);
                this.panel1.Controls.Remove(cout.items[cout.SelectedItem.SelectToMoveTo().Y, cout.SelectedItem.SelectToMoveTo().X].picBox);

                bool flag = this.cout.SelectedItem.move(new Point(j, i), cout.items);

                cout.items[cout.SelectedItem.SelectToMoveTo().Y, cout.SelectedItem.SelectToMoveTo().X].picBox.Click += Item_Click;
                this.panel1.Controls.Add(cout.items[cout.SelectedItem.SelectToMoveTo().Y, cout.SelectedItem.SelectToMoveTo().X].picBox);

                cout.items[i, j].picBox.Click += Item_Click;
                this.panel1.Controls.Add(cout.items[i, j].picBox);

                if (flag)
                {
                    cout.currentPlayer = (cout.currentPlayer == Player.player2) ? Player.player1 : Player.player2;
                    this.panel1.Enabled = !panel1.Enabled;
                }
                cout.noSelectedItem = true;
                cout.SelectedItem.reSelect();
            }


        }
        private void Item_Click(object sender, EventArgs e)
        {



            int i = ((PictureBox)sender).Location.Y / 40;
            int j = ((PictureBox)sender).Location.X / 40;

            // MessageBox.Show(i.ToString() + j.ToString());
            client.sw.Write(i);
            client.sw.Write(j);
            Item_Click2(i, j);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        TcpListener listner;
        Thread thWaitingClients;
        private void button1_Click_1(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button1.Text = "Cancel";
            label1.Text = "waiting clients to connect";

            listner = new TcpListener(5000);
            listner.Start();
            thWaitingClients = new Thread(waitingClients);
            thWaitingClients.Start();
        }


        private void waitingClients()
        {
            Socket tc = listner.AcceptSocket();

            /* this.Invoke(new setText((str) => 
                 label1.Text =str), ((IPEndPoint)tc.Client.RemoteEndPoint).Address.ToString() + ": Connected");
             */
            client =new Client(tc);
             
            this.Invoke(new setText((sss) =>
            {
                panel2.Visible = false;
                panel1.Visible = true;
            }), "");

            client.receiveMessage = this.Item_Click3;

            Thread.CurrentThread.Abort();
        }

        void reseive(string ms)
        {
            // this.Invoke(new setText((str) => textBox3.Text += str + "\r\n"), new object[] { ms });
        }

        Client client;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                TcpClient tc = new TcpClient();
                tc.Connect("127.0.0.1", 5000);
                client = new Client(tc.Client);
                panel1.Visible = true;
                panel1.Enabled = false;
                panel2.Visible = false;
                client.receiveMessage = this.Item_Click3;
                // client.receiveMessage+=(str)=>{textBox3.Text+=str +"\r\n";};
            }
            catch (SocketException ex)
            {
                if (ex.ErrorCode == 10061)
                {
                    MessageBox.Show("لا يمكن الاتصال ");
                }


            }


        }



        class Client
        {
            static int count = 0;
            public int id;
            public NetworkStream ns { set; get; }
            public BinaryWriter sw { set; get; }
            public BinaryReader br { set; get; }
            public Socket mySocket { set; get; }
            public itemClick receiveMessage;
            Thread clientListner;
            public Client(Socket ms)
            {
                id = count++;
                mySocket = ms;
                ns = new NetworkStream(mySocket);
                sw = new BinaryWriter(ns);
                br = new BinaryReader(ns);
                clientListner = new Thread(listen);
                clientListner.Start();

                // sw.Write("Welcome!!");
            }

            void listen()
            {
                while (true)
                {
                    if (this.mySocket.Connected)
                    {
                        int i, j;
                        i = br.ReadInt32();
                        j = br.ReadInt32();
                        receiveMessage(i, j);
                        //Console.WriteLine(mySocket.LocalEndPoint.ToString() + ": id="+id+": " +ms);
                      
                    }
                }
            }
        }
    }
}
