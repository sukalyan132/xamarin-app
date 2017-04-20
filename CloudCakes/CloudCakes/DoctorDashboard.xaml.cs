using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CloudCakes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DoctorDashboard : ContentPage
	{
        public class Baby
        {
            public string full_name { get; set; }
        }
        public class ItemClass
        {
            public Baby baby_id { get; set; }
            public string image_url { get; set; }
        }
        public DoctorDashboard ()
		{
			InitializeComponent ();
            LoadData();
        }
        public async void LoadData()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.1.188:3600/");
            var data = "data";
            string jsonData = "{\"username\" : \"" +data+ "\"}";
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("api/babylist", content);

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
            var result = await response.Content.ReadAsStringAsync();
            // var person2 = JsonConvert.DeserializeObject<Person>(result);
            Console.Out.WriteLine("Response Body: \r\n {0}", result);
            // respon.Redirect(requestUri, false);
            if (response.StatusCode != HttpStatusCode.OK)
            {

            }
            else
            {
                Console.Out.WriteLine(response.StatusCode);
               var Items = JsonConvert.DeserializeObject<List<ItemClass>>(result);
               ListView1.ItemsSource = Items;
            }
            
        }
    }
}
