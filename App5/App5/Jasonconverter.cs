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

        public string ToJasonString(postdata postdata)
        {
            return JsonConvert.SerializeObject(postdata);
        }

        public postdata ToObject(String jason)
        {
            postdata postdatas = JsonConvert.DeserializeObject<postdata>(jason);
            return postdatas;
        }

        public List<postdata> List(String jason)
        {
            List<postdata> list = JsonConvert.DeserializeObject<List<postdata>>(jason);
            return list;
        }

        public String ListToJason(List<postdata> posts)
        {
            String jason = JsonConvert.SerializeObject(posts);
            return jason;
        }

    }
}