using MoneyInspector.Server.Data.Entities;
using MoneyInspector.Server.Data.Interfaces;
using MoneyInspector.Server.Models;
using MoneyInspector.Server.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyInspector.Server.Services
{
    public class NotesService : INotesService
    {
        private readonly IRepository<Note> notesRepository;
        private readonly IRepository<Category> categoriesRepository;

        public NotesService(IRepository<Note> notesRepository, IRepository<Category> categoriesRepository)
        {
            this.notesRepository = notesRepository;
            this.categoriesRepository = categoriesRepository;
        }

        public void AddNote(NewNoteModel note)
        {
            var category = categoriesRepository.GetByFilter(category => category.Id == note.CategoryId).First();

            notesRepository.Add(new Note
            {
                Category = category,
                Notice = note.Notice,
                Price = note.Price,
                CreatedAt = DateTime.UtcNow,
            });
        }

        public List<NoteModel> GetAllNotes()
        {
            var notes = notesRepository.GetByFilter(note => true).ToList();
            var categories = categoriesRepository.GetByFilter(note => true).ToList();

            return notes.Select(note => new NoteModel
            {
                Id = note.Id,
                Category = new CategoryModel
                {
                    Id = note.CategoryId,
                    Name = categories.Where(category => category.Id == note.CategoryId).First().Name
                },
                Notice = note.Notice,
                CreatedAt = note.CreatedAt,
                Price = note.Price
            }).ToList();
        }

        public List<NoteModel> GetNotesByPeriod(DateTimePeriod period)
        {
            var notes = notesRepository.GetByFilter(note => note.CreatedAt >= period.StartDate && note.CreatedAt <= period.EndDate).ToList();
            var categories = categoriesRepository.GetByFilter(note => true).ToList();

            return notes.Select(note => new NoteModel
            {
                Id = note.Id,
                Category = new CategoryModel
                {
                    Id = note.CategoryId,
                    Name = categories.Where(category => category.Id == note.CategoryId).First().Name
                },
                Notice = note.Notice,
                CreatedAt = note.CreatedAt,
                Price = note.Price
            }).ToList();
        }

        public void RemoveNote(int id)
        {
            var note = notesRepository.GetByFilter(note => note.Id == id).First();

            notesRepository.Delete(note);
        }

        public void UpdateNote(UpdateNoteModel note)
        {
            var category = categoriesRepository.GetByFilter(category => category.Id == note.CategoryId).First();
            var noteForUpdate = notesRepository.GetByFilter(n => n.Id == note.Id).First();

            noteForUpdate.Category = category;
            noteForUpdate.Notice = note.Notice;
            noteForUpdate.Price = note.Price;
            
            notesRepository.Update(noteForUpdate);
        }
    }
}
