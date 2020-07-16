using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;
using WpfCoreCardsGallery.Commands;
using WpfCoreCardsGallery.Models;
using WpfCoreCardsGallery.Validators;

namespace WpfCoreCardsGallery.ViewModels
{
    public class CreateCardViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Card> Cards { get; set; }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private Card card;

        public int Id
        {
            get { return card.Id; }
            set
            {
                card.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return card.Name; }
            set
            {
                card.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public BitmapImage Img
        {
            get { return card.Img; }
            set
            {
                card.Img = value;
                OnPropertyChanged("Img");
            }
        }

        // Commands
        // AddImage
        private RelayCommand addImageCommand;
        public RelayCommand AddImageCommand
        {
            get
            {
                return addImageCommand ??
                  (addImageCommand = new RelayCommand(obj =>
                  {
                      OpenFileDialog dlg = new OpenFileDialog();
                      dlg.InitialDirectory = "c:\\";
                      dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
                      dlg.RestoreDirectory = true;

                      if (dlg.ShowDialog() == true)
                      {
                          string selectedFileName = dlg.FileName;
                          BitmapImage bitmap = new BitmapImage();
                          bitmap.BeginInit();
                          bitmap.UriSource = new Uri(selectedFileName);
                          bitmap.EndInit();
                          this.Img = bitmap;
                      }
                  }));
            }
        }
        // Save Changes
        private RelayCommand saveCardCommand;
        public RelayCommand SaveCardCommand
        {
            get
            {
                return saveCardCommand ??
                  (saveCardCommand = new RelayCommand(obj =>
                  {
                      if (CardValidator.CardValidation(card) && !Cards.Contains(card) )
                      {
                          Cards.Add(card);
                          MessageBox.Show("Card saved.");
                          var win = (Window)obj;
                          win.Close();
                      }
                  }));
            }
        }
        public CreateCardViewModel(ObservableCollection<Card> cards)
        {
            this.Cards = cards;
            this.card = new Card() { Id=0, Name="none", Img = new BitmapImage(new Uri("/Images/img.png", UriKind.Relative)) };
        }


    }
}
