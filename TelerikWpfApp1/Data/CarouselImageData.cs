using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TelerikWpfApp1.UserControls;

namespace TelerikWpfApp1.Data
{
    public class CarouselImageData
    {
        public static List<CarouselItem> GetData()
        {
            var imageList = new List<CarouselItem>();

            _FillData(ref imageList);

            return imageList;
        }
        private static void _FillData(ref List<CarouselItem> list)
        {
            var myItem = new CarouselItem();
            myItem.ImageSource = new BitmapImage(new Uri("../Resources/Images/scenery 01.jpg", UriKind.Relative));
            list.Add(myItem);

            var myItem1 = new CarouselItem();
            myItem1.ImageSource = new BitmapImage(new Uri("/Resources/Images/scenery 02.jpg", UriKind.Relative));
            list.Add(myItem1);

            var myItem2 = new CarouselItem();
            myItem2.ImageSource = new BitmapImage(new Uri("/Resources/Images/scenery 03.jpg", UriKind.Relative));
            list.Add(myItem2);

            var myItem3 = new CarouselItem();
            myItem3.ImageSource = new BitmapImage(new Uri("/Resources/Images/scenery 01.jpg", UriKind.Relative));
            list.Add(myItem3);

            var myItem4 = new CarouselItem();
            myItem4.ImageSource = new BitmapImage(new Uri("/Resources/Images/scenery 04.jpg", UriKind.Relative));
            list.Add(myItem4);
        }
    }
}
