using Amcart.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.Business.Order
{
    public class Status : DomainBase
    {
        public DateTime ChangeDate { get; set; }

        public string StatusType { get; set; }
    }
}
