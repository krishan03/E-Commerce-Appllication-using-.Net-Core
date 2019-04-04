using AmCart.Core.AppServices;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.IAMModule.AppService
{
    public class Customer : DtoBase
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        public string Gender { get; set; }

        public string DOB { get; set; }

        public string Phone { get; set; }

        public IList<AddressDTO> Addresses { get; set; }

        public IList<ProductLiteDTO> Wishlist { get; set; }

        public IList<CartProductDTO> Cart { get; set; }
    }
}
