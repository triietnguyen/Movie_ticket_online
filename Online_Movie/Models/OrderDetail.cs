using System;
using System.Collections.Generic;

namespace Online_Movie.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int? MovieId { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public int? OrderMovieId { get; set; }

    public virtual Movie? Movie { get; set; }

    public virtual OrderMovie? OrderMovie { get; set; }
}
