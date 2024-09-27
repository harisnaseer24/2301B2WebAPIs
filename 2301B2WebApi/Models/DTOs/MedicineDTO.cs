namespace _2301B2WebApi.Models.DTOs
{
    public class MedicineDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public int Price { get; set; }
        public string Formula { get; set; }
        public string Power { get; set; }
        public DateTime Expiry { get; set; }
    }
}
