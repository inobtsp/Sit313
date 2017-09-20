using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Xamarin.Forms;
using System.Diagnostics;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace App5
{
   
    

 [XamlCompilation(XamlCompilationOptions.Compile)]
 // function for webrequest and json convert to store and load dat for the netwoirk storage and convert between json and string
    public class storeuser
    {
        private static string url = "http://introtoapps.com/datastore.php?appid=215330413";
        public string username;
        public string password;
        public string address;
        public string postcode;
        bool loginornot = false;
        //convert json to string
        public static storeuser CreatUserFromJson(string json)
        {
            storeuser user = JsonConvert.DeserializeObject<storeuser>(json);
            return user;
        }
        //initialize the class and parameter
        public storeuser()
        {
        }
       public storeuser(string username)
        {
            this.username = username;


        }
        
        public storeuser(string username, string password, string address,string postcode,bool loginornot)
        {
            this.username = username;
            this.password = password;
            this.address = address;
            this.postcode = postcode;
            this.loginornot = loginornot;
        }
        //convert string to json
        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
        //function for web request
        public static async Task<string> getServerResponse(HttpWebRequest request)
        {
            string result = "";
            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader objstream = new StreamReader(stream);
                    string sline = "";
                    while (sline != null)
                    {
                        sline = objstream.ReadLine();
                        if (sline != null)
                            result += sline + "\n";
                    }

                }
            }
            return result;
        }
        // load user from network
        public static async Task<storeuser> loaduser(string username)
        {
            try
            {
                string actualurl = url + "&action=load&objectid=" + username + ".user";
                Uri uri = new Uri(actualurl);
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
                // request.ContentType = "application/json";
                request.Method = "GET";
                string result = await getServerResponse(request);
                return CreatUserFromJson(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }
        //save user in to the network storage
        public async void saveuser()
        {
            try
            {
                string jsonString = this.ToJsonString();
                jsonString = WebUtility.UrlEncode(jsonString);
                string actualurl = url + "&action=save&objectid=" + this.username + ".user" + "&data=" + jsonString;
                Uri uri = new Uri(actualurl);
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);

                request.Method = "GET";
                string result = await getServerResponse(request);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
      
    }

    public partial class login : ContentPage
    {
       
            public login()
        {

            //create toolbaritem
            var Item1 = new ToolbarItem
            {
                Text = "Item 1",
                Icon = "person.png"

            };
            var Item2 = new ToolbarItem
            {
                Text = "See more Topic",
             

            };
            //set event for each item bar
            this.ToolbarItems.Add(Item1);
            this.ToolbarItems.Add(Item2);
            Item1.Activated += gotologin;
            Item2.Activated += gotocategory;
            async void gotologin(object a, EventArgs b)
            {
                //load username from local file
                string datasigniture = DependencyService.Get<ISaveAndLoad>().LoadText("temp.json");
                Jsonconverter jsonconverter = new Jsonconverter();
                string usersfooter = jsonconverter.ToObjectstring(datasigniture);
                //check whether user is login and lead to different page
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
            async void gotocategory(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new category());
            }

            bool loginornot=false;
                //define property for loginpage and adding them into layout
                var scroll = new ScrollView { };
                var layout = new StackLayout { Padding = new Thickness(5, 20) };
                this.Content = layout;
                var labelusername = new Label { Text = "username", TextColor = Color.FromHex("#5858FA"), FontSize = 12 }; layout.Children.Add(labelusername);
                var username = new Entry { Placeholder = "", ClassId = "loginusername" }; layout.Children.Add(username);
                var labelpassword = new Label { Text = "password", TextColor = Color.FromHex("#5858FA"), FontSize = 12 }; layout.Children.Add(labelpassword);
                var password = new Entry { IsPassword = true, ClassId = "loginpassword" }; layout.Children.Add(password);
                var forgetlable = new Label { FontSize = 10, TextColor = Color.Blue }; layout.Children.Add(forgetlable);
                var loginbutton = new Button { Text = "Click here to log in", BackgroundColor = Color.FromHex("#5858FA"), TextColor = Color.White }; layout.Children.Add(loginbutton);
                var registerbutton = new Button { Text = "NO Account? Register here!", BackgroundColor = Color.FromHex("#5858FA"), TextColor = Color.White }; layout.Children.Add(registerbutton);

            

            Content = new ScrollView { Content = layout };
            //goto profile page
            loginbutton.Clicked += logged;
            async void logged(object sender, EventArgs e)
            {
                
                try
                {
                    // set the data input and store it to the network
                    storeuser testuser = await storeuser.loaduser("" + username.Text + "");
                    //changing password in sha256 hash code
                    security sec = new security();
                    //check user login input correct or not
                    if (username.Text == testuser.username && sec.SHA256hash(password.Text) == testuser.password)
                    {
                        Jsonconverter jsonapi = new Jsonconverter();
                        string loggeduser = username.Text + "," + password.Text;
                        Console.WriteLine(loggeduser);
                        DependencyService.Get<ISaveAndLoad>().SaveText("temp.json", jsonapi.ToJasonstring(loggeduser));

                       await  DisplayAlert("Login Success", "Welcome  "+ testuser.username + " your are login success", "OK");
                        await Navigation.PushAsync(new profile());
                     
                    }
                    else
                    {
                        await DisplayAlert("alert", "your password is wrong", "OK");
                    }
            
                    
                }
                catch (Exception ex) { Console.WriteLine(ex); }
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
                var labelusernamer = new Label { Text = "username", TextColor = Color.FromHex("#5858FA"), FontSize = 12 }; 
                var usernamer = new Entry { Placeholder = "", ClassId = "loginusername" }; 
                var labelpasswordr = new Label { Text = "password", TextColor = Color.FromHex("#5858FA"), FontSize = 12 }; 
                var passwordr = new Entry { IsPassword = true, ClassId = "loginpassword" }; layout.Children.Add(password);
                var labeladdress = new Label { Text = "Address", TextColor = Color.FromHex("#5858FA"), FontSize = 12 };
                var labelconfirme = new Label { Text = "Confirme you password", TextColor = Color.FromHex("#5858FA"), FontSize = 12 };
                var labelpostcode = new Label { Text = "Postcode", TextColor = Color.FromHex("#5858FA"), FontSize = 12 };
                var register2 = new Button { Text = "Register", BackgroundColor = Color.FromHex("#5858FA"), TextColor = Color.White };
                var head = new Image { HeightRequest = 100, WidthRequest = 100, HorizontalOptions = LayoutOptions.Center, Source = "head.jpg" };
                var upload = new Button { Text = "Upload your head portrait ", HeightRequest = 5, HorizontalOptions = LayoutOptions.EndAndExpand };
                var confirme = new Entry { IsPassword = true };
                var address = new Entry { };
                var postcode = new Entry { };
                //adding the properties into the layout
                Content = new ScrollView { Content = layout2 };
                layoutuppload.Children.Add(head);
                layoutuppload.Children.Add(upload);
                layout2.Children.Add(layoutuppload);
                //layout2.Children.Add(head);
                layout2.Children.Add(labelusernamer);
                layout2.Children.Add(usernamer);
                layout2.Children.Add(labelpasswordr);
                layout2.Children.Add(passwordr);
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
                { try
                    {
                        Console.WriteLine("success regist");
                        await Navigation.PushAsync(new login());
                        //change user registe password into sha256 formate and store in to the network
                        security sec = new security();
                        string passwordsecure = sec.SHA256hash(passwordr.Text);

                        string inputvalue = "{\"username\":\"" + usernamer.Text + "\",\"password\":\"" + passwordsecure + "\",\"address\":\"" + address.Text + "\",\"postcode\":\"" + postcode.Text + "\",\"logged\":\"" + loginornot + "\"}";              
                        storeuser testuser = storeuser.CreatUserFromJson(inputvalue);
                        //store user into network
                        testuser.saveuser();
                        DisplayAlert("Register Success", "Welcome to inobtsp forum; your are Register success", "OK");
                    }
                    catch (Exception ex) { Console.WriteLine(ex); }
                }

            }


        }

    }
}