using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class history : ContentPage
	{
        //get the post list and set the filter and set the list binding
        async void GetJsonList()
        {
            storepost postlist = new storepost();

            string result = await postlist.loadpost("http://introtoapps.com/datastore.php?appid=215330413&action=load&objectid=wow.topic");
            Jsonconverter converter = new Jsonconverter();
            // listView.ItemsSource = converter.List(result);

            list.ItemsSource = converter.List(result).Where(i => i.Senduser.Equals(posthistory.Text));
        }
         
        public history (string data)
		{
			InitializeComponent ();
            //display  the user name pass from profile
            posthistory.Text = data;
            GetJsonList();
		}
        //set event handler for menu item
        private async void gotologin(object sender, EventArgs e)
        {
            //load local file
            string datasigniture = DependencyService.Get<ISaveAndLoad>().LoadText("temp.json");
            Jsonconverter jsonconverter = new Jsonconverter();
            string usersfooter = jsonconverter.ToObjectstring(datasigniture);
            // check whether user login and lead to different page
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

    }

}