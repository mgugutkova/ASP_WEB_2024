using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Infrastructure.Data.Model
{
    public class RequestHistory
    {
        [Key]
        public int id { get; set; }

        [Required]
        public Guid RequestId { get; set; }

        [ForeignKey(nameof(RequestId))]
        public Request Request { get; set; } = null!;

        [Required]
        public int RequestStateId { get; set; }

        [ForeignKey(nameof(RequestStateId))]
        public RequestState RequestState { get; set; } = null!;

        [Required]
        public DateTime ChangeDate { get; set; } = DateTime.UtcNow;

        [Required]
        public string ChangedById { get; set; } = string.Empty;

        [ForeignKey(nameof(ChangedById))]
        public ApplicationUser ChangedByUser { get; set; } = null!;
    }
}
