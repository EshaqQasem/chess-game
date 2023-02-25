using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Chesset_01
{
    class Space:Item
    {
         public Space(Player pl, Point In, Size si,Color bg)
            : base(pl, In, si, bg)
        {
           // this.ItemImg = new Bitmap( imgPath + ((pl==Player.player1)? "whiteSoldier.png" : "blackSoldier.png"));
            //this.picBox.Image = this.ItemImg;
        }

         public override bool move(Point In, Item[,] items)
         {
             //throw new NotImplementedException();
             return false;
         }

    }
}
