using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CloudCakes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BabySection : ContentPage
	{
		public BabySection ()
		{
			InitializeComponent ();
            // Header bar function
            NavigationPage.SetBackButtonTitle(this, ""); // Empty text
            NavigationPage.SetHasBackButton(this, true); // No back button
        }
        async void Gotoregisterpage(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new BabyRegistrationSection());
        }
        async void Gotoforgetpassword(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ForgetPassword());
        }
    }
}
