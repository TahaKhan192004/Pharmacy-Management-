using Microsoft.AspNetCore.Mvc;
using Pharmacy.Models;
using Pharmacy.Models.Interface;
using System.Collections.Generic;
using System.Text.Json;

namespace Pharmacy.Controllers
{
    public class PharmacyController : Controller
    {
        private readonly IPharmacyItem _iPi;
        public PharmacyController(IPharmacyItem _ip)
        {
            this._iPi = _ip;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<PharmacyItem> list = _iPi.getAllItems();
            return View(list);
        }
        [HttpPost]
        public IActionResult Index(string search)
        {
            List<PharmacyItem> items = _iPi.getAllItems();
            List<PharmacyItem> result = new List<PharmacyItem>();
            if (string.IsNullOrEmpty(search))
                return View(items);
            foreach (var i in items)
            {
                if (i.Name.Contains(search, StringComparison.OrdinalIgnoreCase) || i.Category.Contains(search, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(i);
                }
            }
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(int id,string name,string description,string category,int price,int quantity,string image)
        {
            PharmacyItem item = new PharmacyItem { Id =id,
                Name =name,
                Description =description,
                Category =category,
                price = price,
                quantity = quantity,    
                image = image
            };
            _iPi.Add(item);

            return View();
        }
        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Details(int id)
        {
            PharmacyItem item=_iPi.getItemById(id);
            ViewBag.x = item;
            return View();
        }
    }
}
