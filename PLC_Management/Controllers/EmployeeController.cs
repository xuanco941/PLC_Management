using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PLC_Management;
using PLC_Management.Models.EmployeeModel;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            // check admin
            int ID = Convert.ToInt32(HttpContext.Session.GetInt32(Common.SESSION_USER_LOGIN));
            if(Rules.IsAdmin(ID) == false)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            EmployeeBusiness employeeBusiness = new EmployeeBusiness();
            try
            {
                ViewBag.employees = employeeBusiness.GetAllEmployees();
            }
            catch
            {
                //Lỗi
            }

            return View();
        }

        //Thêm
        [HttpPost]
        public IActionResult InsertEmployee(IFormCollection form)
        {
            // check admin
            int ID = Convert.ToInt32(HttpContext.Session.GetInt32(Common.SESSION_USER_LOGIN));
            if (Rules.IsAdmin(ID) == false)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            string _fullname = form["fullname"];
            string _username = form["username"].ToString().Trim();
            string _password = form["password"].ToString().Trim();
            bool _isAdmin = Convert.ToInt32(form["isAdmin"]) == 1 ? true : false;

            Employee nhanVienModel = new Employee(_fullname, _username, _password, _isAdmin);
            EmployeeBusiness themNhanVienModel = new EmployeeBusiness();
            
            if (themNhanVienModel.AddEmployee(nhanVienModel) == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return Json("Lỗii");
            }


        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee()
        {
            // check admin
            int MaNV = Convert.ToInt32(HttpContext.Session.GetInt32(Common.SESSION_USER_LOGIN));
            if (Rules.IsAdmin(MaNV) == false)
            {
                return RedirectToAction("Index", "Dashboard");
            }


            string strRequestBody;
            using (StreamReader reader = new StreamReader(Request.Body, System.Text.Encoding.UTF8))
            {
                strRequestBody = await reader.ReadToEndAsync();
            }
            Employee? employee = JsonConvert.DeserializeObject<Employee>(strRequestBody);
            EmployeeBusiness capNhatNhanVienModel = new EmployeeBusiness();
            if (capNhatNhanVienModel.UpdateEmployee(employee) == true)
            {
                return Json(employee);
            }
            else
            {
                //Lỗi
                return Json(employee);
            }
        }


        [HttpPost]
        public async Task<IActionResult> GetDataAUser()
        {
            // check admin
            int ID = Convert.ToInt32(HttpContext.Session.GetInt32(Common.SESSION_USER_LOGIN));
            if (Rules.IsAdmin(ID) == false)
            {
                return RedirectToAction("Index", "Dashboard");
            }


            //Đọc dữ liệu gửi lên từ client chuyển về json
            string strRequestBody;
            using (StreamReader reader = new StreamReader(Request.Body, System.Text.Encoding.UTF8))
            {
                strRequestBody = await reader.ReadToEndAsync();
            }
            EmployeeIDModel? iDModel = JsonConvert.DeserializeObject<EmployeeIDModel>(strRequestBody);
            EmployeeBusiness employeeBusiness = new EmployeeBusiness();
            return Json(employeeBusiness.GetDataFromID(iDModel.ID));
        }




        //Xóa
        [HttpPost]
        public IActionResult DeleteEmployee(int id)
        {
            // check admin
            int Employee_ID = Convert.ToInt32(HttpContext.Session.GetInt32(Common.SESSION_USER_LOGIN));
            if (Rules.IsAdmin(Employee_ID) == false)
            {
                return RedirectToAction("Index", "Dashboard");
            }



            EmployeeBusiness nhanVienModel = new EmployeeBusiness();
            if(nhanVienModel.DeleteEmployee(id) == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return Json("Lỗi");
            }
        }

    }
}
