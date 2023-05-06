using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageCurdDemo.Data;
using RazorPageCurdDemo.Models;

namespace RazorPageCurdDemo.Pages.EMP
{
    public class ListModel : PageModel
    {
        private readonly ApplicationDBContext _applicationDBContext;

        [BindProperty]
        public List<EmpModel> EmpList { get; set; }

        public ListModel(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public void OnGet()
        {
           EmpList = _applicationDBContext.EmpDetails.ToList();
        }
    }
}
