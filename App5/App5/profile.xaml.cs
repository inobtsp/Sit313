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
	public partial class profile : ContentPage
	{
        
        public profile ()
		{
       
            InitializeComponent ();
            //define the page for profile
            var layout3 = new StackLayout { Padding = new Thickness(5, 20) };
            var layoutuppload = new StackLayout { Padding = new Thickness(5, 20), Orientation = StackOrientation.Horizontal };
            this.Content = layout3;
            var Labletitle = new Label { Text = "Edit your information", FontSize = 30 };
            var labeladdress = new Label { Text = "Address", TextColor = Color.FromHex("#5858FA"), FontSize = 12 };
            var labelusername = new Label { Text = "username", TextColor = Color.FromHex("#5858FA"), FontSize = 12 };
            var labelconfirmenewpass = new Label { Text = "Confirme you password", TextColor = Color.FromHex("#5858FA"), FontSize = 12 };
            var labelpostcode = new Label { Text = "Postcode", TextColor = Color.FromHex("#5858FA"), FontSize = 12 };
            var labeloldpass = new Label { Text = "Enter your old password", TextColor = Color.FromHex("#5858FA"), FontSize = 12 };
            var labelnewpass = new Label { Text = "Enter your new password", TextColor = Color.FromHex("#5858FA"), FontSize = 12 };
            var Edit = new Button { Text = "Confirme Change", BackgroundColor = Color.FromHex("#5858FA"), TextColor = Color.White };
            var btnlogout= new Button { Text = "Log Out", BackgroundColor = Color.Red, TextColor = Color.White };
            var lablesigniture = new Label { Text = "Signiture", TextColor = Color.FromHex("#5858FA"), FontSize = 12 };
            var upload = new Button { Text = "Click to see your post history ", HeightRequest = 5, HorizontalOptions = LayoutOptions.EndAndExpand };
            var head = new Image { HeightRequest = 75, WidthRequest = 75, Source = "monkey.jpg" };
            var confirmenewpass = new Entry { IsPassword = true };
            var signiture = new Entry { };
            var username = new Entry { };
            var address = new Entry { };
            var oldpass = new Entry { };
            var newpass = new Entry { };
            var postcode = new Entry { };
            //retreive username
            Jsonconverter jsonconverter = new Jsonconverter();
            string datauser = DependencyService.Get<ISaveAndLoad>().LoadText("temp.json");
            string usernames = jsonconverter.ToObjectstring(datauser);
            Console.WriteLine(usernames);
            string[] testarray = usernames.Split(',');
            string usernameinputed = testarray[0];
            username.Text = usernameinputed;
            //display the username relate post


            //adding properties into the page
            Content = new ScrollView { Content = layout3 };
            layoutuppload.Children.Add(head);
            layoutuppload.Children.Add(upload);
            layout3.Children.Add(layoutuppload);
            layout3.Children.Add(btnlogout);
            layout3.Children.Add(Labletitle);
            layout3.Children.Add(labelusername);
            layout3.Children.Add(username);
            layout3.Children.Add(labeloldpass);
            layout3.Children.Add(oldpass);
            layout3.Children.Add(labelnewpass);
            layout3.Children.Add(newpass);
            layout3.Children.Add(labelconfirmenewpass);
            layout3.Children.Add(confirmenewpass);
            layout3.Children.Add(labeladdress);
            layout3.Children.Add(address);
            layout3.Children.Add(labelpostcode);
            layout3.Children.Add(postcode);
            layout3.Children.Add(lablesigniture);
            layout3.Children.Add(signiture);

            layout3.Children.Add(Edit);
            Edit.Clicked += confirmechange;
            //event handler when people done their editing
            async void confirmechange(object a, EventArgs b)
            {
                // save the signiture into a local file and convert it to json
                Jsonconverter jsonapi = new Jsonconverter();
                DependencyService.Get<ISaveAndLoad>().SaveText("signiture.json", jsonapi.ToJasonstring(signiture.Text));
                Console.WriteLine(jsonapi.ToJasonstring(signiture.Text));
                await Navigation.PushAsync(new category());
                DisplayAlert("Change Success", "You are successfully change your information", "OK");
            }
            upload.Clicked += Gotohistory;
            async void Gotohistory(object a, EventArgs b)
            {
                
                await Navigation.PushAsync(new history(username.Text));
               
            }
            btnlogout.Clicked += logout;
              async void logout(object a, EventArgs b)
            {
                //clean the local storage when user log out
                Jsonconverter jsonapi = new Jsonconverter();
                DependencyService.Get<ISaveAndLoad>().SaveText("temp.json", jsonapi.ToJasonstring(""));
                DependencyService.Get<ISaveAndLoad>().SaveText("signiture.json", jsonapi.ToJasonstring(""));
                await Navigation.PushAsync(new category());

            }
        }
    }
	}
