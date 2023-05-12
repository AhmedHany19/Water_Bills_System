using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Default_Slice_Value
    {

        [Key]
        [MaxLength(1)]
        [Column(TypeName = "char")]
        public string Id { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "char")]
        public string Name { get; set; }
        public int Condition { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Water_Price { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Sanitation_Price { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "char")]
        public string? Comments { get; set; }



    }
}
