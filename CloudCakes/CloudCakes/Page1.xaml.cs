using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace CloudCakes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
			InitializeComponent ();
		}
        // On button click event come here
        async void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            
            if(button.Text=="Go To Baby Section")
            {
                // Redirect to baby section
                //Navigation.PushModalAsync(new BabySection());
                await Navigation.PushAsync(new BabySection());
            }
            if (button.Text =="Go To Doctor Section")
            {
                /* await DisplayAlert("Clicked!",
                 "The button labeled '" + button.Text + "' has been clicked",
                 "OK");*/
                // Redirect to Doctor section
                // Navigation.PushModalAsync(new DoctorSection());
                // Redirect with Header bar function
                await Navigation.PushAsync(new DoctorSection());
            }
            
        }
    }
}
