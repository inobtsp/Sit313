using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

using Xamarin.Forms;

namespace App5
{
    class postdata
    {
        public string Posttopic { get; set; }
        public string Postdetail { get; set; }
        public int Postid { get; set; }
        public postdata(int postid,string posttopic, string postdetail)
        {
            this.Postid = postid;
            this.Posttopic = posttopic;
            this.Postdetail = postdetail;
        }

    }
}
