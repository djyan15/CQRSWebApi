using CQRSWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CQRSWebApi.Context
{
    public interface IApplicationContext
    {
        DbSet<Product> Products { get; set; }

        Task<int> SaveChanges();
    }
}