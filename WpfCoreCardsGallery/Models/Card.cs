using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfCoreCardsGallery.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BitmapImage Img { get; set; }
    }
}
