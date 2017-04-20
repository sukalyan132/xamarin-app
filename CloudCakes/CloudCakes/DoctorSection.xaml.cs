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
	public partial class DoctorSection : ContentPage
	{
		public DoctorSection ()
		{
			InitializeComponent ();
            NavigationPage.SetBackButtonTitle(this, ""); // Empty text
            NavigationPage.SetHasBackButton(this, true); // No back button
        }
        async void Gotoregisterpage(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new DoctorRegistrationSection());
        }
        async void Gotoforgetpassword(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Gotoforgetpassword());
        }
        // login check function
        async void Save(object sender, EventArgs args)
        {

            /* await DisplayAlert("Members", UserName.Text + "," + UserPassword.Text + "," + PhoneNo.Text + "," + FullName.Text, "Cancel");
           
            
            */
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://192.168.1.188:3600/");
                string jsonData = "{\"username\" : \"" + Username.Text + "\",\"password\": \"" + Password.Text + "\"}";
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("api/doctorLogin", content);

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
                    await Navigation.PushAsync(new DoctorDashboard());
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}
