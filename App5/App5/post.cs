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
       /* public string topicid;

        public string topic;
        public string detail;*/
 


        public static storepost CreatUserFromJson(string json)
        {
            storepost post = JsonConvert.DeserializeObject<storepost>(json);
            return post;
        }
        public storepost()
        {
        }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }

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
        public  async Task<String> loadpost(string url)
        {
            string result = "";
            try
            {
                string action = url;
                Uri uri = new Uri(action);
                WebRequest request = WebRequest.Create(uri);
                request.Method = "Get";
                result = await getServerResponse(request);
                /*
                string actualurl = url + "&action=load&objectid=" + username + ".user";
                Uri uri = new Uri(actualurl);
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
                // request.ContentType = "application/json";
                request.Method = "GET";
                string result = await getServerResponse(request);
                return CreatUserFromJson(result);*/
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
              
            }
              return result;
        }
        public async void savepost()
        {
            try
            {
                string jsonString = ToJsonString();
                jsonString = WebUtility.UrlEncode(jsonString);
                Jsonconverter jsonapi = new Jsonconverter();
        
              //  post postinput = new post();
                
            //    postdata topic = new postdata(""+postinput.FindByName<Entry>(postinput.c.Text+"",""+ postinput.FindByName<Editor>(detail).Text+"");

                List<postdata> lists = new List<postdata>();
                lists = post.list;
               // lists.Add(topic);
        
             String jason = jsonapi.ListToJason(lists);
                Console.WriteLine(jsonString);
                string action = url + "&action=save&objectid=wow.topic" + "&data=" + jason;
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
    /*public class Post
    {

        private static string HTTPServer = "http://introtoapps.com/datastore.php?appid=215197324";

        public string post;

        public static Post CreateJson(string json)
        {
            Post data = JsonConvert.DeserializeObject<Post>(json);
            return data;
        }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);

        }


        //Post the new topic
        public async void NewPost()
        {
            try
            {
                string jsonString = ToJsonString();
                jsonString = WebUtility.UrlEncode(jsonString);
                Jsonconverter jsonspi = new Jsonconverter();
                Topic topic = new Topic("01", "d1");
                Topic topic1 = new Topic("02", "d2");
                Topic topic2 = new Topic("03", "d3");
                List<Topic> list = new List<Topic>();
                list.Add(topic);
                list.Add(topic1);
                list.Add(topic2);
                String jason = api.ListToJason(list);
                Debug.WriteLine(jsonString);
                string action = HTTPServer + "&action=save&objectid=wow.topic" + "&data=" + jason;
                Uri uri = new Uri(action);
                WebRequest request = WebRequest.Create(uri);
                request.Method = "Post";

                Debug.WriteLine(action);


                await ServerResponse(request);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        //Post the new topic
        public async Task<string> NewPost2(string url)
        {
            string result = "";

            try
            {
                string action = url;
                Uri uri = new Uri(action);
                WebRequest request = WebRequest.Create(uri);
                request.Method = "Get";
                result = await ServerResponse(request);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return result;
        }

        //Get response from server
        public static async Task<string> ServerResponse(WebRequest request)
        {
            string result = "";

            // Send the request to the server and wait for the response:
            using (WebResponse response = await request.GetResponseAsync())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader objStream = new StreamReader(stream);

                    string sLine = "";
                    while (sLine != null)
                    {
                        sLine = objStream.ReadLine();
                        if (sLine != null)
                            result += sLine + "\n";
                    }
                }
            }
            return result;
        }
    }
*/

     partial class post : ContentPage
    {
            public static List<postdata> list = new List<postdata>();
       public List<postdata> List
        {
            get { return list; }
        }
        int id = 1;
        public post(string data)
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
          //  while () { 
               postbutton.Clicked += posted;
                async void posted(object sender, EventArgs e)
                {
                
                    string postids = id.ToString();

                /* Jsonconverter jsonapi = new Jsonconverter();*/

                // for(int i; i < list.Count; i++) { 
                string datauser = DependencyService.Get<ISaveAndLoad>().LoadText("temp.txt");
                string[] testarray = datauser.Split(',');
                string username = testarray[1];
                postdata postdata = new postdata(id,""+topic.Text+"",""+detail.Text+"",""+data+"",""+username+"");
                list.Add(postdata);
                id++;
                list.ForEach(Console.WriteLine);

                // String jason = jsonapi.ListToJason(lists);


               
                  // Console.WriteLine(list);
                  /* storeuser testpost = jsonapi.ListToJason(list);
                     testpost.saveuser();*/
                   storepost testpost = storepost.CreatUserFromJson("{\"postid\":\"" + postids + "\",\"topic\":\"" + topic.Text + "\",\"detail\":\"" + detail.Text +"\"}");
                    testpost.savepost();
                    DisplayAlert("Success!", "" + topic.Text + "", "" + detail.Text + "", "OK");
                    await Navigation.PushAsync(new MainPage(data));
                }
            
        }
    }
}
