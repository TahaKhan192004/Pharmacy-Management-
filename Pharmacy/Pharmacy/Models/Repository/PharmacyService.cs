using Microsoft.AspNetCore.Http;
using Pharmacy.Models.Interface;
using Pharmacy.Models;
using System.Text.Json;

public class PharmacyService : IPharmacyItem
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PharmacyService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private ISession Session => _httpContextAccessor.HttpContext?.Session;

    public List<PharmacyItem> getAllItems()
    {
        string list = Session?.GetString("mydata");
        if (string.IsNullOrEmpty(list))
        {
            return new List<PharmacyItem>();
        }

        List<PharmacyItem> listOfItems = JsonSerializer.Deserialize<List<PharmacyItem>>(list);
        return listOfItems; 
    }

    public PharmacyItem getItemById(int id)
    {
        string list = Session?.GetString("mydata");
        if (string.IsNullOrEmpty(list))
        {
            return null; 
        }

        List<PharmacyItem> listOfItems = JsonSerializer.Deserialize<List<PharmacyItem>>(list);

      
        bool stat = true;
        int i = 0;
        while (stat)
        {
            if (listOfItems[i].Id == id)
            {
                stat = false; 
            }
            else
            {
                i++;
            }
        }
        return listOfItems[i]; 
    }

    public void Add(PharmacyItem item)
    {
        List<PharmacyItem> list;
        string existingList = null;

      
        if (Session.Keys.Contains("mydata"))
        {
            existingList = Session.GetString("mydata");
            list = JsonSerializer.Deserialize<List<PharmacyItem>>(existingList);
        }
        else
        {
            list = new List<PharmacyItem>();
        }

       
        list.Add(item);
        string json = JsonSerializer.Serialize(list);
        Session.SetString("mydata", json);
    }
}
