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
        public string Belongstopic { get;set; }
        public string Senduser { get; set; }

        public postdata(int postid,string posttopic, string postdetail,string belongstopic,string senduser)
        {
            this.Postid = postid;
            this.Posttopic = posttopic;
            this.Postdetail = postdetail;
            this.Belongstopic = belongstopic;
            this.Senduser = senduser;
                
        }

    }
}
