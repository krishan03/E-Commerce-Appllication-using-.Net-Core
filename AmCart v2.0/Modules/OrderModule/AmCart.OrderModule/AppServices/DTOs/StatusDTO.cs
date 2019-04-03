using AmCart.Core.AppServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.OrderModule.AppServices.DTOs
{
    public class StatusDTO : DtoBase
    {
        public DateTime ChangeDate { get; set; }

        public string StatusType { get; set; }
    }
}
