using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Core.Models.Interest
{
    public class AllInterestViewModel
    {
        public int Id { get; set; }
        public int AgreementId { get; set; }
       
        public decimal ValueInterest { get; set; }

        public DateTime DateInterest { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EndDateChanged { get; set; }

        public string UserId { get; set; } = string.Empty;
        public string UserFirstName { get; set; } = string.Empty;
        public string UserLastName { get; set; } = string.Empty;

        public string GoodName { get; set; } = string.Empty;
    }
}
