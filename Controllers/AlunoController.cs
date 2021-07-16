using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;
using System.Linq;
using SmartSchool.API.Data;
using Microsoft.EntityFrameworkCore;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly SmartSchoolContext _smartSchoolContex;
        private readonly IRepository _repository;

        public AlunoController(SmartSchoolContext smartSchoolContext, IRepository _repository)
        {
            this._repository = _repository;
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
            _repository.Add(aluno);
            if (_repository.SaveChages())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não cadastrado!");
        }

        [HttpPut]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _smartSchoolContex.Alunos.AsNoTracking().FirstOrDefault(aluno => aluno.Id == id);
            if (alu == null) return BadRequest("Aluno não encontrado");


            _repository.Update(aluno);
            if (_repository.SaveChages())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não cadastrado!");
        }


        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _smartSchoolContex.Alunos.AsNoTracking().FirstOrDefault(aluno => aluno.Id == id);
            if (alu == null) return BadRequest("Aluno não encontrado");

            _repository.Update(aluno);
            if (_repository.SaveChages())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não cadastrado!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           var alu = _smartSchoolContex.Alunos.AsNoTracking().FirstOrDefault(aluno => aluno.Id == id);
            if (alu == null) return BadRequest("Aluno não encontrado");


            _repository.Delete(alu);
            if (_repository.SaveChages())
            {
                return Ok("aluno excluido com sucesso!");
            }
            return BadRequest("Aluno não excluido!");
        }
    }
}