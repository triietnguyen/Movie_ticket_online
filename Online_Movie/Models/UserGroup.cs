using System;
using System.Collections.Generic;

namespace Online_Movie.Models;

public partial class UserGroup
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
