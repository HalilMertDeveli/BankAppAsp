using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Udemy.BankApp.Data.Entities;

namespace Udemy.BankApp.Data.Configuration
{
    public class AccountConfiguration :IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(x => x.Balance).HasColumnType("decimal(18,4)");
            builder.Property(x => x.Balance).IsRequired(true);


            builder.Property(x => x.AccountNumber).IsRequired(true);

        }
    }
}
