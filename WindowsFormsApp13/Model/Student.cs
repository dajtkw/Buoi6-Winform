namespace WindowsFormsApp13.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string StudentID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Faculty { get; set; }

        public double Score { get; set; }
    }
}
