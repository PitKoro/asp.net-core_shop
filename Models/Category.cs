﻿namespace Shop.Models
{
    public class Category
    {
        public int id { get; set; }
        public string categoryName { get; set; }
        public string desc { get; set; }
        public List<Product> products { get; set; }
    }
}
