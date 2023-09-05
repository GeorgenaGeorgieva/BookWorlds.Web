using Azure;
using BookWorlds.Data.Models;
using BookWorlds.Data.Models.Enum;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace BookWorlds.Data
{
    public class BookWorldsDbContext  : IdentityDbContext<User>
    {
        public BookWorldsDbContext()
        {
        }

        public BookWorldsDbContext(DbContextOptions<BookWorldsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Auction> Аuctions { get; set; }
        public override DbSet<User> Users { get; set; }
        public DbSet<UserAuction> UserАuctions { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder modelBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>()
                .HasMany(e => e.Images)
                .WithOne(e => e.Book)
                .HasForeignKey(e => e.BookId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Book>()
                .HasMany(e => e.Comments)
                .WithOne(e => e.Book)
                .HasForeignKey(e => e.BookId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Book>()
               .HasOne(e => e.User)
               .WithMany(e => e.Books)
               .HasForeignKey(e => e.UserId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Book>()
               .HasOne(e => e.Author)
               .WithMany(e => e.Books)
               .HasForeignKey(e => e.AuthorId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Category>()
                .Property(c => c.Name)
                .HasConversion(
                    v => v.ToString(),
                    v => (Genre)Enum.Parse(typeof(Genre), v));

            builder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });

            builder.Entity<BookCategory>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.Categories)
                .HasForeignKey(bc => bc.BookId);

            builder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(bc => bc.CategoryId);

            builder.Entity<User>()
                .HasMany(e => e.Commnets)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Auction>()
                .HasOne(e => e.Book)
                .WithOne(e => e.Auction)
                .HasForeignKey<Auction>(e => e.BookId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserAuction>()
                .HasKey(ua => new { ua.UserId, ua.AuctionId });

            builder.Entity<UserAuction>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.Auctions)
                .HasForeignKey(ua => ua.UserId);

            builder.Entity<UserAuction>()
                .HasOne(ua => ua.Auction)
                .WithMany(c => c.Buyers)
                .HasForeignKey(ua => ua.AuctionId);

            base.OnModelCreating(builder);
        }
    }
}
