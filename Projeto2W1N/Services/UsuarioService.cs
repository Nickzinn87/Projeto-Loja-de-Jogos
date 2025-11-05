using Projeto2W1N.Models;
using Projeto2W1N.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2W1N.Services
{
    public class UsuarioService
    {
        //FakeDBSingleton dbSingleton = FakeDBSingleton.Instancia;
        private DBService databaseService;
        private SQLiteConnection connection;
        private FakeDBSingleton dbSingleton = FakeDBSingleton.Instancia;

        public UsuarioService()
        {
            databaseService = new DBService();
            connection = databaseService.GetConexao();
            connection.CreateTable<Usuario>();
        }

        public bool Adicionar(Usuario value)
        {
            //dbSingleton.Usuario = value;
            var existe = connection.Table<Usuario>().FirstOrDefault(c => c.CPF == value.CPF);

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

        public void Logar(Usuario value)
        {
            dbSingleton.UsuarioLogado = value;
        }

        public Usuario ConsultarSingleton()
        {
            return dbSingleton.UsuarioLogado;
        }

        public Usuario ConsultarCPF(string CPF)
        {
            return connection.Table<Usuario>().FirstOrDefault(x => x.CPF == CPF);
        }

        public Usuario ConsultarEmail(string Email)
        {
            return connection.Table<Usuario>().FirstOrDefault(x => x.Email == Email);
        }
    }
}
