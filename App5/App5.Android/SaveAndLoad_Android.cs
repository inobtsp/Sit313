using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using App5.Droid;
using System.IO;
using System.Threading.Tasks;


[assembly: Dependency(typeof(SaveAndLoad_Android))]
namespace App5.Droid
{
    public class SaveAndLoad_Android : ISaveAndLoad
    {
      

        public void SaveText(string filename, string text)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            System.IO.File.WriteAllText(filePath, text);
        }

        public string LoadText(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            return System.IO.File.ReadAllText(filePath);
        }

        public bool FileExists(string filename)
        {
            return File.Exists(CreatePathToFile(filename));
        }

      

        string CreatePathToFile(string filename)
        {
            var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(docsPath, filename);
        }
    }
}