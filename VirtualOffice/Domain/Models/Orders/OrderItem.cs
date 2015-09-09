namespace Domain.Models.Orders
{
    public class OrderItem : BaseModel
    {
        public virtual InventoryItem Item { get; set; }

        public int Quantity { get; set; }
    }
}