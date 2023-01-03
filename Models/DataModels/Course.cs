using System.ComponentModel.DataAnnotations;

using UniversityApiBackEnd.Models.DataModels;

namespace UniversityApiBackEnd.Models.DataModels {

    public enum Level {Basic , Medium, Advanced, Expert};

    public class Course: BaseEntity {

        [Required, StringLength(50)]
        public string Name { get; set;} = string.Empty;
        [Required, StringLength(280)]
        public string SorthDescription { get; set;} = string.Empty;
        [Required]
        public string Description { get; set;} = string.Empty;
        [Required]
        public Level Level {get; set; } = Level.Basic;

        [Required]
        public ICollection<Category> Categories {get; set;} = new List<Category>();
        [Required]
        public ICollection<Student> Students { get; set; } = new List<Student>();
        [Required]
        public Chapters index { get; set; } = new Chapters();

    }

}