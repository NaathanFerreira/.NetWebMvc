using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;
using WebMvc.Models.ViewModels;
using WebMvc.Services;

namespace WebMvc.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService){
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index(){
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create(){
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel{ Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // previnir invasões
        public IActionResult Create(Seller seller){
            _sellerService.Insert(seller);
            return RedirectToAction("Index");
        }

        // Delete somente para abrir tela de confirmação, essa função não deleterá o Seller
        public IActionResult Delete(int? id){
            if(id == null){
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value);
            if( obj == null){
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id){
            _sellerService.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id){
            if(id == null){
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value);
            if( obj == null){
                return NotFound();
            }

            return View(obj);
        }
    }
}