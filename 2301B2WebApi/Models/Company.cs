using System.ComponentModel.DataAnnotations;

namespace _2301B2WebApi.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    
    }
}
