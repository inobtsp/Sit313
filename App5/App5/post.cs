using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5
{
 
    public partial class post : ContentPage
    {
        public post()
        {
            
            //define element and property
            var layout = new StackLayout { Padding = new Thickness(5, 20) , BackgroundColor=Color.FromHex("#5858FA") };
            this.Content = layout;
            var labletopic = new Label { Text = "Subject：",  FontSize = 20 }; layout.Children.Add(labletopic);
            var topic = new Entry { Placeholder = "" }; layout.Children.Add(topic);

            var labledetail = new Label { Text = "Detail：",  FontSize = 20 }; layout.Children.Add(labledetail);
            var detail = new Editor { HeightRequest = 300 , BackgroundColor = Device.OnPlatform(Color.FromHex("#5882FA"), Color.FromHex("#5882FA"), Color.FromHex("#5882FA")) }; layout.Children.Add(detail);
            var postbutton = new Button { Text = "Click here to post" ,BackgroundColor = Color.FromHex("#5858FA"), TextColor = Color.White }; layout.Children.Add(postbutton);
           //set event handler fot buttons
            postbutton.Clicked += posted;
             async void posted(object sender, EventArgs e)
            {
                
                Console.WriteLine("posted success");
                DisplayAlert("Success!","You are succssfullt post!", "OK");
                await Navigation.PushAsync(new MainPage());
            }
        }
    }
}
