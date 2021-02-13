using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ForumTest2.Models
{
    public class ApplicationUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public int Active { get; set; } = 1;
        public string Profile { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}