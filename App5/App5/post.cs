using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5
{
    public class storepost
    {
        private static string url = "http://introtoapps.com/datastore.php?appid=215330413";
        public string topicid;

        public string topic;
        public string detail;
    

        public static storepost CreatUserFromJson(string json)
        {
            storepost post = JsonConvert.DeserializeObject<storepost>(json);
            return post;
        }
        public storepost()
        {
        }
        /*  public storeuser(string username)
          {
              this.username = username;


          }*/
        public storepost(string topicid,string topic ,string detail)
        {
            this.topic = topicid;
            this.topic = topic;
            this.detail = detail;
        }
        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }

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
        public static async Task<storepost> loadpost(string username)
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
        public async void saveuser()
        {
            try
            {
                string jsonString = this.ToJsonString();
                jsonString = WebUtility.UrlEncode(jsonString);
                string actualurl = url + "&action=save&objectid=Topic."   + topicid + "&data=" + jsonString;
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
    public partial class post : ContentPage
    {
        public post()
        {
            int postid = 1;
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
               string postids = postid.ToString();
                storeuser testuser = storeuser.CreatUserFromJson("[{\"username\":\"" + postids + "\",\"password\":\"" + topic.Text + "\",\"address\":\"" + detail.Text + "\"}]");
                testuser.saveuser();
                postid++;
                Console.WriteLine("posted success");
                DisplayAlert("Success!","You are succssfullt post!", "OK");
                await Navigation.PushAsync(new MainPage());
            }
        }
    }
}
