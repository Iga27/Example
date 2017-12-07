using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {

            var uri = new Uri("https://github.com/");
            var client = new WebClient();
           /* var byteArray=client.DownloadData(uri);
            string text = Encoding.UTF8.GetString(byteArray);

            var array = client.DownloadData(new Uri("http://localhost:63553/api/quiz"));
            var t = Encoding.UTF8.GetString(array);



            var question=JsonConvert.DeserializeObject<Question>(t);
              foreach(var option in question.Options)
             {
                 Console.WriteLine(option.OptionId+" " + option.OptionText+" "+option.IsCorrect);
             }*/

            //HtmlDocument
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://realt.by/brest-region/sale/flats/search/");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string text;
            /*using (var sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                text = sr.ReadToEnd();
                 
            }*/
            HtmlDocument doc = new HtmlDocument();
            //doc.LoadHtml(text);
            doc.Load(response.GetResponseStream(),Encoding.UTF8);

            var result = doc.DocumentNode.SelectSingleNode("//*[@id=\"wrapper\"]/div[3]/div[2]")
                .SelectSingleNode("//*[@id=\"c1030\"]/div").SelectSingleNode("//*[@id=\"tx_uedbflat_pi2\"]");

            ////////////////////////
            Developer dev = new PanelDeveloper("ООО КирпичСтрой");
            House house2 = dev.Create();



        }
    }

    // абстрактный класс строительной компании
    abstract class Developer
    {
        public string Name { get; set; }

        public Developer(string n)
        {
            Name = n;
        }
        // фабричный метод
        abstract public House Create();
    }
    // строит панельные дома
    class PanelDeveloper : Developer
    {
        public PanelDeveloper(string n) : base(n)
        { }

        public override House Create()
        {
            return new PanelHouse();
        }
    }
    // строит деревянные дома
    class WoodDeveloper : Developer
    {
        public WoodDeveloper(string n) : base(n)
        { }

        public override House Create()
        {
            return new WoodHouse();
        }
    }

    abstract class House
    { }

    class PanelHouse : House
    {
        public PanelHouse()
        {
            Console.WriteLine("Панельный дом построен");
        }
    }
    class WoodHouse : House
    {
        public WoodHouse()
        {
            Console.WriteLine("Деревянный дом построен");
        }
    }
}
