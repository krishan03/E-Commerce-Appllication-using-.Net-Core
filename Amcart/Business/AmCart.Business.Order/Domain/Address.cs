using Amcart.Core.Domain;

namespace AmCart.Business.Order
{
    public class Address : DomainBase
    {
        public string Name { get; set; }

        public string Mobile { get; set; }

        public string Pincode { get; set; }

        public string State { get; set; }

        public string HouseStreetNumber { get; set; }

        public string Locality { get; set; }

        public string City { get; set; }

        public string TypeOfAddress { get; set; }

        public bool IsDefault { get; set; }
    }
}
