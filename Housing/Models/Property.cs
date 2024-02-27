using System.ComponentModel.DataAnnotations;

namespace Housing.Models
{
    public class Property
    {
        [Key]
        public int ID {  get; set; }

        [Required]
        public string Address { get; set; }

        [Range(1, int.MaxValue)]
        public int BedroomCount { get; set; }

        [Required]
        public bool FullyDelegated { get; set; }

        [Required]
        [EmailAddress]
        public string ClientEmail { get; set; }

        [Required]
        public DateTime LeaseExpiry { get; set; }
    }
}
