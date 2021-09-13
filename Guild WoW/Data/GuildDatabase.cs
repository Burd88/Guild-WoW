using Notes.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notes.Data
{
    public class NoteDatabase
    {
        readonly SQLiteAsyncConnection database;

        public NoteDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Guild>().Wait();
        }

        public Task<List<Guild>> GetNotesAsync()
        {
            //Get all notes.
            return database.Table<Guild>().ToListAsync();
        }

        public Task<Guild> GetNoteAsync(int id)
        {
            // Get a specific note.
            return database.Table<Guild>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Guild guild)
        {
            if (guild.ID != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(guild);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(guild);
            }
        }

        public Task<int> DeleteNoteAsync(Guild guild)
        {
            // Delete a note.
            return database.DeleteAsync(guild);
        }
    }
}