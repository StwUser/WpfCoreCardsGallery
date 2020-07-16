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
using System.Windows.Media.Imaging;
using WpfCoreCardsGallery.Commands;
using WpfCoreCardsGallery.Models;
using WpfCoreCardsGallery.Views;

namespace WpfCoreCardsGallery.ViewModels
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private Card selectedCard;

        public ObservableCollection<Card> Cards { get; set; }


        public Card SelectedCard
        {
            get { return selectedCard; }
            set
            {
                selectedCard = value;
                OnPropertyChanged("SelectedCard");
            }
        }

        //Commands
        // create card window
        private RelayCommand createCommand;
        public RelayCommand CreateCommand
        {
            get
            {
                return createCommand ??
                  (createCommand = new RelayCommand(obj =>
                  {
                      CreateCard cardWindow = new CreateCard();
                      cardWindow.DataContext = new CreateCardViewModel(Cards);
                      cardWindow.ShowDialog();
                  }));
            }
        }
        // Delete Card Command
        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(obj =>
                  {
                      Cards.Remove(selectedCard);
                  }));
            }
        }


        public ApplicationViewModel()
        {
            Cards = new ObservableCollection<Card>() { 
                new Card(){ Id=1, Name="Tv1", Img = new BitmapImage(new Uri("/Images/img.png", UriKind.Relative))},
                new Card(){ Id=2, Name="Tv2", Img = new BitmapImage(new Uri("/Images/img.png", UriKind.Relative))},
                new Card(){ Id=3, Name="Tv3", Img = new BitmapImage(new Uri("/Images/img.png", UriKind.Relative))},
                new Card(){ Id=4, Name="Tv4", Img = new BitmapImage(new Uri("/Images/img.png", UriKind.Relative))},
                new Card(){ Id=5, Name="Tv5", Img = new BitmapImage(new Uri("/Images/img.png", UriKind.Relative))}
            };

        }


    }
}
