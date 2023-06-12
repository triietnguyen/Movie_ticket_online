using System;
using System.Collections.Generic;

namespace Online_Movie.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public int? CategoryId { get; set; }

    public string? MovieName { get; set; }

    public string? Duration { get; set; }

    public int? Likes { get; set; }

    public string? Actors { get; set; }

    public string? Image { get; set; }

    public decimal? Price { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
}
