using System.Collections.Generic;

namespace WebUI.Data
{
    public class BookMedium
    {
        public int BookId { get; set; }
        public int MediumId { get; set; }

        public Book Book { get; set; } = new Book();
        public Medium Medium { get; set; } = new Medium();
    }
}