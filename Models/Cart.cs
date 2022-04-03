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
                .Where(p => p.id == product.id)
                .FirstOrDefault();
            
            if (item == null)
            {
                cartCollection.Add(new CartItem {
                    id = product.id,
                    name = product.name,
                    price = product.price,
                    quantity = quantity
                });
            }
            else
            {
                item.quantity += quantity;
            }
        }

        public void RemoveItem(Product product)
        {
            cartCollection.RemoveAll(i => i.id == product.id);
        }

        public decimal ComputeTotalValue()
        {
            return cartCollection.Sum(i => i.price * i.quantity);
        }
        public void Clear()
        {
            cartCollection.Clear();
        }
    }
    public class CartItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
    }
}
