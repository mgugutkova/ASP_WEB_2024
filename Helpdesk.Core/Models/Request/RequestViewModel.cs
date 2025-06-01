using Helpdesk.Core.Models.ApplicationUser;
using Helpdesk.Core.Models.Categoris;
using Helpdesk.Core.Models.RequestHistory;
using Helpdesk.Core.Models.RequestState;
using System.ComponentModel.DataAnnotations;
using static Helpdesk.Infrastructure.Constants.DataConstants;

namespace Helpdesk.Core.Models.Request
{
    public class RequestViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty; 

        public string UserFullName { get; set; } = string.Empty;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = ErrorMessageLength)]
        [Display(Name = "* Описание на проблема")]
        public string Description { get; set; } = string.Empty!;


        [Required]
        [Display(Name = "* Категория")]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public IEnumerable<AllCategoriesViewModel> CategoryList { get; set; } = new List<AllCategoriesViewModel>();
        public IEnumerable<RequestServiceViewModel> StateList { get; set; } = new List<RequestServiceViewModel>();
        public IEnumerable<ITAdminViewModel> AdminList { get; set; } = new HashSet<ITAdminViewModel>();
        public IEnumerable<RequestHistoryViewModel> HistoryList { get; set; } = new HashSet<RequestHistoryViewModel>();

        [Required]
        [Display(Name = "Подадена")]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Приключена")]
        public DateTime? EndDate { get; set; }

        [Required]
        [Display(Name = "* Статус")]
        public int RequestStateId { get; set; } = 1;

        [Display(Name = "Статус")]
        public string RequestState { get; set; } = string.Empty;

        [Display(Name = "Оператор")]
        public string? OperatorId { get; set; }

        [Display(Name = "Разпределена")]
        public string? OperatorName { get; set; } = string.Empty;

        [Display(Name = "Мениджър")]
        public string? ManagerId { get; set; }

        [Display(Name = "Приключена")]
        public string? ManagerName { get; set; } = string.Empty;
       
        [Display(Name = "Заключение/коментар")]
        public string? Comment { get; set; } = string.Empty;

        [Display(Name = "Удовлетвореност")]
        public string? Satisfaction { get; set; } = null;

        [Required]
        public bool IsActive { get; set; } = true;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string DirectorateName { get; set; } = string.Empty;
        public string? Position { get; set; } = string.Empty;
    }
}


















