using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteAddPage : ContentPage
    {
        public Note Note;
        public string imagingpath;
        public NoteAddPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            if (Note != null)
            {
                Note = await App.NoteDB.GetNoteAsync(Note.id);
            }
            else
            {
                Note = new Note();
            }
            BindingContext = Note;
            base.OnAppearing();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var result = await FilePicker.PickAsync(PickOptions.Images);
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                ImageUser.Source = ImageSource.FromStream(() => stream);
                imagingpath = result.FullPath;
                Note.Url = result.FullPath;
                Debug.Write(Note.Url);
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(Name.Text) && !string.IsNullOrWhiteSpace(Text.Text))
            {
                Note note = new Note();
                note.Name = Name.Text;
                note.Description = Text.Text;
                Debug.WriteLine(Note.Url);
                //Note = (Note)BindingContext;
                if (imagingpath != null)
                    note.Url = imagingpath;
                Debug.WriteLine(note.Url);
                await App.NoteDB.SaveNoteAsync(note);

                await Navigation.PopAsync();
            }

        }
    }
}