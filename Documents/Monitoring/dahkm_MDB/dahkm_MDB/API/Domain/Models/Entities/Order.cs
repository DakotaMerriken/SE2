using System;

namespace dahkm_MDB.API.Domain.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RecieveDate { get; set; }
        public double AmountDue { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public double ShippingCost { get; set; }
    }
}