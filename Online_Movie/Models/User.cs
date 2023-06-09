using System;
using System.Collections.Generic;

namespace Online_Movie.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public int? GroupId { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual UserGroup? Group { get; set; }

    public virtual ICollection<OrderMovie> OrderMovies { get; set; } = new List<OrderMovie>();
}
