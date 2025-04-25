namespace Pharmacy.Models.Interface
{
    public interface IPharmacyItem
    {
        public List<PharmacyItem> getAllItems();
        public PharmacyItem getItemById(int index);
        public void Add(PharmacyItem item);
    }
}
