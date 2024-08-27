using Ecommerce.Application.Common;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Identity.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Sql.DataAccess;

public partial class DataContext : IdentityDbContext<ApplicationUser>, IDataContext
{
    //private readonly ICurrentUser _currentUser;
    private readonly IHttpContextAccessor _httpContext;

    public DataContext(DbContextOptions<DataContext> options, IHttpContextAccessor httpContext) : base(options)
    {
        //_currentUser = currentUser;
        _httpContext = httpContext;
        this.Database.Migrate();
    }
    //protected override void OnConfiguring(DbContextOptionsBuilder options)
    //{
    //    if (!options.IsConfigured)
    //    {
    //        options.UseSqlServer("A FALLBACK CONNECTION STRING");
    //    }
    //}

    //protected override void OnConfiguring(DbContextOptionsBuilder options)
    //{
    //    base.OnConfiguring(options);
    //    options.UseSqlServer("Server=DESKTOP-S50IT9A\\SQLEXPRESS;Database=ticketvip2024;User Id=sa;Password=Phamtien@123;MultipleActiveResultSets=true;TrustServerCertificate=True;Encrypt=False;");
    //}



    public DbSet<Gallery> Galleries { get; set; }
 
    public DbSet<AppConfiguration> AppConfigurations { get; set; }
  
   public DbSet<Customer> Customers { get; set; }
  
    public DbSet<PortfolioCategory> PortfolioCategorys { get; set; }
  
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<TicketBook> TicketBooks { get; set; }


}
