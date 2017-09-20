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
    //function to save and load post for network
   public class storepost
    {
        private static string url = "http://introtoapps.com/datastore.php?appid=215330413";
  


        public static storepost CreatUserFromJson(string json)
        {
            storepost post = JsonConvert.DeserializeObject<storepost>(json);
            return post;
        }
        //inistialize the class
        public storepost()
        {
        }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
        // webrequest function
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
        //function to load post
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
      
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
              
            }
              return result;
        }
        //function to append post string
        public async void saveappendpost(string jsonString )
        {
            try
            {
                
                jsonString = WebUtility.UrlEncode(jsonString);
                string actualurl = url + "&action=append&objectid=wow.topic" + "&data=" + jsonString;
                Uri uri = new Uri(actualurl);
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
                Console.WriteLine(actualurl);
                request.Method = "GET";
                string result = await getServerResponse(request);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        //function to save post list
        public async void savepost()
        {
            try
            {
                string jsonString = ToJsonString();
                jsonString = WebUtility.UrlEncode(jsonString);
                Jsonconverter jsonapi = new Jsonconverter();
        
              
            //creat a list and make it equal to list string
                List<postdata> lists = new List<postdata>();
                lists = post.list;
                //convert list object to json
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


     partial class post : ContentPage
    {
        //declare the list object
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
        
               postbutton.Clicked += posted;
                async void posted(object sender, EventArgs e)
                {
             
                try
                {
                    storepost storepost = new storepost();
                    string postids = id.ToString();
                    //load the logged username from local file
                    string datauser = DependencyService.Get<ISaveAndLoad>().LoadText("temp.json");
                    Jsonconverter jsonconverter = new Jsonconverter();
                    //convert json into string
                    string usernames = jsonconverter.ToObjectstring(datauser);
                    Console.WriteLine(usernames);
                    //split the string and retreive the username data
                    string[] testarray = usernames.Split(',');
                    string usernameinputed = testarray[0];
                    // if the list is exist append string after the first one , if not create a string
                    if (storepost.loadpost("http://introtoapps.com/datastore.php?appid=215330413&action=load&objectid=wow.topic") == null)
                    {
                           
                        postdata postdata = new postdata(id, "" + topic.Text + "", "" + detail.Text + "", "" + data + "", "" + usernameinputed + "");

                        list.Add(postdata);
                        id++;
                        list.ForEach(Console.WriteLine);


                        storepost testpost =new storepost();
                        testpost.savepost();
                       await DisplayAlert("Success!", "" + topic.Text + "", "" + detail.Text + "", "OK");
                        
                    }
                    else
                    {
                        
                        postdata postdata = new postdata(id, "" + topic.Text + "", "" + detail.Text + "", "" + data + "", "" + usernameinputed + "");
                        Jsonconverter jsonapi = new Jsonconverter();
                    
                       string jsonstring= jsonapi.ToJasonString(postdata);
                     //   string normalstring = jsonapi.ToObject(jsonstring);

                   
                        storepost testpost = new storepost();
                        testpost.saveappendpost(jsonstring);
                      await  DisplayAlert("Success!", "" + topic.Text + "", "" + detail.Text + "", "OK");
                    }
                 
                   } catch (Exception ex) { Console.WriteLine(ex); }
                        await Navigation.PushAsync(new MainPage(data));
               
                }
            
        }
    }
}
