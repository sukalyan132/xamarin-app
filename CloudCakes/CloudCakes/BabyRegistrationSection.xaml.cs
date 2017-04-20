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
	public partial class BabyRegistrationSection : ContentPage
	{
		public BabyRegistrationSection ()
		{
			InitializeComponent ();
            // Header bar function
            NavigationPage.SetBackButtonTitle(this, ""); // Empty text
            NavigationPage.SetHasBackButton(this, true); // No back button
        }
        async void Save(object sender, EventArgs args)
        {

            /* await DisplayAlert("Members", UserName.Text + "," + UserPassword.Text + "," + PhoneNo.Text + "," + FullName.Text, "Cancel");
           
            
            */
            try
            {
                
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://192.168.1.188:3600/");
                string jsonData = "{\"username\" : \"" + UserName.Text + "\",\"password\": \"" + UserPassword.Text + "\",\"phone\" : \"" + PhoneNo.Text + "\",\"fullName\" : \"" + FullName.Text + "\",\"email\" : \"" + EmailId.Text + "\"}";
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("api/babyRegistation", content);

                // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
                var result = await response.Content.ReadAsStringAsync();
                Console.Out.WriteLine("Response Body: \r\n {0}", result);
                // respon.Redirect(requestUri, false);
                if (response.StatusCode != HttpStatusCode.OK)
                {

                }
                else
                {
                    Console.Out.WriteLine(response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}
