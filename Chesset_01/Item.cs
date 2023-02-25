using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Chesset_01
{
    enum Player { player1, player2,noPlayer };
    abstract class Item
    {
        public Player player;
        protected Point Index;
        public  Size size;
        public PictureBox picBox;
        public Bitmap ItemImg;
        private Bitmap ItemBackground;

        public Item()
        {
        }
        public Item(Player pl, Point In, Size si, Color bg)
        {
            player = pl;
            Index = new Point(In.X, In.Y);
            size = new Size(si.Width, si.Height);
            //ItemImg = new Bitmap(imgPath);
            picBox = new PictureBox();
            this.picBox.BackColor = bg;
            this.picBox.Location = new System.Drawing.Point(Index.X*si.Width, Index.Y*si.Height);
            this.picBox.Name = Index.Y.ToString() + Index.X.ToString();
            this.picBox.Size = new System.Drawing.Size(40, 40);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;


            // picBox.Image = ItemImg;
        }

        public  Item Select(Player currentPlayer)
        {
            if (this.player == currentPlayer)
            {
                this.picBox.BorderStyle = BorderStyle.FixedSingle;
                return this;
            }
            return null;
        }

        public void reSelect()
        {
           
                this.picBox.BorderStyle = BorderStyle.None;
               
        }

        public Point SelectToMoveTo()
        {
            return this.Index;
        }

        public abstract bool move(Point In, Item[,] items);

    }
}
