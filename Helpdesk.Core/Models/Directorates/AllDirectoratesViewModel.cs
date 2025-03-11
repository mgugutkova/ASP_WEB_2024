using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Helpdesk.Infrastructure.Constants.DataConstants;


namespace Helpdesk.Core.Models.Directorates
{
    public class AllDirectoratesViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]      
        [StringLength(DirectorateNameMaxLength, MinimumLength = DirectorateNameMinLength, ErrorMessage = ErrorMessageLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
