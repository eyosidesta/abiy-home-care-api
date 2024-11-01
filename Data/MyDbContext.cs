using Microsoft.EntityFrameworkCore;
using model.email;

namespace data.email
{
    public class MyDbContext: DbContext {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) {}
        public DbSet<EmailModel> EmailModels { get; set; }
    }
}