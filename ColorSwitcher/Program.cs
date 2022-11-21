using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ColorSwitcher
{
    public class Program
    {
        static void Main(string[] args)
        {
            InitializeList();
        }

        static List<String> InitializeList()
        {
            Regex isValidColor = new Regex(@"(#(?:[0-9a-f]{2}){2,4}|#[0-9a-f]{3}|(?:rgba?|hsla?)\((?:\d+%?(?:deg|rad|grad|turn)?(?:,|\s)+){2,3}[\s\/]*[\d\.]+%?\))");
            var extensions = new List<string> { ".txt", ".xml", ".css", ".html", ".js" };
            List<String> rgbaList = new List<String>();
            List<String> finalList = new List<String>();
            foreach (string fileName in Directory.EnumerateFiles(@"C:\Users\daniel\Desktop\podmianaKolorow\ZadaniePodmianaKolorowCSS", "*.*", SearchOption.AllDirectories).Where(f => extensions.IndexOf(Path.GetExtension(f)) >= 0)) // sprawdza wszystkie pliki rekruencyjnie w folderze
            {
                String all_files_joined = File.ReadAllText(fileName); // tworzy jeden string z wszystkich pasujacych plikow
                String[] splitted_files = all_files_joined.Split(new String[] { ";", "\n", }, StringSplitOptions.None);
                foreach (String item in splitted_files)
                {
                    if (isValidColor.IsMatch(item))
                    {
                        Match match = isValidColor.Match(item);
                        if (match.Length != 4 && match.Length != 5)
                        {
                            finalList.Add(match.ToString());
                        }
                    }
                }
            }
            return finalList;
        }
    }
}