using AmCart.Core.Domain;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.OrderModule
{
    public class Order : DomainBase
    {
        public ObjectId CustomerId { get; set; }

        public Address DeliveryAddress { get; set; }

        public string PaymentType { get; set; }

        public IList<Status> StatusTrack { get; set; }

        public string TrackingNumber { get; set; }

        public IList<OrderedProduct> OrderedProducts { get; set; }

        public int TaxPercentage { get; set; }

        public double TotalAmountPayable { get; set; }
    }
}
