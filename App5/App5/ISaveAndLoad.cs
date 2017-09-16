using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App5
{
  public interface  ISaveAndLoad
    {
      void  SaveText(string filename, string text);
        string LoadText(string filename);
        bool FileExists(string filename);
    }
}
