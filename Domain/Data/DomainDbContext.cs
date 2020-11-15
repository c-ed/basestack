using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using SqwareBase.Domain.Model;

namespace SqwareBase.Domain.Data
{
    public class DomainDbContext : DbContext
    {
        public DbSet<Widget> Widgets { get; set; }

        public DomainDbContext(DbContextOptions<DomainDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(ConvertToSnakeCase(entity.GetTableName()));

                foreach (var property in entity.GetProperties())
                {
                    if (property.ClrType.IsEnum)
                        modelBuilder.Entity(entity.Name).Property(property.Name).HasConversion<string>();

                    property.SetColumnName(ConvertToSnakeCase(property.Name));
                }

                foreach (var key in entity.GetKeys())
                    key.SetName(ConvertToSnakeCase(key.GetName()));

                foreach (var key in entity.GetForeignKeys())
                    key.SetConstraintName(ConvertToSnakeCase(key.GetConstraintName()));

                foreach (var index in entity.GetIndexes())
                    index.SetName(ConvertToSnakeCase(index.GetName()));
            }
        }

        private string ConvertToSnakeCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var startUnderscores = Regex.Match(input, @"^_+");

            return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }
    }
}
