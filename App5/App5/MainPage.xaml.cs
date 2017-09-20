using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App5
{
    public partial class MainPage : ContentPage
    {
  //load list of post from network and set binding for the reply
        public async void GetJsonList()
        {
            storepost postlist = new storepost();

            string result = await postlist.loadpost("http://introtoapps.com/datastore.php?appid=215330413&action=load&objectid=wow.topic");
            Jsonconverter converter = new Jsonconverter();
            listView.ItemsSource = converter.List(result).Where(i => i.Belongstopic.Contains(topicname.Text));
        }
        public MainPage(string data)
        {

            InitializeComponent();
            topicname.Text = data;
            GetJsonList();
 
            //set the event handler for create button
            var tgr = new TapGestureRecognizer { NumberOfTapsRequired = 1 };
            tgr.TappedCallback = async (sender, args) =>
            {
                await Navigation.PushAsync(new post(data));
            };
            post.GestureRecognizers.Add(tgr);
        }
        //set event handler for menu item
        private async void gotologin(object sender, EventArgs e)
        {
            //check whether user has login and lead to different page
            string datasigniture = DependencyService.Get<ISaveAndLoad>().LoadText("temp.json");
            Jsonconverter jsonconverter = new Jsonconverter();
            string usersfooter = jsonconverter.ToObjectstring(datasigniture);
            if (usersfooter != null)
            {
                await Navigation.PushAsync(new profile());
            }
            else
            {
                await Navigation.PushAsync(new login());
            }
        }
        //set event handler for another menu item
        private async void gotocategory(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new category());
        }

        //set event handler for listview
         private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
           {
               try
               {

                //retreive the post topic of the user click item in the list view
                   postdata item = (postdata)((ListView)sender).SelectedItem;
                   ((ListView)sender).SelectedItem = null;
                   string itemtopic = item.Posttopic;
                   Console.WriteLine(item.Posttopic);
                   await Navigation.PushAsync(new detail(itemtopic));
               }
               catch(Exception exception) { Console.WriteLine(exception); }
        }

        //search bar 
         private async void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            //referesh the list
           listView.BeginRefresh();

            var keyword = searchbar.Text;
            //retreive all post in ther list
            storepost postlist = new storepost();

            string result = await postlist.loadpost("http://introtoapps.com/datastore.php?appid=215330413&action=load&objectid=wow.topic");
            Jsonconverter converter = new Jsonconverter();
          // display the item that contains keyword
            listView.ItemsSource = converter.List(result).Where(i => i.Posttopic.Contains(keyword));
            //referesh the list
            listView.EndRefresh();
        }
    }
}

