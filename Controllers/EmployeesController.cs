using Employee_Management.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Employee_Management.Controllers
{
    public class EmployeesController : ApiController
    {
        public static List<Employee> EmployeeList = new List<Employee>()
        {
            new Employee{ Id=101,Name="Shashank",Designation="Developer",Salary=10000},
            new Employee{ Id=102,Name="Geeta",Designation="HR",Salary=2000},
            new Employee{ Id=103,Name="Vanshika",Designation="Data Analyst",Salary=3000},
            new Employee{ Id=104,Name="Rohit",Designation="Accountant",Salary=15000},
        };
        
        //api/Employees
        public List<Employee> Get()
        {
            return EmployeeList;
        }
        
        //api/Employees/{id}
        public HttpResponseMessage GetEmployee(int id)
        {
            var empbyid = EmployeeList.FirstOrDefault(x=>x.Id == id);
            if(empbyid == null || empbyid.Id != id)
            {
                var message = string.Format("This id is not found");
                HttpError er= new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, er);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK,empbyid);
            }
        }
        public void PostEmployee(Employee employee)
        {
            EmployeeList.Add(employee);             
        }
        public HttpResponseMessage PutEmployee(int id,Employee employee) 
        {
            var emp = EmployeeList.FirstOrDefault(x=> x.Id == id);
            if (emp != null)
            {
                emp.Name = employee.Name;
                emp.Designation = employee.Designation;
                emp.Salary = employee.Salary;
                var message = string.Format("Updated");
                HttpError er = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.OK, er);
            }
            else
            {
                var message = string.Format("This id is not found");
                HttpError er = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, er);
            }
        }
        public HttpResponseMessage DeleteEmployee(int id)
        {
            var empdel = EmployeeList.FirstOrDefault(x=>x.Id==id);
            if (empdel != null)
            {
                EmployeeList.Remove(empdel);
                var message = string.Format("Value Deleted Successfully");
                HttpError er = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.OK, er);
            }
            else
            {
                var message = string.Format("This id is not found");
                HttpError er = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, er);
            }
        }
    }
}
