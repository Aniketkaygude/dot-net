using ClassLibrary1.Model;
using ClassLibrary1.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeRepository context;

        public EmployeeController(IEmployeeRepository context)
        {
            this.context = context;
        }


        [HttpGet("all")]

        public IActionResult GetAll()
        {
            List<ClassLibrary1.Model.Employee> employees = context.GetAllEmployees();
           
            return Ok(employees);
        }


        [HttpGet("id/{id:int}")]
        public IActionResult GetById(int id)
        {

            ClassLibrary1.Model.Employee e = context.GetById(id);

            if (e == null)
            {
                return StatusCode(500, $"Employee with ID {id} not found.");
            }

            return Ok(e);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] Employee employee)
        {

            if (employee == null)
            {
                return StatusCode(500, "Employee data is null.");
            }

            ClassLibrary1.Model.Employee e = context.AddEmployee(employee);
            return Ok(e);
        }

        [HttpPost("update")]

        public IActionResult Update([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return StatusCode(500, "Employee data is null.");
            }

            var updatedEmployee = context.UpdateEmployee(employee);
            if (updatedEmployee == null)
            {
                return NotFound($"Employee with ID {employee.EmployeId} not found.");
            }

            return Ok(updatedEmployee);
        }



        [HttpPost("delete/{id:int}")]

        public IActionResult Delete(int id)
        {
            bool isDeleted = context.DeleteEmployee(id);
            if (!isDeleted)
                return NotFound($"Employee with ID {id} not found.");

            return StatusCode(200, " data deleted."); // 204 No Content for successful delete
        }

    }


}
