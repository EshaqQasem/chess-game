using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Chesset_01
{
    class Hourse:Item
    {

        private static string imgPath = @"C:\Users\DELL\Desktop\VCsharp\projects\Chesset_01\Chesset_01\bin\Debug\";

        public Hourse()
        {
            imgPath = Application.ExecutablePath + "\\";
        }

        public Hourse(Player pl, Point In, Size si,Color bg)
            : base(pl, In, si, bg)
        {
            imgPath = Application.StartupPath + "\\";
            this.ItemImg = new Bitmap( imgPath + ((pl==Player.player1)? "whiteHourse.png" : "blackHourse.png"));
            this.picBox.Image = this.ItemImg;
        }

        public override bool move(Point In, Item[,] items)
        {
            if ((Math.Abs(this.Index.X - In.X) == 2 && Math.Abs(this.Index.Y - In.Y) == 1) || (Math.Abs(this.Index.X - In.X) == 1 && Math.Abs(this.Index.Y - In.Y) == 2))
            {
                items[In.Y, In.X] = new Hourse(this.player, new Point(In.X, In.Y), new Size(this.size.Width, this.size.Height), items[In.Y, In.X].picBox.BackColor);//items[this.Index.Y, this.Index.X];
                items[this.Index.Y, Index.X] = new Space(Player.noPlayer, this.Index, this.size, this.picBox.BackColor);
                //items[this.Index.Y,this.Index.X] = pt;
                return true;
            }

            return false;
        }
    }
}
