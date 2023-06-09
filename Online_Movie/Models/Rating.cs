using System;
using System.Collections.Generic;

namespace Online_Movie.Models;

public partial class Rating
{
    public int Id { get; set; }

    public double? Rating1 { get; set; }

    public int? MovieId { get; set; }

    public virtual Movie? Movie { get; set; }
}
