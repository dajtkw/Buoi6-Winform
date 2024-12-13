using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WindowsFormsApp13.Model
{
    public partial class StudentDBcontext : DbContext
    {
        public StudentDBcontext()
            : base("name=StudentDBcontext")
        {
        }

        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
