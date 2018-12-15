using System.Collections.Generic;

namespace AmCart.CustomerModule
{
    public class CustomerContext
    {
        public Customer Customer { get; set; }

        public IList<SimpleClaim> Claims { get; set; }
    }
}
