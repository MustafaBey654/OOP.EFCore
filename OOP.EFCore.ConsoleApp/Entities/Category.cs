using System.Collections;
using System.Collections.Generic;

namespace OOP.EFCore.ConsoleApp.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public string Description { get; set; }
        
        //Bire çok ilişki durumu dikkat 
        //Birden fazla kitap olabilir
        //List ile de tanımlanabilir.
        public ICollection<Book> Books { get; set; }
    }
}
