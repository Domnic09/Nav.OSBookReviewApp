using System;
using System.Collections.Generic;

namespace NavOS.Basecode.Data.Models
{
    public partial class Book
    {
        public Book()
        {
            Reviews = new HashSet<Review>();
        }

        public string BookId { get; set; }
        public string BookTitle { get; set; }
        public string Summary { get; set; }
        public string Author { get; set; }
        public string Status { get; set; }
        public string Genre { get; set; }
        public string Volume { get; set; }
        public DateTime Date { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedTime { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
