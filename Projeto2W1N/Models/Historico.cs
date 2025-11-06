using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2W1N.Models
{
    public class Historico
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string CPF { get; set; }
        public string NomeJogo { get; set; }
        public DateTime DataSelec { get; set; } = DateTime.Now;
    }
}
