using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartSchool.API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChages();
        

        //Aluno 
        // Task<PageList<Aluno>> GetAllAlunosAsync(PageParams pageParams, bool includeProfessor = false);        

        // Aluno[] GetAllAlunos();
        // Aluno[] GetAlunosByDisciplinaId();
        // Aluno GetAlunoById();

        // //Professor 
        //  Professor[] GetAllProfessores();
        //  Professor[] GetProfessoresByDisciplinaId();
        //  Professor[] GetAllProfessoresById();

    }
}