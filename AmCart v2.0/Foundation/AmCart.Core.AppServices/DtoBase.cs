using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.Core.AppServices
{
    public abstract class DtoBase : IDto
    {
       
        public string Id
        {
            get; set ;

        }

           

        /// <summary>
        /// Gets or sets the IsActive.
        /// </summary>
        /// <value>The IsActive.</value>
        public bool IsActive { get; set; }

    }
}
