using System.ComponentModel.DataAnnotations;

namespace LibraryItems.Api.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public float Salary { get; set; }
        [Required]
        public bool IsCEO { get; set; }
        [Required]
        public bool IsManager { get; set; }
        public int?  ManagerId { get; set; }
    }
}
