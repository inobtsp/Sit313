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
	public partial class detail : ContentPage
	{
        public async void GetJsonList()
        {try
            {
                storereply postlist = new storereply();

                string result = await postlist.loadpost("http://introtoapps.com/datastore.php?appid=215330413&action=load&objectid=post");
                Jsonconverter converter = new Jsonconverter();
                string topic = replytopic.Text;
               
                listView.ItemsSource = converter.Listreply(result).Where(i => i.Belongpost.Contains(replytopic.Text));
            }
            catch (Exception ex) {Console.WriteLine(ex); }
        }

        
		public detail(string data)
		{
			InitializeComponent ();
            GetJsonList();
               replytopic.Text = data;
            Console.WriteLine(replytopic.Text);
            //create binding data for listview
       /* listView.ItemsSource = new List<Custom>
            {
                new Custom
                {
                    icon="monkey.jpg",
                     detail="LGD will win this TI",
                    author= "inobts",
                    time ="2017-6-7 6:00pm",
                    level = "lv17",
                    image="monkey.jpg",
                    image1="monkey.jpg"

                },
                   new Custom
                {
                     icon="monkey.jpg",       
                    detail="You damn right bro!",
                    author= "inobtsp",
                     time ="2017-6-16 6:00pm",
                    level = "lv1",
                    image="monkey.jpg"
                },

            };*/
           
            //set event handler for image button
            var tgr = new TapGestureRecognizer { NumberOfTapsRequired = 1 };
            tgr.TappedCallback = async (sender, args) =>
            {  
                await Navigation.PushAsync(new replypage(replytopic.Text));
            };
            reply.GestureRecognizers.Add(tgr);
   
        }
        //set event handler for menu item
        private async void gotologin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new login());
        }
        //set event handler for another menu item
        private async void gotocategory(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new category());
        }
    }
}