using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Data
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Synopsis { get; set; }
        public int YearPublished { get; set; }
        public List<BookMedium> AvailableMedia { get; } = new List<BookMedium>();

        public Book()
        {

        }

        public Book(int id, string title, string author, string synopsis, int yearPublished)
        {
            Id = id;
            Title = title;
            Author = author;
            Synopsis = synopsis;
            YearPublished = yearPublished;
        }
    }
}