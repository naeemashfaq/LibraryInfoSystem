using System.ComponentModel.DataAnnotations;

namespace LibraryItems.Api.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }

        //public ICollection<LibraryItem> LibraryItem { get; set; }

    }
}
