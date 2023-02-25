using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Chesset_01
{
    class Soldier:Item
    {
        private static string imgPath = @"C:\Users\DELL\Desktop\VCsharp\projects\Chesset_01\Chesset_01\bin\Debug\";

        public Soldier()
        {
            imgPath = Application.ExecutablePath + "\\";
        }

        public Soldier(Player pl, Point In, Size si,Color bg)
            : base(pl, In, si, bg)
        {
            imgPath = Application.StartupPath + "\\";
            this.ItemImg = new Bitmap( imgPath + ((pl==Player.player1)? "whiteSoldier.png" : "blackSoldier.png"));
            this.picBox.Image = this.ItemImg;
        }

        public override bool move(Point In,Item [,]items)
        {
            //MessageBox.Show(In.Y.ToString() +In.X.ToString());

            int temp = 1;
            if (this.player == Player.player1)
                temp *= -1;

            if (this.Index.Y + temp == In.Y)
            {
               // MessageBox.Show("lm");

                if ((this.Index.X == In.X&&items[In.Y, In.X].player == Player.noPlayer) || ((this.Index.X == In.X + 1 || this.Index.X == In.X - 1) && items[In.Y, In.X].player != items[this.Index.Y, this.Index.X].player) && items[In.Y, In.X].player != Player.noPlayer)
                {
                    //if (items[In.Y, In.X].player == Player.noPlayer  )
                    {
                        
                       // Item pt = items[In.Y, In.X];
                        
                        //items[In.Y, In.X].picBox.BackColor = Color.Black;
                        
                        items[In.Y, In.X] = new Soldier ((this.player==Player.player2)? Player.player2:Player.player1, new Point(In.X, In.Y), new Size(this.size.Width, this.size.Height), items[In.Y,In.X].picBox.BackColor);//items[this.Index.Y, this.Index.X];
                        items[ this.Index.Y,Index.X] = new Space(Player.noPlayer, this.Index, this.size, this.picBox.BackColor);
                        //items[this.Index.Y,this.Index.X] = pt;
                        return true;
                    }
                }
            }
            return false;
       }
    }
}
