using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CloudCakes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DoctorRegistrationSection : ContentPage
	{
		public DoctorRegistrationSection ()
		{
			InitializeComponent ();
            // Header bar function
            NavigationPage.SetBackButtonTitle(this, ""); // Empty text
            NavigationPage.SetHasBackButton(this, true); // No back button
            
        }
        async void Save(object sender, EventArgs args)
        {
            await DisplayAlert("Members", UserName.Text + "," + UserPassword.Text + "," + PhoneNo.Text + "," + FullName.Text, "Cancel");
            var rxcui = "198440";
            var request = HttpWebRequest.Create(string.Format(@"http://localhost/webservice/user.php", rxcui));
            request.ContentType = "application/json";
            request.Method = "GET";

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                Console.Out.WriteLine(response);
            }
        }
    }
}
