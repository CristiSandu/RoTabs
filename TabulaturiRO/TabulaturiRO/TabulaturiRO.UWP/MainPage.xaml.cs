using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TabulaturiRO.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            var documentsPath = ApplicationData.Current.LocalFolder.Path;
            var dbPath = Path.Combine(documentsPath, "artistsdb.sqlite");

            var storageFile = IsolatedStorageFile.GetUserStoreForApplication();

           /* if (!storageFile.FileExists(dbPath))
            {
                using (var resourceStream = Application.GetResourceStream(new Uri("artistsdb.sqlite", UriKind.Relative)).Stream)
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
