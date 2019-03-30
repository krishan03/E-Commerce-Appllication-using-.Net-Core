using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace AmCart.Core.Domain
{
    public abstract class DomainBase : IDomain
    {
       

        #region Ctor
        public DomainBase()
        {
           // this.ModifiedOnDate = DateTime.UtcNow;
        }
        #endregion

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }

        ///// <summary>
        ///// Gets the created on date.
        ///// </summary>
        ///// <value>
        ///// The created on date.
        ///// </value>
        //[BsonDateTimeOptions]
        //public DateTimeOffset CreatedOnDate { get; set; }

        ///// <summary>
        ///// Gets the modified on date.
        ///// </summary>
        ///// <value>
        ///// The modified on date.
        ///// </value>
        //[BsonDateTimeOptions]
        //public DateTimeOffset ModifiedOnDate { get; set; }

        /// <summary>
        /// Gets or sets the IsActive.
        /// </summary>
        /// <value>The IsActive.</value>
        public bool IsActive { get; set; }

    }
}
