using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageCurdDemo.Data;
using RazorPageCurdDemo.Models;
using RazorPageCurdDemo.Models.ViewModels;

namespace RazorPageCurdDemo.Pages.EMP
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public EmpFormModel empFormModel { get; set; }

        private readonly ApplicationDBContext _dBContext;

        public AddModel(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            var EmpData = new EmpModel()
            {
                Id = Guid.NewGuid(),
                Name = empFormModel.Name,
                Email = empFormModel.Email,
                Salary = empFormModel.Salary,
                DateOfBirth = empFormModel.DateOfBirth,
                Department = empFormModel.Department
            };

            _dBContext.EmpDetails.Add(EmpData);
            _dBContext.SaveChanges();

            ViewData["Message"] = "Registration Successfully";
        }
    }
}
