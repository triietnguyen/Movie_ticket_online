using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Online_Movie.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Online_MovieUser class
public class Online_MovieUser : IdentityUser
{
	[PersonalData]
	[Column(TypeName = "varchar(50)")]
	public string? FirstName { get; set; }
	[PersonalData]
	[Column(TypeName = "varchar(50)")]
	public string? LastName { get; set; }
	[PersonalData]
	[Column(TypeName = "varchar(50)")]
	public string? Address { get; set; }
}

