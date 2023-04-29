using System.ComponentModel.DataAnnotations;

namespace AngularAuthAPI.Models
{
    public class Base
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool InActive { get; set; }
    }
}
