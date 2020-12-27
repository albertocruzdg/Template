using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SomeApplication.Business.Model;

namespace SomeApplication.Repository.Extensions
{
    internal static class EntityTypeConfigurationExtensions
    {
        /// <summary>
        ///    Configures an owned-type of type MoneyAmount.        
        /// </summary>
        public static EntityTypeBuilder<TEntity> OwnsOneMoneyAmount<TEntity>(this EntityTypeBuilder<TEntity> builder, Expression<Func<TEntity, MoneyAmount>> navigationExpression, string amountColumnName = nameof(MoneyAmount.Amount), string currencyColumnName = nameof(MoneyAmount.Currency))
            where TEntity : Entity
        {
            return builder.OwnsOneComplexType(navigationExpression, moneyBuilder =>
            {
                moneyBuilder.Property(x => x.Amount).HasColumnName(amountColumnName);
                moneyBuilder.Property(x => x.Currency).HasColumnName(currencyColumnName);
            });
        }

        /// <summary>
        ///    Configures an owned-type and EF's default shadow property to match default Id property.        
        /// </summary>
        public static EntityTypeBuilder<TEntity> OwnsOneComplexType<TEntity, TRelatedEntity>(this EntityTypeBuilder<TEntity> builder, Expression<Func<TEntity, TRelatedEntity>> navigationExpression, Action<OwnedNavigationBuilder<TEntity, TRelatedEntity>> buildAction)
            where TEntity : Entity
            where TRelatedEntity : class
        {
            return builder.OwnsOne(navigationExpression, relatedBuilder =>
            {
                buildAction(relatedBuilder);

                relatedBuilder.Property<Guid>(nameof(Entity.Id));
                relatedBuilder.WithOwner().HasForeignKey(nameof(Entity.Id));
            });
        }
    }
}
