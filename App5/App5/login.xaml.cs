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
	public partial class login : ContentPage
	{
		public login ()
		{
			//define property for loginpage and adding them into layout
            var scroll = new ScrollView { };
            var layout = new StackLayout { Padding = new Thickness(5, 20) };    
            this.Content = layout;
            var labelusername = new Label { Text = "username", TextColor = Color.FromHex("#5858FA"), FontSize = 12 }; layout.Children.Add(labelusername);
            var username = new Entry { Placeholder = "" }; layout.Children.Add(username);
            var labelpassword = new Label { Text = "password", TextColor = Color.FromHex("#5858FA"), FontSize = 12 }; layout.Children.Add(labelpassword);
            var password = new Entry { IsPassword = true }; layout.Children.Add(password);
            var forgetlable = new Label { FontSize = 10, TextColor = Color.Blue }; layout.Children.Add(forgetlable);
        var loginbutton = new Button { Text = "Click here to log in", BackgroundColor = Color.FromHex("#5858FA"), TextColor = Color.White }; layout.Children.Add(loginbutton);
            var registerbutton = new Button { Text = "NO Account? Register here!",BackgroundColor= Color.FromHex("#5858FA") ,TextColor=Color.White}; layout.Children.Add(registerbutton);
          


            Content = new ScrollView { Content = layout };
            //goto profile page
            loginbutton.Clicked += logged;
              void logged(object sender, EventArgs e)
            {
                //reset the page
                DisplayAlert("Login Success", "Welcome to inobtsp forum; your are login success", "OK");
                layout.Children.Remove(labelusername);
                layout.Children.Remove(username);
                layout.Children.Remove(labelpassword);
                layout.Children.Remove(password);
                layout.Children.Remove(forgetlable);
                layout.Children.Remove(loginbutton);
                layout.Children.Remove(registerbutton);
                //define the page for profile
                var layout3 = new StackLayout { Padding = new Thickness(5, 20)  };
                var layoutuppload = new StackLayout { Padding = new Thickness(5, 20), Orientation = StackOrientation.Horizontal };
                this.Content = layout3;
                var Labletitle = new Label { Text = "Edit your information", FontSize = 30 };
                var labeladdress = new Label { Text = "Address", TextColor = Color.FromHex("#5858FA"), FontSize = 12 };
                var labelconfirmenewpass = new Label { Text = "Confirme you password", TextColor = Color.FromHex("#5858FA"), FontSize = 12 };
                var labelpostcode = new Label { Text = "Postcode", TextColor = Color.FromHex("#5858FA"), FontSize = 12 };
                var labeloldpass = new Label { Text = "Enter your old password", TextColor = Color.FromHex("#5858FA"), FontSize = 12 };
                var labelnewpass = new Label { Text = "Enter your new password", TextColor = Color.FromHex("#5858FA"), FontSize = 12 };
                var Edit = new Button { Text = "Confirme Change" , BackgroundColor = Color.FromHex("#5858FA"), TextColor = Color.White };
                var upload = new Button { Text = "Upload to change your head portrait ",HeightRequest = 5, HorizontalOptions= LayoutOptions.EndAndExpand};
                var head = new Image {HeightRequest=75 ,WidthRequest=75, Source = "monkey.jpg" };
                var confirmenewpass = new Entry { IsPassword = true };
                var address = new Entry { };
                var oldpass = new Entry { };
                var newpass = new Entry { };
                var postcode = new Entry { };
                //adding properties into the page
                Content = new ScrollView { Content = layout3 };
                layoutuppload.Children.Add(head);
                layoutuppload.Children.Add(upload);
                layout3.Children.Add(layoutuppload);
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
                layout3.Children.Add(Edit);
                Edit.Clicked += confirmechange;
                //event handler when people done their editing
                async void confirmechange(object a, EventArgs b)
                {
                    Console.WriteLine("success change");
                    await Navigation.PushAsync(new MainPage());
                    DisplayAlert("Change Success", "You are successfully change your information", "OK");
                }
            }
            registerbutton.Clicked += register;
            //go to register page in 
            void register(object sender, EventArgs e)
            {
                //reset the pages 
                layout.Children.Remove(loginbutton);
                layout.Children.Remove(forgetlable);
                layout.Children.Remove(registerbutton);
                //define the properties of the page
                var layoutuppload = new StackLayout { Padding = new Thickness(5, 20), Orientation = StackOrientation.Horizontal };
                var layout2 = new StackLayout { Padding = new Thickness(5, 20) };
                this.Content = layout2;
                var labeladdress = new Label { Text = "Address", TextColor = Color.FromHex("#5858FA"), FontSize = 12 }; 
                var labelconfirme = new Label { Text = "Confirme you password", TextColor = Color.FromHex("#5858FA"), FontSize = 12 }; 
                var labelpostcode = new Label { Text = "Postcode", TextColor = Color.FromHex("#5858FA"), FontSize =12 };
                var register2 = new Button { Text = "Register", BackgroundColor = Color.FromHex("#5858FA"), TextColor = Color.White };
                var head = new Image { HeightRequest = 100, WidthRequest = 100, HorizontalOptions = LayoutOptions.Center , Source = "head.jpg"};
                var upload = new Button { Text = "Upload your head portrait ", HeightRequest = 5, HorizontalOptions = LayoutOptions.EndAndExpand };
                var confirme = new Entry { IsPassword = true };
                var address = new Entry {  };
                var postcode = new Entry { };
                //adding the properties into the layout
                Content = new ScrollView { Content = layout2 };
                layoutuppload.Children.Add(head);
                layoutuppload.Children.Add(upload);
                layout2.Children.Add(layoutuppload);
                //layout2.Children.Add(head);
                layout2.Children.Add(labelusername);
                layout2.Children.Add(username);
                layout2.Children.Add(labelpassword);
                layout2.Children.Add(password);
                layout2.Children.Add(labelconfirme);
                layout2.Children.Add(confirme);
                layout2.Children.Add(labeladdress);
                layout2.Children.Add(address);
                layout2.Children.Add(labelpostcode);
                layout2.Children.Add(postcode);
                layout2.Children.Add(register2);
                register2.Clicked += registersuccess;
                //event handler fot regist button
                async void registersuccess(object a, EventArgs b)
                {
                    Console.WriteLine("success regist");
                    await Navigation.PushAsync(new login());
                    DisplayAlert("Register Success", "Welcome to inobtsp forum; your are Register success", "OK");
                }

            }
           
        }
	}
}