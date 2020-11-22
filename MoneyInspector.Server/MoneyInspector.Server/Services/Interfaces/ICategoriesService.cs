using MoneyInspector.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyInspector.Server.Services.Interfaces
{
    public interface ICategoriesService
    {
        List<CategorySumModel> GetAllCategorySums();

        List<CategorySumModel> GetCategorySumsByPeriod(DateTimePeriod period);

        List<CategoryModel> GetAllCategories();
    }
}
