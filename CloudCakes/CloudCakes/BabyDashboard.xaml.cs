using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Plugin.Media.Abstractions;
using System.IO;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace CloudCakes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BabyDashboard : ContentPage
    {
        public BabyDashboard()
        {
            InitializeComponent();
        }
        async void TakeImage(object sender, EventArgs args)
        {
            //var url = "http://192.168.1.188:3600/api/babyImageUpload";
            await CrossMedia.Current.Initialize();
            if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No camera","No camera avlable","Cancel");
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                SaveToAlbum = true,
                Name = "test.jpg"
            });
            if (file == null)
                return;

            // Image1.Source = ImageSource.FromStream(() => file.GetStream());
            try
            {
                StreamContent scontent = new StreamContent(file.GetStream());
                scontent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    FileName = "newimage",
                    Name = "image"
                };
                scontent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                StringContent studentIdContent = new StringContent("2123");
                var client = new HttpClient();
                var multi = new MultipartFormDataContent();
                multi.Add(scontent);
                multi.Add(studentIdContent, "StudentId");
                client.BaseAddress = new Uri("http://192.168.1.188:3600/");
                var result = client.PostAsync("api/babyImageUpload", multi).Result;
                Debug.WriteLine(result.ReasonPhrase);
                if (result.StatusCode != HttpStatusCode.OK)
                {

                }
                else
                {
                    Console.Out.WriteLine(result.ReasonPhrase);
                    if(result.ReasonPhrase=="OK")
                    {
                        await DisplayAlert("SUCCESS","Picture uploaded successfully", "Ok");
                    }
                    //await Navigation.PushAsync(new UserDashboard());
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
