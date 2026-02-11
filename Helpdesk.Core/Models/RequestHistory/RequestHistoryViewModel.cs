using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Core.Models.RequestHistory
{
    public class RequestHistoryViewModel
    {
        public int id { get; set; }
      
        public Guid RequestId { get; set; }

        public int RequestNumber { get; set; }

        public int RequestStateId { get; set; }

        public string RequestState { get; set; } = string.Empty;

        public DateTime ChangeDate { get; set; } 
      
        public string ChangedById { get; set; } = string.Empty;

        public string ChangedByUser { get; set; } = string.Empty;    

    }
}
