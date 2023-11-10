namespace MyFarm.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderingPersonId { get; set; }
        public int Quantity { get; set; }
        public int QuantityPerPackage { get; set; }
        public int OrderedGoodsId { get; set; }
        public decimal AmountPerQuantity { get; set; }
        public DateTime DateOrder { get; set; }
        public int Status { get; set; }
    }
}
