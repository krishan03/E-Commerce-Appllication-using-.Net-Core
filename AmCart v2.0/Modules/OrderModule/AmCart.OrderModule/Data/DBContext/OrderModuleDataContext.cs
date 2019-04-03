using AmCart.Core.ExceptionManagement.CustomException;
using AmCart.OrderModule.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AmCart.OrderModule.Data.DBContext
{
    public class OrderModuleDataContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrderModuleDataContext(DbContextOptions options): base(options)
        {
        }

        public override int SaveChanges()
        {
            string errorMessage = string.Empty;
            var entities = (from entry in ChangeTracker.Entries()
                            where entry.State == EntityState.Modified || entry.State == EntityState.Added
                            select entry.Entity);

            var validationResults = new List<ValidationResult>();
            List<ValidationException> validationExceptionList = new List<ValidationException>();
            foreach (var entity in entities)
            {
                // errorMessage += ValidateResult(validationResults, entity);
                if (!Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults, true))
                {
                    foreach (var result in validationResults)
                    {
                        if (result != ValidationResult.Success)
                        {
                            //throw new ValidationException(result.ErrorMessage);
                            validationExceptionList.Add(new ValidationException(result.ErrorMessage));

                        }
                    }
                    //    //throw new ValidationException(;

                    //}

                    throw new ValidationExceptions(validationExceptionList);
                }
            }

            return base.SaveChanges();
        }
    }
}
