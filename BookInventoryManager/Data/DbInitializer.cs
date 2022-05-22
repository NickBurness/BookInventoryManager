using BookInventoryManager.Models;

namespace BookInventoryManager.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BookManagerContext context)
        {
            #region category seed
            // Look for any categories.
            if (!context.Categories.Any())
            {
                var categories = new Category[]
                {
                    new Category()
                    {
                        Name = "Nonfiction",

                    },
                    new Category()
                    {
                        Name = "Fiction"
                    }
                };
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }
            #endregion

            #region author seed
            // Look for any authors.
            if (!context.Authors.Any())
            {
                var authors = new Author[]
                {
                    new Author
                    {
                        FirstName = "George",
                        Surname = "Orwell"
                    },
                    new Author
                    {
                        FirstName = "Harper",
                        Surname = "Lee"
                    },
                    new Author
                    {
                        FirstName = "Bram",
                        Surname = "Stoker"
                    },
                    new Author
                    {
                        FirstName = "Herman",
                        Surname = "Melville"
                    },
                    new Author
                    {
                        FirstName = "Joseph",
                        Surname = "Heller"
                    },
                    new Author
                    {
                        FirstName = "Jon",
                        Surname = "Skeet"
                    },
                };

                context.Authors.AddRange(authors);
                context.SaveChanges();
            }
            #endregion

            #region book seed
            // Look for any books.
            if (!context.Books.Any())
            {
                var books = new Book[]
                {
                    new Book
                    {
                        Title = "1984",
                        AuthorID = 1,
                        CategoryID = 2,
                        Description = "1984 is a dystopian novella by George Orwell published in 1949, which follows the life of Winston Smith, a low ranking member of 'the Party', who is frustrated by the omnipresent eyes of the party, and its ominous ruler Big Brother. 'Big Brother' controls every aspect of people's lives.",
                        Edition = 0,
                        Quantity = 5
                    },
                    new Book
                    {
                        Title = "To kill a mockingbird",
                        AuthorID = 2,
                        CategoryID = 2,
                        Description= "To Kill a Mockingbird is both a young girl's coming-of-age story and a darker drama about the roots and consequences of racism and prejudice, probing how good and evil can coexist within a single community or individual.",
                        Edition = Edition.Other,
                        Quantity = 5
                    },
                    new Book
                    {
                        Title = "Animal Farm",
                        AuthorID = 1,
                        CategoryID = 2,
                        Description = "Animal Farm is a satirical allegorical novella by George Orwell, first published in England on 17 August 1945. The book tells the story of a group of farm animals who rebel against their human farmer, hoping to create a society where the animals can be equal, free, and happy.",
                        Edition = Edition.Other,
                        Quantity = 5
                    },
                    new Book
                    {
                        Title = "Dracula",
                        AuthorID = 3,
                        CategoryID = 2,
                        Description = "Dracula comprises journal entries, letters, and telegrams written by the main characters. It begins with Jonathan Harker, a young English lawyer, as he travels to Transylvania. Harker plans to meet with Count Dracula, a client of his firm, in order to finalize a property transaction.",
                        Edition = Edition.Other,
                        Quantity = 5
                    },
                    new Book
                    {
                        Title = "Moby Dick",
                        AuthorID = 4,
                        CategoryID = 2,
                        Description = "Moby-Dick; or, The Whale is an 1851 novel by American writer Herman Melville. The book is the sailor Ishmael's narrative of the obsessive quest of Ahab, captain of the whaling ship Pequod, for revenge on Moby Dick, the giant white sperm whale that on the ship's previous voyage bit off Ahab's leg at the knee.",
                        Edition = Edition.Other,
                        Quantity = 5
                    },
                    new Book
                    {
                        Title = "Catch-22",
                        AuthorID = 5,
                        CategoryID = 2,
                        Description = "Catch-22, satirical novel by American writer Joseph Heller, published in 1961. The work centres on Captain John Yossarian, an American bombardier stationed on a Mediterranean island during World War II, and chronicles his desperate attempts to stay alive.",
                        Edition = Edition.Second,
                        Quantity = 5
                    },
                    new Book
                    {
                        Title = "C# in Depth",
                        AuthorID = 6,
                        CategoryID = 1,
                        Description = "C# in Depth is a book for those who are passionate about C#. It aims to be a bridge between the existing introductory books and the language specification.",
                        Edition = Edition.First,
                        Quantity = 5
                    }
                };

                context.Books.AddRange(books);
                context.SaveChanges();
            }
            #endregion
        }
    }
}