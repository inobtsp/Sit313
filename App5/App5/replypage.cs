using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App5
{
	public class replypage : ContentPage
	{
		public replypage ()
		{
            //define element and property
            var layout = new StackLayout { Padding = new Thickness(5, 20), BackgroundColor = Color.FromHex("#5858FA") };
            this.Content = layout;
            var labledetail = new Label { Text = "Reply", FontSize = 20 }; layout.Children.Add(labledetail);
            var detail = new Editor { VerticalOptions= LayoutOptions.FillAndExpand  , BackgroundColor = Device.OnPlatform(Color.FromHex("#5882FA"), Color.FromHex("#5882FA"), Color.FromHex("#5882FA")) }; layout.Children.Add(detail);
            var replybutton = new Button { Text = "Click here to reply", BackgroundColor = Color.FromHex("#5858FA"), TextColor = Color.White }; layout.Children.Add(replybutton);
            //set event handler for button
            replybutton.Clicked += posted;
            async void posted(object sender, EventArgs e)
            {
                Console.WriteLine("posted success");
                DisplayAlert("Success!", "You are succssfullt replied!", "OK");
                await Navigation.PushAsync(new detail());
            }
        }
    }
	}
