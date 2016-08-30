using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GerenciamentoAlunos.Models;
using GerenciamentoAlunos.Restricoes;

namespace GerenciamentoAlunos.Repository
{
    public class AlunoRepository
    {
        public List<Aluno> Get(RestricaoAluno restricao)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var dbAlunos = context.Alunos.AsQueryable();

                if (restricao.Id.HasValue)
                    dbAlunos = dbAlunos.Where(a => a.Id == restricao.Id.Value);

                if (restricao.Ra.HasValue)
                    dbAlunos = dbAlunos.Where(a => a.Ra == restricao.Ra.Value);

                return dbAlunos.ToList();
            }
        }


        public void AddOrUpdate(Aluno aluno)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                if (aluno.Id == 0)
                {
                    context.Alunos.Add(aluno);
                }
                else
                {
                    context.Alunos.Attach(aluno);
                    context.Entry(aluno).State = EntityState.Modified;
                }

                context.SaveChanges();
            }
        }


        public void Delete(Aluno aluno)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                context.Alunos.Attach(aluno);
                context.Alunos.Remove(aluno);
                context.SaveChanges();
            }
        }

        public bool Exists(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.Alunos.Count(e => e.Id == id) > 0;
            }
        }
    }
}