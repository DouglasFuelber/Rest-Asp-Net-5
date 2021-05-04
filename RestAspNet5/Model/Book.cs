using RestAspNet5.Model.Base;
using System;

namespace RestAspNet5.Model
{
    public class Book : BaseEntity
    {
        public string Author { get; set; }
        public DateTime LaunchDate { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
    }
}
