namespace Shop.Models
{
    [Serializable()]
    public class Cart
    {
        private List<CartItem> cartCollection = new List<CartItem>();

        public IEnumerable<CartItem> Items { get { return cartCollection; } }

        public void AddItem(Product product, int quantity)
        {

            CartItem item = cartCollection
                .Where(p => p.Product.id == product.id)
                .FirstOrDefault();
            
            if (item == null)
            {
                cartCollection.Add(new CartItem { Product = product, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void RemoveItem(Product product)
        {
            cartCollection.RemoveAll(i => i.Product.id == product.id);
        }

        public decimal ComputeTotalValue()
        {
            return cartCollection.Sum(i => i.Product.price * i.Quantity);
        }
        public void Clear()
        {
            cartCollection.Clear();
        }
    }
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
