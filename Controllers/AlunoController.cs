using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;
using System.Linq;
using SmartSchool.API.Data;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly SmartSchoolContext _smartSchoolContex;
 
        public AlunoController(SmartSchoolContext smartSchoolContext)
       {
            _smartSchoolContex = smartSchoolContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_smartSchoolContex.Alunos);
        }

        //ById ou ByName para query string
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var aluno = _smartSchoolContex.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Dados Não encontrado");

            return Ok(aluno);
        }

        [HttpGet("ByName")]
        public IActionResult GetById(string nome, string sobreNome)
        {
            var aluno = _smartSchoolContex.Alunos.FirstOrDefault(
                a => a.Name.Contains(nome) && a.SobreNome.Contains(sobreNome)
            );
            if (aluno == null) return BadRequest("Aluno Não encontrado");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }


        [HttpPatch("{id}")]
        public IActionResult Patch(int id,Aluno aluno)
        {
                return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}