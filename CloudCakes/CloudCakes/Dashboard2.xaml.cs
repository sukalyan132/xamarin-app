using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;

namespace CloudCakes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Dashboard2 : ContentPage
	{
        public class ItemClass
        {
            public string ArticleTitle { get; set; }
            public string description { get; set; }
        }
        public Dashboard2 ()
		{
			InitializeComponent ();
            LoadData();
        }
        public async void LoadData()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.1.188:3600/");
            string jsonData = "";
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("api/doctorLogin", content);

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
            var result = await response.Content.ReadAsStringAsync();
            // var person2 = JsonConvert.DeserializeObject<Person>(result);
            var Items = JsonConvert.DeserializeObject<List<ItemClass>>(result);
            ListView1.ItemsSource = Items;
        }
    }
}
