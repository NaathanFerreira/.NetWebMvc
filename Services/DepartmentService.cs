using WebMvc.Models;
using System.Linq;
using System.Collections.Generic;

namespace WebMvc.Services
{
    public class DepartmentService
    {
        private readonly WebMvcContext _context;

        public DepartmentService(WebMvcContext context){
            _context = context;
        }

        public List<Department> FindAll(){
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}