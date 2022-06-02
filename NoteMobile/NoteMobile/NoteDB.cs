using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace NoteMobile
{
    public class NoteDB
    {
        public SQLiteAsyncConnection db { get; set; }
        public NoteDB(string connectionString)
        {
            db = new SQLiteAsyncConnection(connectionString);
            db.CreateTableAsync<Note>().Wait();
        }
        public Task<List<Note>> GetNotesAsync()
        {
            return db.Table<Note>().ToListAsync();
        }
        public Task<Note> GetNoteAsync(int id)
        {
            return db.Table<Note>().Where(u => u.id == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveNoteAsync(Note note)
        {
            if(note.id != 0)
            {
                return db.UpdateAsync(note);
            }
            else
            {
                return db.InsertAsync(note);
            }
        }
        public Task<int> AddNoteAsync(Note note)
        {
            return db.InsertAsync(note);
        }
        public Task<int> DeleteNoteAsync(Note note)
        {
            return db.DeleteAsync(note);
        }
    }
}
