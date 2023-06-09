using System;
using System.Collections.Generic;

namespace Online_Movie.Models;

public partial class Showtime
{
    public int Id { get; set; }

    public int? MovieId { get; set; }

    public DateTime? Date { get; set; }

    public string? Location { get; set; }

    public virtual Movie? Movie { get; set; }
}
