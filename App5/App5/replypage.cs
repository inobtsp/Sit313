using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App5
{

    public class storereply
    {
        private static string url = "http://introtoapps.com/datastore.php?appid=215330413";
        //inistailixze the class
        public storereply()
        {
        }

        //function for web request
        public static async Task<string> getServerResponse(WebRequest request)
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
         //function to load reply 
        public async Task<String> loadreply(string url)
        {
            string result = "";
            try
            {
                string action = url;
                Uri uri = new Uri(action);
                WebRequest request = WebRequest.Create(uri);
                request.Method = "Get";
                result = await getServerResponse(request);
      
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            return result;
        }
        //function to save reply
        public async void savereply()
        {
            try
            {
                // create a list and make it equalts to the list in the content page 
                Jsonconverter jsonapi = new Jsonconverter();
                List<storetopic> lists = new List<storetopic>();
                 lists = replypage.listreply;
                //convert list in to json
                String jason = jsonapi.ListToJasonreply(lists);
                Console.WriteLine(jason);
                replypage reply = new replypage("");
                storetopic storetopic = new storetopic();
                string postname = storetopic.Replytopic;
                
                Console.Write(postname);
                string action = url + "&action=save&objectid=post" + "&data=" + jason;
                Uri uri = new Uri(action);
                WebRequest request = WebRequest.Create(uri);
                request.Method = "Post";
                Console.WriteLine(action);
                await getServerResponse(request);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
      class replypage : ContentPage
	{
        int id = 111111;
        //reply list object in content page
        public static List<storetopic> listreply = new List<storetopic>();
        public List<storetopic> Listreply
        {
            get { return listreply; }
        }
         
        public  replypage (string data)
		{
            string postname = data;
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

                //append user footer
                string datasigniture = DependencyService.Get<ISaveAndLoad>().LoadText("signiture.json");
                Jsonconverter jsonconverter = new Jsonconverter();
                string usersfooter = jsonconverter.ToObjectstring(datasigniture);
                //set date 
                DateTime dt = DateTime.Now.ToLocalTime();
                DateTime date= dt.Date;
           //retreive logged username from local file
                string postids = id.ToString();
                string datauser = DependencyService.Get<ISaveAndLoad>().LoadText("temp.json");
                string usernames = jsonconverter.ToObjectstring(datauser);
                Console.WriteLine(usernames);
                //split the file string and retreive user name
                string[] testarray = usernames.Split(',');
                string usernameinputed = testarray[0];
                Console.WriteLine(datauser);
                //set save data
                storetopic storereply = new storetopic(id, "" + detail.Text + "", "" + date + "", "monkey.jpg",""+postname+"",""+usernameinputed+"",""+usersfooter+"");
                listreply.Add(storereply);
                id+=1;   
                storereply testpost =new storereply();
                testpost.savereply();
                storeuser userinfo = new storeuser();
                string tested = userinfo.password;
                Console.WriteLine("posted success");
               await DisplayAlert("Success!", "You are succssfullt replied!", "OK");
                await Navigation.PushAsync(new detail(data));
            }
        }
    }
	}
