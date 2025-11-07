using Projeto2W1N.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2W1N.Services
{
    public class HistoricoService
    {
        //FakeDBSingleton dbSingleton = FakeDBSingleton.Instancia;
        private DBService databaseService;
        private SQLiteConnection connection;

        public HistoricoService()
        {
            databaseService = new DBService();
            connection = databaseService.GetConexao();
            connection.CreateTable<Historico>();
        }

        public bool Adicionar(Historico value)
        {
            var existe = connection.Table<Historico>()
                .FirstOrDefault(c => c.NomeJogo == value.NomeJogo && c.CPF == value.CPF);

            if (existe != null)
            {
                value.Id = existe.Id;
                return connection.Update(value) > 0;
            }
            else
            {
                return connection.Insert(value) > 0;
            }
        }

        public bool Excluir(Historico value)
        {
            //dbSingleton.Historico = value;
            return connection.Delete(value) > 0;
        }

        public Historico ConsultarNome(string CPF)
        {
            return connection.Table<Historico>().FirstOrDefault(x => x.CPF == CPF);
        }

        public List<Historico> ConsultarTodos()
        {
            return connection.Table<Historico>().ToList();
        }

    }
}
