using AmCart.Core.Domain;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.OrderModule.Domain
{
    public class Order : DomainBase
    {
        public Address DeliveryAddress { get; set; }

        public ObjectId CustomerId { get; set; }

        public string PaymentType { get; set; }

        public string TrackingNumber { get; set; }

        public IList<Product> OrderedProducts { get; set; }

        public double TotalAmountPayable { get; set; }

        public double TaxPercentage { get; set; }

        public IList<Status> Status { get; set; }

        public IList<string> ImageUrl { get; set; }
    }
}
