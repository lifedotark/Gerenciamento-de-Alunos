using System;
using System.Collections.Generic;
using GerenciamentoAlunos.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using GerenciamentoAlunos.Repository;
using GerenciamentoAlunos.Restricoes;

namespace GerenciamentoAlunos.Controllers
{
    public class AlunoesController : ApiController
    {
        private AlunoRepository repository = new AlunoRepository();

        // GET: api/Alunoes
        public List<Aluno> GetAlunos()
        {
            return repository.Get(new RestricaoAluno());
        }

        // GET: api/Alunoes/5
        [ResponseType(typeof(Aluno))]
        public List<Aluno> GetAluno(int ra)
        {
            return repository.Get(new RestricaoAluno {Ra = ra});
        }

        [ResponseType(typeof(Aluno))]
        public List<Aluno> GetAlunoPorId(int id)
        {
            return repository.Get(new RestricaoAluno { Id = id });
        }

        // POST: api/Alunoes
        [ResponseType(typeof(Aluno))]
        public IHttpActionResult PostAluno(Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.AddOrUpdate(aluno);

            return CreatedAtRoute("DefaultApi", new { id = aluno.Id }, aluno);
        }

        // DELETE: api/Alunoes/5
        [ResponseType(typeof(Aluno))]
        public IHttpActionResult ApagarAluno(int id)
        {
            Aluno aluno = repository.Get(new RestricaoAluno {Id = id}).SingleOrDefault();
            if (aluno == null)
            {
                return NotFound();
            }

            repository.Delete(aluno);

            return Ok(aluno);
        }

        private bool AlunoExists(int id)
        {
            return repository.Exists(id);
        }
    }
}