using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_DotNetCore.Models
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Candidate { get; set; }
        [Required]
        public DateTime Datetime { get; set; }

    }
}
