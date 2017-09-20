using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;

namespace App5
{
    class Jsonconverter
    {
        public Jsonconverter()
        {

        }
        // convet post  string to object 
        public string ToJasonString(postdata postdata)
        {
            return JsonConvert.SerializeObject(postdata);
        }
        //convert post string to object
        public string ToJasonstring(string sting)
        {
            return JsonConvert.SerializeObject(sting);
        }
        // convet post  list to object 
        public postdata ToObject(String jason)
        {
            postdata postdatas = JsonConvert.DeserializeObject<postdata>(jason);
            return postdatas;
        }
        // convet post  object to string
        public string ToObjectstring(String jason)
        {
            string postdatas = JsonConvert.DeserializeObject<string>(jason);
            return postdatas;
        }
        // convet post  string to object list
        public List<postdata> List(String jason)
        {
            List<postdata> list = JsonConvert.DeserializeObject<List<postdata>>(jason);
            return list;
        }
        // convet reply string to object list
        public List<storetopic> Listreply(String jason)
        {
            List<storetopic> list = JsonConvert.DeserializeObject<List<storetopic>>(jason);
            return list;
        }
        // convet post to string
        public String ListToJason(List<postdata> posts)
        {
            String jason = JsonConvert.SerializeObject(posts);
            return jason;
        }
        // convet object to reply list
        public String ListToJasonreply(List<storetopic> posts)
        {
            String jason = JsonConvert.SerializeObject(posts);
            return jason;
        }
    }
}