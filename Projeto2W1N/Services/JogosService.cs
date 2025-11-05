using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto2W1N.Models;
using Projeto2W1N.Services;
using SQLite;

namespace Projeto2W1N.Services
{
    public class JogosService
    {
        //FakeDBSingleton dbSingleton = FakeDBSingleton.Instancia;
        private DBService databaseService;
        private SQLiteConnection connection;

        public JogosService()
        {
            databaseService = new DBService();
            connection = databaseService.GetConexao();
            connection.CreateTable<Jogos>();
        }

        public bool Adicionar(Jogos value)
        {
            //dbSingleton.Jogos = value;
            var existe = connection.Table<Jogos>().FirstOrDefault(c => c.Nome == value.Nome);

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

        public Jogos ConsultarNome(string Nome)
        {
            return connection.Table<Jogos>().FirstOrDefault(x => x.Nome == Nome);
        }
    }
}
