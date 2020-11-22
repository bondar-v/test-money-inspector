using MoneyInspector.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyInspector.Server.Services.Interfaces
{
    public interface INotesService
    {
        public void UpdateNote(UpdateNoteModel note);

        public void RemoveNote(int id);

        public void AddNote(NewNoteModel note);

        public List<NoteModel> GetAllNotes();

        public List<NoteModel> GetNotesByPeriod(DateTimePeriod period);
    }
}
