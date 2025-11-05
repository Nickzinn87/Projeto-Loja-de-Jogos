using Projeto2W1N.Models;
using Projeto2W1N.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Projeto2W1N.ViewModel
{
    public class JogosViewModel : BaseViewModel
    {
        JogosService jogosService = new JogosService();

        //Precismo herdar da classe BaseViewModel

        //Agora iremos implementar as propriedades
        //dos campos que poderao ser usados em tela
        //geralmente seguimos os atributos da classe
        //referenciada, no caso a classe Carro
        //Mais conhecido como encapsulamento
        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value;
                OnPropertyChanged();
            }
        }

        private string _preco;
        public string Preco
        {
            get { return _preco; }
            set
            {
                _preco = value;
                OnPropertyChanged();
            }
        }
        private string _desc;
        public string Desc
        {
            get { return _desc; }
            set
            {
                _desc = value;
                OnPropertyChanged();
            }
        }

        private bool _Admin;
        public bool Admin
        {
            get { return _Admin; }
            set
            {
                _Admin = value;
                OnPropertyChanged();
            }
        }

        private bool _Cliente;
        public bool Cliente
        {
            get { return _Cliente; }
            set
            {
                _Cliente = value;
                OnPropertyChanged();
            }
        }
        public ICommand CadastrarCommand { get; set; }

        void Cadastrar()
        {

            Jogos jogos = new Jogos();

            jogos.Nome = Nome;
            //jogos.Imagem = Imagem;
            jogos.Preco = Preco;
            jogos.Desc = Desc;


            jogosService.Adicionar(jogos);

            App.Current.MainPage.DisplayAlert("Sucesso", "Usuário cadastrado com sucesso!", "OK");
        }

        public ICommand ConsultarCommand { get; set; }
        public void Consultar()
        {
            Jogos jogos = jogosService.ConsultarNome(_nome);

            Nome = jogos.Nome;
            //Imagem = jogos.Imagem;
            Preco = jogos.Preco;
            Desc = jogos.Desc;
        }

        public ICommand VoltarCommand { get; set; }
        void VoltarComm()
        {
            Voltar();
        }

        

        public ICommand ListagemCommand { get; set; }

        public void Listar()
        {
            Jogos jogos = jogosService.ConsultarNome(_nome);

            Nome = jogos.Nome;
            //Imagem = jogos.Imagem;
            Preco = jogos.Preco;
            Desc = jogos.Desc;
        }

        public ICommand ChecagemCommand { get; set; }

        public void Checar()
        {
            Usuario usuario = FakeDBSingleton.Instancia.UsuarioLogado;

            if (usuario.Admin == true)
            {
                Admin = true;
                Cliente = false;
            }
            else
            {
                Admin = false;
                Cliente = true;
            }
        }

        public JogosViewModel()
        {
            CadastrarCommand = new Command(Cadastrar);
            ConsultarCommand = new Command(Consultar);
            VoltarCommand = new Command(VoltarComm);
            ListagemCommand = new Command(Listar);
            ChecagemCommand = new Command(Checar);

            Checar();
        }

    }
}
