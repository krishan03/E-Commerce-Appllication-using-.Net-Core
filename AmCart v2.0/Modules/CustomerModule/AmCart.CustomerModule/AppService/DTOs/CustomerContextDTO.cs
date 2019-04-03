using AmCart.Core.AppServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.CustomerModule.AppService.DTOs
{
    public class CustomerContextDTO:DtoBase
    {
        public CustomerDTO Customer { get; set; }

        public IList<SimpleClaim> Claims { get; set; }
    }
}
