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
        /* public string topicid;

         public string topic;
         public string detail;*/



        /*public static storereply CreatUserFromJson(string json)
        {
            storereply post = JsonConvert.DeserializeObject<storereply>(json);
            return post;
        }*/
        public storereply()
        {
        }

        /*  public string ToJsonString()
          {
              return JsonConvert.SerializeObject(this);
          }*/

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
        public async Task<String> loadpost(string url)
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
        public async void savereply()
        {
            try
            {

                Jsonconverter jsonapi = new Jsonconverter();



                //    postdata topic = new postdata(""+postinput.FindByName<Entry>(postinput.c.Text+"",""+ postinput.FindByName<Editor>(detail).Text+"");

                List<storetopic> lists = new List<storetopic>();
                 lists = replypage.listreply;
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

                DateTime dt = DateTime.Now.ToLocalTime();
                DateTime date= dt.Date;
           
                string postids = id.ToString();
                string datauser = DependencyService.Get<ISaveAndLoad>().LoadText("temp.txt");
               string[] testarray= datauser.Split(',');
                string username = testarray[1];
                Console.WriteLine(datauser);
                storetopic storereply = new storetopic(id, "" + detail.Text + "", "" + date + "", "monkey.jpg",""+postname+"",""+username+"");
                listreply.Add(storereply);
                id+=1;
               // list.ForEach(Console.WriteLine);

                // Console.WriteLine(list);
                /* storeuser testpost = jsonapi.ListToJason(list);
                   testpost.saveuser();*/
                storereply testpost =new storereply();
                testpost.savereply();
                //  DisplayAlert("Success!", "" + topic.Text + "", "" + detail.Text + "", "OK");
                storeuser userinfo = new storeuser();
              //  StreamReader sr = new StreamReader();

               // storeuser testuser = await storeuser.loaduser("" + username.Text + "");
                string tested = userinfo.password;

                Console.WriteLine("posted success");
                DisplayAlert("Success!", "You are succssfullt replied!", "OK");
                await Navigation.PushAsync(new detail(data));
            }
        }
    }
	}
