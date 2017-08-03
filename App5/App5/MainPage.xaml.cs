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
		public MainPage()
		{
            InitializeComponent();
            
            listView.ItemsSource = new List<Custom>
            {
                new Custom
                {
               
                    Topic="LGD is the best team！",
                    time="post at: 2017-8-04",
                    author= "inobts"
                },
                   new Custom
                {
                 
                    Topic="Dota2 is the best game ever",
                      time="post at: 2017-8-04",
                    author= "inobtsp"
                },

            };
            var tgr = new TapGestureRecognizer { NumberOfTapsRequired = 1 };
            tgr.TappedCallback = async (sender, args) =>
            {
                await Navigation.PushAsync(new post());
            };
           post.GestureRecognizers.Add(tgr);
        }
        
                private async void gotologin (object sender, EventArgs e)
        {
            await Navigation.PushAsync(new login());
        }
        private async void gotocategory(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new category());
        }


        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new detail());
        }

        private void MenuItem1_Activated(object sender, EventArgs e)
        {

        }
    }
	}

