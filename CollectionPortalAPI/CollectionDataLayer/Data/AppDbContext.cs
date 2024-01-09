using Microsoft.EntityFrameworkCore;

namespace CollectionDataLayer.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{

}
