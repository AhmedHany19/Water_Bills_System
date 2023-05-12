using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Real_Estate_Type
    {
        [Key]
        [MaxLength(1)]
        [Column(TypeName = "char")]
        public string Id { get; set; }
        [MaxLength(15)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }
        [StringLength(100)]
        [Column(TypeName = "varchar")]
        public string? Comments { get; set; }

        //Navigation Properties
        public List<Subscription> Subscriptions { get; set; }
        public List<Invoice> Invoices { get; set; }


    }
}
