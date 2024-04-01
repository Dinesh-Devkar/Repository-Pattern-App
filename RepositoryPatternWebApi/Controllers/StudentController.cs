using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace RepositoryPatternWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController:ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }


        [HttpPost]
        public async Task<IActionResult> PostStudent(Student student)
        {
            await _unitOfWork.Students.AddAsync(student);
            if (await _unitOfWork.Complete()>0)
            {
                return Ok("Student Created Successfully");
            }
            return Ok("Student Not Created");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result= await _unitOfWork.Students.GetAll();
            return Ok(result);
        }
    }
}