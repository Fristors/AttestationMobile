using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;

namespace NoteMobile
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

        }
        protected override async void OnAppearing()
        {
            /*Note note = new Note()
            {
                Name = "Заметка 3",
                Description = "Первая",
                Url = "/storage/emulated/0/Android/data/com.companyname.notemobile/cache/2203693cc04e0be7f4f024d5f9499e13/39e299ca25474b94bb629b143df4298a/E88pFFAJaig5eiR6lz09UCDsi2wktdnvClyXye80UyvsWz6z1CxZtdON12VCTXAKRstgj7elDOZTVUWvoqPFbz8I.jpg"
            };
            await App.NoteDB.SaveNoteAsync(note);*/

            ListNote.ItemsSource = await App.NoteDB.GetNotesAsync();
            base.OnAppearing();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (ListNote.SelectedItem != null)
            {
                Note note = ListNote.SelectedItem as Note;
                await App.NoteDB.DeleteNoteAsync(note);
                ListNote.ItemsSource = await App.NoteDB.GetNotesAsync();
            }

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoteAddPage());
        }

        private async void ListNote_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            if (ListNote.SelectedItem != null)
            {
                Note note = ListNote.SelectedItem as Note;
                NoteAddPage noteAddPage = new NoteAddPage();
                noteAddPage.Note = note;
                await Navigation.PushAsync(noteAddPage);
            }
        }
    }
}
