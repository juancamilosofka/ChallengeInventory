using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Model;
namespace Infrastructure.Data;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options) { }

    public DBContext() { }
    public virtual DbSet<Buy> buy { get; set; }
    public virtual DbSet<Product> product { get; set; }
    public virtual DbSet<ProductList> productList { get; set; }
}
