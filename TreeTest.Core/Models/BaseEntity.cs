using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeTest.Core.Interfaces.Repository;

namespace TreeTest.Core.Models
{
    public class BaseEntity
    {
        [Key]
        [Required]
        public virtual string Id { get; set; }
    }
}
