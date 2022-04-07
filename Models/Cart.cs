namespace Shop.Models
{
    [Serializable()]
    public class Cart
    {
        private List<CartItem> cartCollection = new List<CartItem>();

        public IEnumerable<CartItem> Items { get { return cartCollection; } }
        public int totalQuantity { get; set; }


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
                    quantity = quantity,
                    img = product.img
                });
            }
            else
            {
                item.quantity += quantity;
            }
            totalQuantity = ComputeTotalQuantity();
        }

        public void RemoveItem(Product product)
        {
            cartCollection.RemoveAll(i => i.id == product.id);
            totalQuantity = ComputeTotalQuantity();
        }

        public decimal ComputeTotalValue()
        {
            return cartCollection.Sum(i => i.price * i.quantity);
        }
        public int ComputeTotalQuantity()
        {
            return cartCollection.Sum(i => i.quantity);
        }
        public void Clear()
        {
            cartCollection.Clear();
            totalQuantity = 0;
        }
    }
    public class CartItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public string img { get;set; }

        public decimal ComputeTotalPrice()
        {
            return price * quantity;
        }
    }
}
