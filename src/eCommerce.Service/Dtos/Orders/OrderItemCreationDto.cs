using eCommerce.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Dtos.Orders
{
    internal class OrderItemCreationDto
    {
        public Order Order { get; set; }
        public long ProductId { get; set; }
        public long ProductCount { get; set; }
        public decimal TotalMoneyToBePaid { get; set; }
    }
}
