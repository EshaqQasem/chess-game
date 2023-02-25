using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Chesset_01
{
    class Cout
    {
        public static  Size ItemSize = new Size(40, 40);
       // public static const
        private Player cPlayer;
        public Player currentPlayer
        {
            get { return cPlayer; }
            set
            {
                cPlayer = value;
            }
        }

        public bool noSelectedItem;
        public Item SelectedItem;
        public Point IndexToMoveTo;

        public Item[,] items;

        public Cout()
        { }

        public Cout(Player cp)
        {
            currentPlayer = Player.player2;
            noSelectedItem = true;
            SelectedItem = null;

            Color bg = Color.White;
            items = new Item[8, 8];


            for (int i = 0; i < 8; i++)
            {

                for (int j = 0; j < 8; j++)
                {
                    items[i, j] = new Space(Player.noPlayer, new Point(j, i), ItemSize, bg);


                    if (bg == Color.SandyBrown)
                        bg = Color.White;
                    else
                        bg = Color.SandyBrown;

                }

                if (bg == Color.SandyBrown)
                    bg = Color.White;
                else
                    bg = Color.SandyBrown;
            }

            items[0, 0] = new Casel(Player.player2, new Point(0, 0), ItemSize, items[0, 0].picBox.BackColor);
            items[0, 1] = new Hourse(Player.player2, new Point(1, 0), ItemSize, items[0, 1].picBox.BackColor);
            items[0, 2] = new Officer(Player.player2, new Point(2, 0), ItemSize, items[0, 2].picBox.BackColor);
            items[0, 3] = new Minister(Player.player2, new Point(3, 0), ItemSize, items[0, 3].picBox.BackColor);

            items[0, 4] = new King(Player.player2, new Point(4, 0), ItemSize, items[0, 4].picBox.BackColor);

            items[0, 7] = new Casel(Player.player2, new Point(7, 0), ItemSize, items[0, 7].picBox.BackColor);
            items[0, 6] = new Hourse(Player.player2, new Point(6, 0), ItemSize, items[0, 6].picBox.BackColor);
            items[0, 5] = new Officer(Player.player2, new Point(5, 0), ItemSize, items[0, 5].picBox.BackColor);

            for (int col = 0; col < 8; col++)
            {
                items[1, col] = new Soldier(Player.player2, new Point(col, 1), ItemSize, items[1, col].picBox.BackColor);
                items[6, col] = new Soldier(Player.player1, new Point(col, 6), ItemSize, items[6, col].picBox.BackColor);
            }


           

            items[7, 0] = new Casel(Player.player1, new Point(0, 7), ItemSize, items[7, 0].picBox.BackColor);
            items[7, 1] = new Hourse(Player.player1, new Point(1, 7), ItemSize, items[7, 1].picBox.BackColor);
            items[7, 2] = new Officer(Player.player1, new Point(2, 7), ItemSize, items[7, 2].picBox.BackColor);
            items[7, 3] = new Minister(Player.player1, new Point(3, 7), ItemSize, items[7, 3].picBox.BackColor);

            items[7, 4] = new King(Player.player1, new Point(4, 7), ItemSize, items[7, 4].picBox.BackColor);

            items[7, 7] = new Casel(Player.player1, new Point(7, 7), ItemSize, items[7, 7].picBox.BackColor);
            items[7, 6] = new Hourse(Player.player1, new Point(6, 7), ItemSize, items[7, 6].picBox.BackColor);
            items[7, 5] = new Officer(Player.player1, new Point(5, 7), ItemSize, items[7, 5].picBox.BackColor);

           
        }
    }
}
