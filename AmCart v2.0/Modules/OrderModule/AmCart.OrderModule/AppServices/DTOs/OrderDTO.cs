using AmCart.Core.AppServices;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.OrderModule.AppServices.DTOs
{
    public class OrderDTO : DtoBase
    {
        public AddressDTO DeliveryAddress { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerId { get; set; }

        public string PaymentType { get; set; }

        public string TrackingNumber { get; set; }

        public IList<ProductDTO> OrderedProducts { get; set; }

        public double TotalAmountPayable { get; set; }

        public double TaxPercentage { get; set; }

        public IList<StatusDTO> Status { get; set; }



        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }
    }
}
