using System.ComponentModel.DataAnnotations;

namespace BookInventoryManager.Models
{
    public class Book
    {
        public int ID { get; set; }
        public int AuthorID { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        [DisplayFormat(NullDisplayText = "Unknown")]
        public Edition? Edition { get; set; }
    }
}
