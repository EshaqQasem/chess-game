using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Chesset_01
{
    class Minister:Item
    {
        private static string imgPath = @"C:\Users\DELL\Desktop\VCsharp\projects\Chesset_01\Chesset_01\bin\Debug\";

        public Minister()
        {
            imgPath = Application.ExecutablePath + "\\";
        }

        public Minister(Player pl, Point In, Size si, Color bg)
            : base(pl, In, si, bg)
        {
            imgPath = Application.StartupPath + "\\";
            this.ItemImg = new Bitmap(imgPath + ((pl == Player.player1) ? "whiteMinister.png" : "blackMinister.png"));
            this.picBox.Image = this.ItemImg;
        }

        private bool isThereItem(int X1, int X2, int y, Item[,] items)
        {
            int i = X1, end = X2;
            if (X2 < X1)
            {
                i = X2;
                end = X1;
            }
            for (i += 1; i < end; i++)
            {
                if (items[y, i].player != Player.noPlayer)
                    return false;
            }
            return true;
        }

        private bool isThereItem2(int Y1, int Y2, int x, Item[,] items)
        {
            int i = Y1, end = Y2;
            if (Y2 < Y1)
            {
                i = Y2;
                end = Y1;
            }
            for (i += 1; i < end; i++)
            {
                if (items[i, x].player != Player.noPlayer)
                    return false;
            }
            return true;
        }
        public override bool move(Point In, Item[,] items)
        {
            if (this.Index.Y == In.Y)
            {
                if (isThereItem(this.Index.X, In.X, In.Y, items))
                {

                    items[In.Y, In.X] = new Minister(this.player, new Point(In.X, In.Y), new Size(this.size.Width, this.size.Height), items[In.Y, In.X].picBox.BackColor);//items[this.Index.Y, this.Index.X];
                    items[this.Index.Y, Index.X] = new Space(Player.noPlayer, this.Index, this.size, this.picBox.BackColor);
                    return true;
                }
            }

            if (this.Index.X == In.X)
            {
                if (isThereItem2(this.Index.Y, In.Y, In.X, items))
                {

                    items[In.Y, In.X] = new Minister(this.player, new Point(In.X, In.Y), new Size(this.size.Width, this.size.Height), items[In.Y, In.X].picBox.BackColor);//items[this.Index.Y, this.Index.X];
                    items[this.Index.Y, Index.X] = new Space(Player.noPlayer, this.Index, this.size, this.picBox.BackColor);
                    return true;
                }
            }

            if (Math.Abs(this.Index.X - this.Index.Y) == Math.Abs(In.X - In.Y) || this.Index.X + this.Index.Y == In.X + In.Y)
            {
                items[In.Y, In.X] = new Minister(this.player, new Point(In.X, In.Y), new Size(this.size.Width, this.size.Height), items[In.Y, In.X].picBox.BackColor);//items[this.Index.Y, this.Index.X];
                items[this.Index.Y, Index.X] = new Space(Player.noPlayer, this.Index, this.size, this.picBox.BackColor);
                //items[this.Index.Y,this.Index.X] = pt;
                return true;
            }
            return false;
        }
    }
}
