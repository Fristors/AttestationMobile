using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteMobile
{
    public partial class App : Application
    {
        static NoteDB _noteDB;
        public static NoteDB NoteDB
        {
            get
            {
                if (_noteDB == null)
                {
                    _noteDB = new NoteDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Note.db"));
                }
                return _noteDB;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
