using Helpdesk.Core.Models.Categoris;
using Helpdesk.Infrastructure.Data.Model;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Display(Name = "* Описание на проблема:")]
        public string Description { get; set; } = string.Empty!;


        [Required]
        [Display(Name = "* Категория:")]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public IEnumerable<AllCategoriesViewModel> CategoryList { get; set; } = new List<AllCategoriesViewModel>();

        [Required]
        [Display(Name = "Подадена:")]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Приключена:")]
        public DateTime? EndDate { get; set; }

        [Required]
        [Display(Name = "* Статус:")]
        public int RequestStateId { get; set; } = 1;

        [Display(Name = "Статус:")]
        public string RequestState { get; set; } = string.Empty;
       

        public Guid? OperatorId { get; set; }

        [Display(Name = "Разпределена:")]
        public string? OperatorName { get; set; } = string.Empty;
        //public Operator? Operator { get; set; } = null;

        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength, ErrorMessage = ErrorMessageLength)]
        [Display(Name = "Заключение/коментар:")]
        public string? Comment { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; } = true;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string DirectorateName { get; set; } = null!;
        public string? Position { get; set; } = null;
    }
}


















