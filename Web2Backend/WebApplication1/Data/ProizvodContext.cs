using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ProizvodContext : DbContext
    {
        public ProizvodContext(DbContextOptions<ProizvodContext> options) : base(options)
        {

        }

        }
    }
