using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Repositories.Models
{
    public class FavouriteDirector
    {
        public int UserId { get; set; }
        public int DirectorId { get; set; }
    }
}
