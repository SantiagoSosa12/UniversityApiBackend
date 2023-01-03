using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityApiBackEnd.Models.DataModels;

    public class UniversityDBContext : DbContext
    {
        public UniversityDBContext (DbContextOptions<UniversityDBContext> options)
            : base(options)
        {
        }

        public DbSet<UniversityApiBackEnd.Models.DataModels.Chapters> Chapters { get; set; } = default!;
    }
