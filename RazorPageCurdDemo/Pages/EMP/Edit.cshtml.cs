using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageCurdDemo.Data;
using RazorPageCurdDemo.Models;
using RazorPageCurdDemo.Models.ViewModels;

namespace RazorPageCurdDemo.Pages.EMP
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDBContext _applicationDBContext;

        [BindProperty]
        public EmpEditViewModel empViewModel { get; set; }

        public EditModel(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public void OnGet( Guid id)
        {
            var empDetail = _applicationDBContext.EmpDetails.Find(id);

            if (empDetail != null) 
            {
                empViewModel = new EmpEditViewModel()
                {
                    Id= empDetail.Id,
                    Name= empDetail.Name,
                    Email= empDetail.Email,
                    Salary= empDetail.Salary,
                    DateOfBirth= empDetail.DateOfBirth,
                    Department= empDetail.Department
                };
            }
        }

        public void OnPostUpdate()
        {
            if(empViewModel != null)
            {
                var searchDetail = _applicationDBContext.EmpDetails.Find(empViewModel.Id);

                if (searchDetail != null)
                {

                   searchDetail.Name = empViewModel.Name;
                   searchDetail.Email = empViewModel.Email;
                   searchDetail.Salary = empViewModel.Salary;
                   searchDetail.DateOfBirth = empViewModel.DateOfBirth;
                   searchDetail.Department = empViewModel.Department;

                   _applicationDBContext.SaveChanges();

                    ViewData["Message"] = "Data Updated";
                }
            }
            
        }

        public IActionResult OnPostDelete()
        {
            var searchDetail = _applicationDBContext.EmpDetails.Find(empViewModel.Id);
            if (searchDetail != null)
            {
                _applicationDBContext.EmpDetails.Remove(searchDetail);
                _applicationDBContext.SaveChanges();

                return RedirectToPage("/EMP/List");
            }

            return Page();
        }
    }
}
