using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RatingDemoTest.Domain
{
    public class LoginServices
    {
        [Key]
        public int LoginId { get; set; }
        public int LoginServiceId { get; set; }
        public string LoginServicePassCode { get; set; }
        public bool IsStillLogin { get; set; }
    }
}
