using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Helpdesk.Infrastructure.Constants.DataConstants;

namespace Helpdesk.Infrastructure.Data.Model
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(FirstNameMaxLength)]
        [PersonalData]
        public string FirstName { get; set; } = string.Empty;


        [Required]
        [MaxLength(LastNameMaxLength)]
        [PersonalData]
        public string LastName { get; set; } = string.Empty;


        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = string.Empty;


        [Required]
        [DefaultValue("User")]
        public string RoleName { get; set; } = string.Empty;


        [Required]
        public int DirectoratesUnitId { get; set; }

        [Required]
        [ForeignKey(nameof(DirectoratesUnitId))]
        public DirectoratesUnit DirectoratesUnit { get; set; } = null!;


        [MaxLength(PositionMaxLength)]
        public string? Position { get; set; } = null;

        [Required]
        public bool IsActive { get; set; } = true;

      //  public virtual ICollection<Request> Requests { get; set; } = new HashSet<Request>();  // maybe not need
    }
}
