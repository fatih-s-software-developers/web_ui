using kullanici_kayit_web_ui.apicom;
using Microsoft.AspNetCore.Mvc;
using kullanici_kayit_web_ui.apicom.apiModels.StudentObject;
using kullanici_kayit_web_ui.Models;
namespace kullanici_kayit_web_ui.Controllers
{
    public class StudentController : Controller
    {

        ApiComForStudentObject apiCom;

        public StudentController()
        {
            apiCom = new ApiComForStudentObject("http://localhost:5290/api");
        }

        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult AddStudent()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(AddStudent addStudent)
        {
            await apiCom.AddStudent(new AddStudentRequest() { Name = addStudent.Name,Surname = addStudent.Surname,Email = addStudent.Email});
            return RedirectToAction("ListStudent");
        }

        public async Task<IActionResult> ListStudent()
        {

            List<ListStudent> listStudents = new List<ListStudent>();
            List<GetStudentRequest> getStudentRequests = await apiCom.GetStudents();
            foreach (GetStudentRequest item in getStudentRequests)
            {
                listStudents.Add(new ListStudent() { Id = item.Id,Name= item.Name, Surname=item.Surname,Email=item.Email});
            }
            return View(listStudents);
        }

        public IActionResult BoolTest()
        {

            return View();
        }

        public IActionResult zorunluktesti()
        {

            return View();
        }
        [HttpPost]
        public IActionResult zorunluktesti(ZorunlulukTesti zorunluluk)
        {

            return View();
        }



	}
}
