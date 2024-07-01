
namespace TaskManagementProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Task
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed {1} characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [StringLength(50, ErrorMessage = "Status must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string Status { get; set; }

        [Required(ErrorMessage = "Project ID is required.")]
        public int ProjectFid { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public int UserFid { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
    }
}
