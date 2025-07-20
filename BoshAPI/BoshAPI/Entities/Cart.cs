namespace BoshAPI.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public decimal Check { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}
