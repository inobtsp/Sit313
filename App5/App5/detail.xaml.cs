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
        //load list from networl and set binding for the reply
        public async void GetJsonList()
        {
            try
            {

                //display list
                storereply postlist = new storereply();

                string result = await postlist.loadreply("http://introtoapps.com/datastore.php?appid=215330413&action=load&objectid=post");
                Jsonconverter converter = new Jsonconverter();
                string topic = replytopic.Text;
               
                listView.ItemsSource = converter.Listreply(result).Where(i => i.Belongpost.Contains(replytopic.Text));
            }
            catch (Exception ex) {Console.WriteLine(ex); }
        }

        
		public detail(string data)
		{
			InitializeComponent ();
            //set the listview binding
            GetJsonList();

     
      
            // set the passing data and change the text of the lable
            replytopic.Text = data;
            Console.WriteLine(replytopic.Text);
     
       //set event handler for image add button
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