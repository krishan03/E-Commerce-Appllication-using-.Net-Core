using AmCart.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.OrderModule.Domain
{
    public class Status : DomainBase
    {
        public DateTime ChangeDate { get; set; }

        public string StatusType { get; set; }
    }
}
