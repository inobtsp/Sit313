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
			InitializeComponent ();
            var layout = new StackLayout { Padding = new Thickness(5, 20) };
            this.Content = layout;
            var labelusername = new Label { Text = "username", TextColor = Color.FromHex("#77d065"), FontSize = 20 }; layout.Children.Add(labelusername);
            var username = new Entry { Placeholder = "" }; layout.Children.Add(username);
            var labelpassword = new Label { Text = "password", TextColor = Color.FromHex("#77d065"), FontSize = 20 }; layout.Children.Add(labelpassword);
            var password = new Entry { IsPassword = true }; layout.Children.Add(password);
            var forgetlable = new Label { FontSize = 10, TextColor = Color.Blue }; layout.Children.Add(forgetlable);
        var loginbutton = new Button { Text = "Click here to log in" }; layout.Children.Add(loginbutton);
            var registerbutton = new Button { Text = "NO Account? Register here!" }; layout.Children.Add(registerbutton);
            loginbutton.Clicked += logged;
              void logged(object sender, EventArgs e)
            {
                DisplayAlert("Login Success", "Welcome to inobtsp forum; your are login success", "OK");
                layout.Children.Remove(labelusername);
                layout.Children.Remove(username);
                layout.Children.Remove(labelpassword);
                layout.Children.Remove(password);
                layout.Children.Remove(forgetlable);
                layout.Children.Remove(loginbutton);
                layout.Children.Remove(registerbutton);

                var layout3 = new StackLayout { Padding = new Thickness(5, 20)  };
                this.Content = layout3;
                var Labletitle = new Label { Text = "Edit your information", FontSize = 30 };
                var labeladdress = new Label { Text = "Address", TextColor = Color.FromHex("#77d065"), FontSize = 20 };
                var labelconfirmenewpass = new Label { Text = "Confirme you password", TextColor = Color.FromHex("#77d065"), FontSize = 20 };
                var labelpostcode = new Label { Text = "Postcode", TextColor = Color.FromHex("#77d065"), FontSize = 20 };
                var labeloldpass = new Label { Text = "Enter your old password", TextColor = Color.FromHex("#77d065"), FontSize = 20 };
                var labelnewpass = new Label { Text = "Enter your new password", TextColor = Color.FromHex("#77d065"), FontSize = 20 };
                var Edit = new Button { Text = "Confirme Change" };
                var confirmenewpass = new Entry { IsPassword = true };
                var address = new Entry { };
                var oldpass = new Entry { };
                var newpass = new Entry { };
                var postcode = new Entry { };
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
                void confirmechange(object a, EventArgs b)
                {
                    DisplayAlert("Change Success", "You are successfully change your information", "OK");
                }
            }
            registerbutton.Clicked += register;
            void register(object sender, EventArgs e)
            {
                layout.Children.Remove(loginbutton);
                layout.Children.Remove(forgetlable);
                layout.Children.Remove(registerbutton);
                var layout2 = new StackLayout { Padding = new Thickness(5, 20) };
                this.Content = layout2;
                var labeladdress = new Label { Text = "Address", TextColor = Color.FromHex("#77d065"), FontSize = 20 }; 
                var labelconfirme = new Label { Text = "Confirme you password", TextColor = Color.FromHex("#77d065"), FontSize = 20 }; 
                var labelpostcode = new Label { Text = "Postcode", TextColor = Color.FromHex("#77d065"), FontSize = 20 };
                var register2 = new Button { Text = "Register"};
                var confirme = new Entry { IsPassword = true };
                var address = new Entry {  };
                var postcode = new Entry { };
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
                void registersuccess(object a, EventArgs b)
                {
                    DisplayAlert("Register Success", "Welcome to inobtsp forum; your are Register success", "OK");
                }

            }
           
        }
	}
}