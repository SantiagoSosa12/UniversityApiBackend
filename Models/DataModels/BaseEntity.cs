using System.ComponentModel.DataAnnotations;

/*
Replica el proyecto completo .Net 6 visto en el vídeo

Asegúrate de crear correctamente el diagrama del modelo de EntityFramework

Asegúrate de crear las migraciones y actualizar la base de datos

Establece relaciones entre:

Usuarios y BaseEntit

Actualiza la base de datos

Crea los controllers necesarios para cada modelo

Realiza pruebas desde Swagger para todas las peticiones CRUD de cada controller y asegúrate de su buen funcionamiento.
*/
namespace UniversityApiBackEnd.Models.DataModels {

    public class BaseEntity {

        [Required]
        [Key]
        public int Id { get; set; }
        public string createdBy { get; set; } = string.Empty;
        public DateTime createAt { get; set; } = DateTime.Now;
        public string updateddBy { get; set; } = string.Empty;
        public DateTime? updatedAt { get; set; }
        public string deleteBy { get; set; } = string.Empty;
        public DateTime? deleteAt { get; set; }
        public bool IsDeleted {get; set;} = false;
    }

}