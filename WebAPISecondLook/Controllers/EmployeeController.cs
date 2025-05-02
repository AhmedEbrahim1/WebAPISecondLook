using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAPISecondLook.Models;
using WebAPISecondLook.Models.Context;

namespace WebAPISecondLook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //api
        //getAll
        //getById
        //AddEmployee
        //EditEmployee
        //DeleteEmployee

        //don't create just ask 
        private readonly ApplicationContext context;


        public EmployeeController(ApplicationContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var emps = context.Employees.ToList();
            return Ok(emps);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            var emp = context.Employees.FirstOrDefault(emp => emp.Id == id);
            if (emp is not null)
            {
                return Ok(emp);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteEmployee(int id)
        {
            var empDeleted = context.Employees.FirstOrDefault(x => x.Id == id);
            if(empDeleted is not null)
            {
                context.Employees.Remove(empDeleted);
                context.SaveChanges();
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
               
        }

        [HttpPost]
        public IActionResult PostEmployee(Employee employee)
        {
            if(ModelState.IsValid)
            {
                context.Employees.Add(employee);
                context.SaveChanges();

                //return created 
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult PutEmployee(int id , Employee newEmployee)
        {
            if(ModelState.IsValid)
            {
                var oldEmp = context.Employees.Find(id);
                if(oldEmp is not null)
                {
                    oldEmp.Name = newEmployee.Name;
                    oldEmp.Salary = newEmployee.Salary;
                    oldEmp.Age = newEmployee.Age;
                    oldEmp.Address = newEmployee.Address;
                    context.Employees.Update(oldEmp);
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //consume this api 


    }
}
