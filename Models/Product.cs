namespace Shop.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortDesc { get; set; }
        public string longDesc { get; set; }
        public string img { get; set; }
        public uint price { get; set; }
        public bool isFavourite { get; set; }
        public bool available { get; set; }
        public int categoryId   { get; set; }
        public virtual Category Category { get; set; }
    }
}
