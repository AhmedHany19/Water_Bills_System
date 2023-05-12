using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Subscriber
    {
        [Key]
        [MaxLength(10)]
        [Column(TypeName = "char")]
        public string Id { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string City { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Area { get; set; }
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string Mobile { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "varchar")]
        public string? Comments { get; set; }

        //Navigation Properties
        public List<Subscription> Subscriptions { get; set; }
        public List<Invoice> Invoices { get; set; }


    }
}
