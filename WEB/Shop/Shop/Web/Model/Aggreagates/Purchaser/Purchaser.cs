using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Model.Aggreagates
{
    public class Purchaser
    {
        public string IdentityGuid { get; private set; }

        private List<PaymentCard> _paymentCard = new List<PaymentCard>();

        public IEnumerable<PaymentCard> Payments { get => _paymentCard.AsReadOnly(); }

        private Purchaser()
        {
            // required by EF
        }

        public Purchaser(string identity) : this()
        {
            IdentityGuid = identity;
        }
    }
}
