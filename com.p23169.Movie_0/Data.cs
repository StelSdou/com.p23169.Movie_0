using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.p23169.Movie_0
{
    internal class Data
    {
        public List<string> LNames = new List<string>();
        public List<string> LPaths = new List<string>();
        public int sum;
        public Data(string path)
        {
            this.sum = Directory.GetFiles(path).Length - 1;
            foreach (string file in Directory.GetFiles(path))
            {
                LPaths.Add(file);
                LNames.Add(name(file, path));
            }
        }
        private string name(string file, string path) {
            return file.Replace("_", " ").Replace(path, "").Replace(".jpg", "").Replace(".png", "");
        }
    }
}
