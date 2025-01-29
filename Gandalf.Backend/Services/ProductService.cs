using Gandalf.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Gandalf.Backend.Services
{
    public class ProductService(IDbContextFactory<GandalfDbContext> dbContextFactory)
    {
    }
}
