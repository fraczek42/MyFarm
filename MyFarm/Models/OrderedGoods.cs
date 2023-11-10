namespace MyFarm.Models
{
    public class OrderedGoods
    {
        private int Id { get; set; }
        private string Name { get; set; } = string.Empty;
        private int OrderedGoodsCategoryId { get; set; }
    }
}
