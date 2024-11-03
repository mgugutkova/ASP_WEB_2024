using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Infrastructure.Data.Model
{
	public class Period
	{
		[Key]
        public int Id { get; set; }

		[Required]
		public int Days { get; set; }
    }
}
