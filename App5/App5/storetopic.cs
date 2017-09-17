using System;
using System.Collections.Generic;
using System.Text;

namespace App5
{
    class storetopic
    {
        public string Replytopic { get; set; }
        public string Replytime { get; set; }
        public string Replyimage { get; set; }
        public string Belongpost { get; set; }
        public int Replyid { get; set; }
        public string Replyname { get; set; }
        public storetopic(int replyid, string replytopic, string replytime,string replyimage,string belongpost ,string replyname)
        {
            this.Replyid= replyid;
            this.Replytopic = replytopic;
            this.Replytime = replytime;
            this.Replyimage = replyimage;
            this.Belongpost = belongpost;
            this.Replyname = replyname;
        }
        public storetopic()
        {
           
        }
    }
}
