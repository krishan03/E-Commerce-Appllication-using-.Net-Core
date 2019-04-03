using AmCart.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.OrderModule.Domain
{
    public class Address: DomainBase
    {
        public string CompanyName { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }

        public string Pincode { get; set; }

        public string State { get; set; }

        public string HouseStreetNumber { get; set; }

        public string Locality { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string TypeOfAddress { get; set; }

        public bool IsDefault { get; set; }
    }
}
