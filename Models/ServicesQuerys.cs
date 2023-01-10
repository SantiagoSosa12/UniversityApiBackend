using System.ComponentModel.DataAnnotations;
using UniversityApiBackEnd.Models.DataModels;
namespace UniversityApiBackEnd.Models
{

    public class ServicesQuerys
    {
        /*
        Buscar usuarios por email
        Buscar alumnos mayores de edad
        Buscar alumnos que tengan al menos un curso
        Buscar cursos de un nivel determinado que al menos tengan un alumno inscrito
        Buscar cursos de un nivel determinado que sean de una categoría determinada
        Buscar cursos sin alumnos
*/
        static public void StudentsQuerys()
        {
            var courses = new[] {
                new Course() {
                    Name = "Fisica",
                    Level = Level.Basic,
                    Categories = new[] {
                        new Category {
                            Name = "Relatividad"
                        },
                        new Category {
                            Name = "Mecanica Cuantica"
                        },
                        new Category {
                            Name = "Mecanica Clasica"
                        }
                    },
                    Students = new[] {
                        new Student() {
                            Name = "Gareth"
                        },
                        new Student() {
                            Name = "Riquelme"
                        },
                        new Student() {
                            Name = "Dele - Ali"
                        }
                    }
                },
                new Course() {
                    Name = "Calculo",
                    Level = Level.Basic,
                    Categories = new[] {
                        new Category {
                            Name = "Derivadas"
                        },
                        new Category {
                            Name = "Integrales"
                        },
                        new Category {
                            Name = "Ecuaciones Diferenciales"
                        }
                    },
                    Students = new[] {
                        new Student() {
                            Name = "Busquets"
                        },
                        new Student() {
                            Name = "Quepa"
                        },
                        new Student() {
                            Name = "Rodrigo"
                        }
                    }
                },
                new Course() {
                    Name = "Telematica",
                    Level = Level.Basic,
                    Categories = new[] {
                        new Category {
                            Name = "Redes LAN"
                        },
                        new Category {
                            Name = "Redes WAN"
                        },
                        new Category {
                            Name = "Enrrutamiento"
                        }
                    },
                    Students = new[] {
                        new Student() {
                            Name = "Marianito"
                        },
                        new Student() {
                            Name = "Josema"
                        },
                        new Student() {
                            Name = "Ali"
                        }
                    }
                }
            };


            var students = new[] {
                new Student() {
                    Name = "Jose",
                    LastName = "PicaPiedra",
                    DOB = new DateTime(2015 , 5 , 8)
                },
                new Student() {
                    Name = "Maria",
                    LastName = "La Del Barrio",
                    DOB = new DateTime(2013 , 7 , 10),
                    Courses = new[] {courses[1] , courses[2]}
                },
                new Student() {
                    Name = "Super",
                    LastName = "Man",
                    DOB = new DateTime(2016 , 6 , 6),
                    Courses = new[] {courses[0] , courses[1]}
                }
            };

            var usersListLocal = new[] {
                new User() {
                    Name = "Jose",
                    LastName = "PicaPiedra",
                    EmailAddress = "JosePica@gmail.com"
                },
                new User() {
                    Name = "Mariana",
                    LastName = "Pajon",
                    EmailAddress = "pajoMari@gmail.com"
                }
            };

            string emailSearching = "email@Searching.com";

            var usersFind =
                from user
                in usersListLocal
                where user.EmailAddress.Equals(emailSearching)
                select user;



            // Estudiantes mayores de EDAD
            static int CalcularEdad(DateTime fechaNacimiento)
            {
                // Obtiene la fecha actual:
                DateTime fechaActual = DateTime.Today;

                // Comprueba que la se haya introducido una fecha válida; si 
                // la fecha de nacimiento es mayor a la fecha actual se muestra mensaje 
                // de advertencia:
                if (fechaNacimiento > fechaActual)
                {
                    Console.WriteLine("La fecha de nacimiento es mayor que la actual.");
                    return -1;
                }
                else
                {
                    int edad = fechaActual.Year - fechaNacimiento.Year;

                    // Comprueba que el mes de la fecha de nacimiento es mayor 
                    // que el mes de la fecha actual:
                    if (fechaNacimiento.Month > fechaActual.Month)
                    {
                        --edad;
                    }

                    return edad;
                }
            }
            //Alumnos mayores de edad
            var mayores =
                from student
                in students
                where CalcularEdad(student.DOB) >= 18
                select student;
            //Alumnos con al menos un curso
            var conAlMenosUnCurso =
                from student
                in students
                where student.Courses.Count() > 0
                select student;
            // cursos de un nivel determinado que al menos tengan un alumno inscrito
            var conAlMenosUnAlumno =
                from course
                in courses
                where course.Level == Level.Basic
                where course.Students.Count() > 0
                select course;

            // Buscar cursos de un nivel determinado que sean de una categoría determinada
            var CategoryList = courses.Any(
                course =>
                    course.Categories.Any(
                        Category => Category.Name == "Relatividad"
                    )
                );
            // Cursos Sin alumnos
            var cursosSinAlumnos =
                from course
                in courses
                where course.Students.Count() == 0
                select course;
        }


    }

}
