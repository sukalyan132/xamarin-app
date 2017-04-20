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
	public partial class DoctorRegistrationSection : ContentPage
	{
        private bool isJson;
        private char serializedDataString;

        public DoctorRegistrationSection ()
		{
			InitializeComponent ();
            // Header bar function
            NavigationPage.SetBackButtonTitle(this, ""); // Empty text
            NavigationPage.SetHasBackButton(this, true); // No back button
            
        }

        public class Person
        {
            public string message { get; set; }
           // public DateTime Birthday { get; set; }
        }
        async void Save(object sender, EventArgs args)
        {

            /* await DisplayAlert("Members", UserName.Text + "," + UserPassword.Text + "," + PhoneNo.Text + "," + FullName.Text, "Cancel");
           
            
            */
            try
            {
                /*
                string sUrl = "http://192.168.1.188//webservice/user.php";
                string sContentType = "application/json"; // or application/xml

                JObject oJsonObject = new JObject();
                oJsonObject.Add("any key", UserName.Text);

                HttpClient oHttpClient = new HttpClient();
                var oTaskPostAsync = oHttpClient.PostAsync(sUrl, new StringContent(oJsonObject.ToString(), Encoding.UTF8, sContentType));
                oTaskPostAsync.ContinueWith((oHttpResponseMessage) =>
                {
                });
               
                Uri requestUri = new Uri("http://192.168.1.188:3600/api"); //replace your Url  
                dynamic dynamicJson = new ExpandoObject();
                dynamicJson.username = "sureshmit55@gmail.com".ToString();
                dynamicJson.password = "9442921025";
                string json = "";
                json = Newtonsoft.Json.JsonConvert.SerializeObject(dynamicJson);
                var objClint = new System.Net.Http.HttpClient();
                System.Net.Http.HttpResponseMessage respon = await objClint.PostAsync(requestUri, new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
                string responJsonText = await respon.Content.ReadAsStringAsync();
               
              
                var rxcui = "198440";
                var request = HttpWebRequest.Create(string.Format(@"http://192.168.1.188:3600/api", rxcui));
                request.ContentType = "application/json";
                request.Method = "POST";
               // request.RequestFormat = DataFormat.Json;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        Console.Out.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        var content = reader.ReadToEnd();
                        var Items = JsonConvert.DeserializeObject(content);
                        if (string.IsNullOrWhiteSpace(content))
                        {
                            Console.Out.WriteLine("Response contained empty body...");
                        }
                        else
                        {
                            Console.Out.WriteLine("Response Body: \r\n {0}", Items);
                        }

                        //Assert.NotNull(content);
                    }
                }
               */
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://192.168.1.188:3600/");
                string jsonData = "{\"username\" : \""+ UserName.Text + "\",\"password\": \""+ UserPassword.Text + "\",\"phone\" : \"" + PhoneNo.Text + "\",\"fullName\" : \"" + FullName.Text + "\",\"email\" : \"" + EmailId.Text + "\"}";
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("api/userRegistation", content);

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
                   // Console.Out.WriteLine(person2.message);
                    await Navigation.PushAsync(new UserDashboard());
                }
            }
            catch(Exception ex)
            {

            }
            
        }
    }
   
}
