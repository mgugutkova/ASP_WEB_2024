﻿using System.ComponentModel.DataAnnotations;
using static PawnShop.Infrastructure.Data.DataConstants;

namespace PawnShop.Core.Models.AgreementState
{
    public class AgreementStateViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(StateNameMaxLength)]
        public string Name { get; set; } = string.Empty;
    }
}