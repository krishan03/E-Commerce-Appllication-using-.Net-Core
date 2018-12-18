using AmCart.Core.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace AmCart.CustomerModule
{
    public class Customer : DomainBase
    {
        public ObjectId UserId  { get; set; }

        public string Gender { get; set; }

        public string DOB { get; set; }

        public string Phone { get; set; }

        public IList<Address> Addresses { get; set; }

        public IList<ProductLite> Wishlist { get; set; }

        public IList<CartProduct> Cart { get; set; }
    }
}
