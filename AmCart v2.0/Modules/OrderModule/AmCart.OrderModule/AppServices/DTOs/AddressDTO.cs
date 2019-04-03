using AmCart.Core.AppServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.OrderModule.AppServices.DTOs
{
    public class AddressDTO : DtoBase
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
