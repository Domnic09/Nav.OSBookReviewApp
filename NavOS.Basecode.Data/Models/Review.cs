using System;
using System.Collections.Generic;

namespace NavOS.Basecode.Data.Models
{
    public partial class Review
    {
        public string ReviewId { get; set; }
        public string BookId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string ReviewText { get; set; }
        public int Rate { get; set; }

        public virtual Book Book { get; set; }
    }
}
