using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcDzien3Configs.Models
{
    public class ConsultationModel
    {
	    public int Id { get; set; }

		[Required]
	    public string Subject { get; set; }

	    public string Description { get; set; }

		public int CustomerId { get; set; }

		[ForeignKey("CustomerId")]
		public CustomerModel Customer { get; set; }
    }
}
