using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;
using WebMvc.Services;

namespace WebMvc.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService){
            _sellerService = sellerService;
        }

        public IActionResult Index(){
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // previnir invasões
        public IActionResult Create(Seller seller){
            _sellerService.Insert(seller);
            return RedirectToAction("Index");
        }
    }
}