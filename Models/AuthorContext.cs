using Microsoft.EntityFrameworkCore;

namespace dotnet.Models {
    public class AuthorContext : DbContext {
        public AuthorContext (DbContextOptions<AuthorContext> options) : base (options) {

        }
        public DbSet<Author> AuthorsList { get; set; }

    }
}