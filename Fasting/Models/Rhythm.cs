using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fasting.Models
{
    public class Rhythm
    {
        public int Id { get; set; }
        [Required]
        public int Ratio { get; set; }
        [Required]
        [DisplayName("Start Time")]
        public DateTime StartTime { get; set; }
        [Required]
        [DisplayName("End Time")]
        public DateTime EndTime { get; set; }
        public bool Achieved { get; set; }
        [Range(1, 30, ErrorMessage = "Value must be between 1 and 30")]
        public int Days { get; set; }
    }
}
