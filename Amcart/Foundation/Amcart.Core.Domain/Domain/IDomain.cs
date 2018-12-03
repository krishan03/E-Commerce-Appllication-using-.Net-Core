using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amcart.Core.Domain
{
    public interface IDomain
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        ObjectId Id { get; set; }
    }
}
