using System;
using System.Collections.Generic;

namespace Online_Movie.Models;

public partial class OrderMovie
{
    public int OrderMovieId { get; set; }

    public int? UserId { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual User? User { get; set; }
}
