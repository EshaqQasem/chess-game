using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Chesset_01
{
    class Officer : Item
    {
        private static string imgPath = @"C:\Users\DELL\Desktop\VCsharp\projects\Chesset_01\Chesset_01\bin\Debug\";

        public Officer()
        {
            imgPath = Application.ExecutablePath + "\\";
        }

        public Officer(Player pl, Point In, Size si, Color bg)
            : base(pl, In, si, bg)
        {
            imgPath = Application.StartupPath + "\\";
            this.ItemImg = new Bitmap(imgPath + ((pl == Player.player1) ? "whiteOfficer.png" : "blackOfficer.png"));
            this.picBox.Image = this.ItemImg;
        }

        public override bool move(Point In, Item[,] items)
        {
            if (Math.Abs(this.Index.X - this.Index.Y) == Math.Abs(In.X - In.Y) || this.Index.X + this.Index.Y == In.X + In.Y)
            {
                items[In.Y, In.X] = new Officer(this.player, new Point(In.X, In.Y), new Size(this.size.Width, this.size.Height), items[In.Y, In.X].picBox.BackColor);//items[this.Index.Y, this.Index.X];
                items[this.Index.Y, Index.X] = new Space(Player.noPlayer, this.Index, this.size, this.picBox.BackColor);
                //items[this.Index.Y,this.Index.X] = pt;
                return true;
            }
            return false;
        }
    }
}
