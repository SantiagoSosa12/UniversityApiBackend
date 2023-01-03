using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackEnd.Models.DataModels {

    public class Student: BaseEntity {

        [Required, StringLength(50)]
        public string Name { get; set;} = string.Empty;
        [Required, StringLength(50)]
        public string LastName { get; set;} = string.Empty;
        [Required]
        public DateTime DOB { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();

    }

}