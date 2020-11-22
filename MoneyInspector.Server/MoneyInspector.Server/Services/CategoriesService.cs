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
    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Note> notesRepository;
        private readonly IRepository<Category> categoriesRepository;

        public CategoriesService(IRepository<Note> notesRepository, IRepository<Category> categoriesRepository)
        {
            this.notesRepository = notesRepository;
            this.categoriesRepository = categoriesRepository;
        }

        public List<CategoryModel> GetAllCategories()
        {
            return categoriesRepository.GetByFilter(category => true).Select(category => new CategoryModel
            {
                Id = category.Id,
                Name = category.Name
            }).ToList();
        }

        public List<CategorySumModel> GetAllCategorySums()
        {
            var categories = categoriesRepository.GetByFilter(category => true).ToList();
            var notes = notesRepository.GetByFilter(note => true).ToList();

            return categories.Select(category => new CategorySumModel
            {
                Category = new CategoryModel { Id = category.Id, Name = category.Name },
                Sum = notes.Where(note => note.CategoryId == category.Id).Sum(note => note.Price)
            }).ToList();
        }

        public List<CategoryModel> GetCategoriesByPeriod(DateTimePeriod period)
        {
            var categories = categoriesRepository.GetByFilter(category => true).ToList();
            var notes = notesRepository.GetByFilter(note => note.CreatedAt >= period.StartDate && note.CreatedAt <= period.EndDate).ToList();

            return categories.Select(category => new CategoryModel
            {
                Id = category.Id,
                Name = category.Name
            }).ToList();
        }

        public List<CategorySumModel> GetCategorySumsByPeriod(DateTimePeriod period)
        {
            var categories = categoriesRepository.GetByFilter(category => true).ToList();
            var notes = notesRepository.GetByFilter(note => note.CreatedAt >= period.StartDate && note.CreatedAt <= period.EndDate).ToList();

            return categories.Select(category => new CategorySumModel
            {
                Category = new CategoryModel { Id = category.Id, Name = category.Name },
                Sum = notes.Where(note => note.CategoryId == category.Id).Sum(note => note.Price)
            }).ToList();
        }
    }
}
