using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RatingDemoTest.Domain
{
    public class ServicesRating
    {
        [Key]
        public int RatingId { get; set; }
        public int RatedServiceId { get; set; }
        public int RatedServicePoint { get; set; }
        public string RatedServiceComment { get; set; }
    }
}
