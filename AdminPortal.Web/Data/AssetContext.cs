using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdminPortal.Web.Models;

namespace AdminPortal.Web.Data
{
    public class AssetContext : DbContext
    {
        public AssetContext (DbContextOptions<AssetContext> options)
            : base(options)
        {
        }

        public DbSet<Asset> Assets { get; set; }
    }
}
