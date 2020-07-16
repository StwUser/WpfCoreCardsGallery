using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfCoreCardsGallery.Models;

namespace WpfCoreCardsGallery.Validators
{
    public static class CardValidator
    {
        public static bool CardValidation(Card card)
        {
            if (card.Id <= 0 || card.Id > Int32.MaxValue)
            {
                MessageBox.Show($"Id must be more than 0 and less than {Int32.MaxValue}.");
                return false;
            }
            else if (card.Name == "none")
            {
                MessageBox.Show($"Name can't be \"none\".");
                return false;
            }
            else if (card.Img.UriSource.ToString() == "/Images/img.png")
            {
                MessageBox.Show("You don't pick a picture.");
                return false;
            }

            return true;
        }
    }
}
