using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcDzien3Configs.Models
{
    public class CustomerModel
    {
		public int Id { get; set; }

		[Required]
	    public string Firstname { get; set; }

		[Required]
	    public string LastName { get; set; }

	    public int Age { get; set; }

	    public DateTime DateAdded { get; set; }

	    public DateTime? DateUpdated { get; set; }

	    public AddressModel Address { get; set; }

	    public ICollection<ConsultationModel> Consultations { get; set; }
	}
}
