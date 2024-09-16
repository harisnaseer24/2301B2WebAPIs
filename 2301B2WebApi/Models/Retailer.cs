using System.ComponentModel.DataAnnotations;

namespace _2301B2WebApi.Models
{
    public class Retailer
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

    }
}
