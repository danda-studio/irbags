using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Irabags.Core.Order
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public PaymentType PaymentType { get; set; }
        public PersonName Name { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
        public Phone Phone { get; set; }
        public Email Email { get; set; }
    }
}
