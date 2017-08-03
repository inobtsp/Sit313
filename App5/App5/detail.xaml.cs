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
		public detail()
		{
			InitializeComponent ();
            listView.ItemsSource = new List<Custom>
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

            };
            var tgr = new TapGestureRecognizer { NumberOfTapsRequired = 1 };
            tgr.TappedCallback = async (sender, args) =>
            {
                await Navigation.PushAsync(new replypage());
            };
            reply.GestureRecognizers.Add(tgr);
        }
	}
}