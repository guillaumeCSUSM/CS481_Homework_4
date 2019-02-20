using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_4.models;
using Xamarin.Forms;

namespace Homework_4
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Player> allPlayers = new ObservableCollection<Player>();

        public MainPage()
        {
            InitializeComponent();

            PopulatePlayer();
            PlayerListView.ItemsSource = allPlayers;
        }

        private void PopulatePlayer()
        {
            allPlayers.Clear();
            var player1 = new Player
            {
                Name = "DJOKOVIC Novak",
                NationalityImage = "Serbia",
                AtpPoints = 10955
            };
            var player2 = new Player
            {
                Name = "NADAL Rafael",
                NationalityImage = "Spain",
                AtpPoints = 8320
            };
            var player3 = new Player
            {
                Name = "ZVEREV Alexander",
                NationalityImage = "Germany",
                AtpPoints = 6475
            };
            var player4 = new Player
            {
                Name = "DEL POTRO Juan Martin",
                NationalityImage = "Argentina",
                AtpPoints = 5060
            };
            var player5 = new Player
            {
                Name = "ANDERSON Kevin",
                NationalityImage = "SouthAfrica",
                AtpPoints = 4845
            };
            allPlayers.Add(player1);
            allPlayers.Add(player2);
            allPlayers.Add(player3);
            allPlayers.Add(player4);
            allPlayers.Add(player5);
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var item = (Player)((ListView)sender).SelectedItem;
            RemoveObjectFromList(item);
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var item = (MenuItem)sender;
            Player listitem = (from itm in allPlayers
                               where itm.Name == item.CommandParameter.ToString()
                               select itm)
                           .FirstOrDefault<Player>();
            RemoveObjectFromList(listitem);
        }

        void RemoveObjectFromList(Player player)
        {
            allPlayers.Remove(player);
        }

        async void Handle_Refreshing(object sender, System.EventArgs e)
        {
            await Task.Delay(2000);
            PopulatePlayer();
            PlayerListView.IsRefreshing = false;
        }
    }
}
