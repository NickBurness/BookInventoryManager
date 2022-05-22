namespace BookInventoryManager.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}