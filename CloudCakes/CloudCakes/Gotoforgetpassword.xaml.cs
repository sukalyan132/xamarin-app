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
	public partial class Gotoforgetpassword : ContentPage
	{
		public Gotoforgetpassword ()
		{
			InitializeComponent ();
            // Header bar function
            NavigationPage.SetBackButtonTitle(this, ""); // Empty text
            NavigationPage.SetHasBackButton(this, true); // No back button
        }
	}
}
