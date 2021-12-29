using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuthorApi.Model
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MaxLength (15)]
        public  string FirstName { get; set; }
        
        [Required, MaxLength (15)] 
        public string LastName { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();



    }
}