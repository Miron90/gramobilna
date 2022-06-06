using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EqService.Model
{
    [Table("EQ")]
    public partial class Eq
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("typ")]
        [StringLength(50)]
        public string Typ { get; set; }
        [Column("lvl")]
        public int Lvl { get; set; }
        [Column("hpmulti")]
        public double Hpmulti { get; set; }
        [Column("attmulti")]
        public double Attmulti { get; set; }
    }
}
