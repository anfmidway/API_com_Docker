using System;
using System.Collections;
using System.Collections.Generic;

namespace SmartSchool.API.Models
{
    public class Aluno
    {
        public Aluno() { }

        public Aluno(int id, string name, string sobreNome, string telefone)
        {
            this.Id = id;
            this.Name = name;
            this.SobreNome = sobreNome;
            this.Telefone = telefone;

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string SobreNome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime? DataIni { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }







    }
}