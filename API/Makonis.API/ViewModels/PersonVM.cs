using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Makonis.API.ViewModels
{
    public class PersonVM
    {
        public Guid PersonId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name length should not be more than 50")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name length should not be more than 50")]
        public string LastName { get; set; }
    }
}
