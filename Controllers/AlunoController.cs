using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;
using System.Linq;


namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> alunos = new List<Aluno>()
        {
            new Aluno()
            {
              Id=1,  Name = "Joice",SobreNome="Dara",Telefone="112233"
            },
           new Aluno(){
                 Id=2,  Name = "Paula",SobreNome="Vida",Telefone="112244"
            },
           new Aluno()
           {
                Id=3,  Name = "José",SobreNome="Rei",Telefone="113344"
           }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(alunos);
        }

        //ById ou ByName para query string
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Dados Não encontrado");

            return Ok(aluno);
        }

        [HttpGet("ByName")]
        public IActionResult GetById(string nome, string sobreNome)
        {
            var aluno = alunos.FirstOrDefault(
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
            return Ok(alunos);
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