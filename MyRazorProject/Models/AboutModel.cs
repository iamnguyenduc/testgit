using System;
using System.ComponentModel.DataAnnotations;

namespace MyRazorProject.Models
{
    public class AboutModel
    {
        [Key] // Marking this as the primary key
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Use Name as the primary key (or another property)

        public string Nickname { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        public string Phone { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }

        public string Location { get; set; } = string.Empty;

        public string Text1 { get; set; } = string.Empty;
        public string Text2 { get; set; } = string.Empty;
    }
}
