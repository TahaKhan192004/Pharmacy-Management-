namespace Pharmacy.Models
{
    public class PharmacyItem
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        public string Category {  get; set; }
        public int price {  get; set; }
        public int quantity {  get; set; }
        public string image {  get; set; }
    }
}
