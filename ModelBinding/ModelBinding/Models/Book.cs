using Microsoft.AspNetCore.Mvc;

namespace ModelBinding.Models
{
    public class Book
    {
        //[FromQuery] // can be added to take data from query
        public int? BookId { get; set; }
        public string? Author { get; set; }

        public override string ToString()
        {
            return $"Book object - Book id: {BookId}, Author: {Author}";
        }
    }
}
