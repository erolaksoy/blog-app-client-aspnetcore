using System.Collections.Generic;
using System.Threading.Tasks;
using WorksBlogProjectClient.Models;

namespace WorksBlogProjectClient.ApiServices.Interfaces
{
    public interface IBlogApiService
    {
        Task<List<BlogListModel>> GetAllAsync();
        Task<BlogListModel> GetByIdAsync(int id);
        Task<List<BlogListModel>> GetAllByCategoryIdAsync(int id);
        Task InsertAsync(BlogAddModel blogAddModel);
        Task UpdateAsync(BlogUpdateModel blogUpdateModel);
        Task DeleteAsync(int id);
    }
}