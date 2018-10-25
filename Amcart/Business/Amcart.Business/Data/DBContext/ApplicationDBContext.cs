using Amcart.Business.Domain;
using Amcart.Core.ExceptionManagement.CustomException;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Amcart.Business.Data.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options)
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
            //if (!(string.IsNullOrEmpty(errorMessage)))
            //{
            //    throw new ValidationException(errorMessage);
            //}
            return base.SaveChanges();



        }
    }
}
