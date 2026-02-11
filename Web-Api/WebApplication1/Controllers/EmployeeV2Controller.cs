using ClassLibrary1.Repository;
using Microsoft.AspNetCore.Mvc;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class EmployeeV2Controller : ControllerBase
{
    private readonly IEmployeeRepository context;

    public EmployeeV2Controller(IEmployeeRepository context)
    {
        this.context = context;
    }

    [HttpGet("AllEmployees")]
    public IActionResult GetAll()
    {
        var employees = context.GetAllEmployees();
        return Ok(employees);
    }


    [HttpGet("New/id/{id:int}")]
    public IActionResult GetById(int id)
    {

        ClassLibrary1.Model.Employee e = context.GetById(id);

        if (e == null)
        {
            return StatusCode(500, $"Employee with ID {id} not found.");
        }

        return Ok(e);
    }

}
