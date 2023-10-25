using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavOS.Basecode.Services.ServiceModels
{
    public class BookViewModel
    {
        public string BookId { get; set; }
        public string BookTitle { get; set; }
        public string Summary { get; set; }
        public string Author { get; set; }
        public string Status { get; set; }
        public string Genre { get; set; }
        public int Volume { get; set; }
    }
}
