using System;
using System.ComponentModel.DataAnnotations;

namespace OliveApp.Legacy.Models
{
    // Legacy domain model - mirrors the Customers table on the pre-migration
    // SQL Server database (see Data/OliveLegacyDbContext.cs).
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
