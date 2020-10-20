using System;
using System.IO;
using System.IO.IsolatedStorage;
using Windows.Storage;
using Windows.UI.Xaml;

namespace TabulaturiRO.UWP
{

    public sealed partial class MainPage
    
    {
      
        public MainPage()
        {
            this.InitializeComponent();

            var documentsPath = ApplicationData.Current.LocalFolder.Path;
            var dbPath = Path.Combine(documentsPath, "artistsdb1.sqlite");

            var storageFile = IsolatedStorageFile.GetUserStoreForApplication();
            /*
            if (!storageFile.FileExists(dbPath))
            {
                using (var resourceStream = Application.GetResourceStream(new Uri("artistsdb1.sqlite", UriKind.Relative)).Stream)
                {
                    using (var fileStream = storageFile.CreateFile(dbPath))
                    {
                        byte[] readBuffer = new byte[4096];
                        int bytes = -1;

                         while ((bytes = resourceStream.Read(readBuffer, 0, readBuffer.Length)) > 0)
                         {
                             fileStream.Write(readBuffer, 0, bytes);
                         }
                    }
                }
            }
           */


            LoadApplication(new TabulaturiRO.App(dbPath));
        }
    }
}
