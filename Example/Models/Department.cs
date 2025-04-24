using System.ComponentModel.DataAnnotations;

namespace Example.Models
{
    public class Department
    {
        public int Id { get;set; }
        [Display(Name="Department Name.")]
        [Required(ErrorMessage="Fill the name ya basha")]
        [MaxLength(25)]
        [MinLength(4)]
        [UniqueName]
        public string Name { get; set; }
        [Required]
        [MaxLength(25)]
        [MinLength(4)]
        public string ManagerName { get; set; }

    }
}
