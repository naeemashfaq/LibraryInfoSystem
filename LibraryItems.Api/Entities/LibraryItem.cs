using System.ComponentModel.DataAnnotations;

namespace LibraryItems.Api.Entities
{
    public class LibraryItem
    {
        public int Id { get; set; }
        [Required]       
        public string Title { get; set; }
        public string? Author { get; set; }
        public int? Pages { get; set; }
        public int? RunTimeMinutes { get; set; }
        [Required]
        public bool IsBorrowable { get; set; }
        public string? Borrower { get; set; }
        public DateTime? BorrowDate { get; set; }
        [Required]
        public string Type { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
