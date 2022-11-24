using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class SlikaContext : DbContext
    {
        public SlikaContext(DbContextOptions<SlikaContext> options) : base(options)
        {

        }

    }
}
