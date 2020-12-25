using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SomeApplication.Business.Model;

namespace SomeApplication.Repository.Extensions
{
    internal static class EntityTypeConfigurationExtensions
    {
        public static EntityTypeBuilder<TEntity> OwnsOneMoneyAmount<TEntity>(this EntityTypeBuilder<TEntity> builder, Expression<Func<TEntity, MoneyAmount>> navigationExpression, string amountColumnName = nameof(MoneyAmount.Amount), string currencyColumnName = nameof(MoneyAmount.Currency))
            where TEntity : Entity
        {
            return builder.OwnsOne(navigationExpression, moneyBuilder =>
            {
                moneyBuilder.Property(x => x.Amount).HasColumnName(amountColumnName);
                moneyBuilder.Property(x => x.Currency).HasColumnName(currencyColumnName);
            });
        }
    }
}
