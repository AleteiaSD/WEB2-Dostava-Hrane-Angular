using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class PorudzbinaContext : DbContext
    {
        public PorudzbinaContext(DbContextOptions<PorudzbinaContext> options) : base(options)
        {

        }

    }
}

