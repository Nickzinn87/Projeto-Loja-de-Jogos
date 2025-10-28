using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Projeto2W1N.Models;
using Projeto2W1N.Services;

namespace Projeto2W1N.ViewModel
{
    public class UsuarioViewModel : BaseViewModel
    {
        UsuarioService usuarioService = new UsuarioService();

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

        private string _CPF;
        public string CPF
        {
            get { return _CPF; }
            set
            {
                _CPF = value;
                OnPropertyChanged();
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        private string _senha;
        public string Senha
        {
            get { return _senha; }
            set
            {
                _senha = value;
                OnPropertyChanged();
            }
        }
        private string _dataNasc;
        public string DataNasc
        {
            get { return _dataNasc; }
            set
            {
                _dataNasc = value;
                OnPropertyChanged();
            }
        }
        public ICommand CadastrarCommand { get; set; }

        void Cadastrar()
        {

            Usuario usuario = new Usuario();

            usuario.Nome = Nome;
            usuario.CPF = CPF;
            usuario.Email = Email;
            usuario.Senha = Senha;
            usuario.DataNasc = DataNasc;


            usuarioService.Adicionar(usuario);

            App.Current.MainPage.DisplayAlert("Sucesso", "Usuário cadastrado com sucesso!", "OK");


            //AbrirView(new UsuarioLoginView());
        }

        public ICommand ConsultarCommand { get; set; }
        public void Consultar()
        {
            Usuario usuario = usuarioService.Consultar();

            Nome = usuario.Nome;
            CPF = usuario.CPF;
            Email = usuario.Email;
            Senha = usuario.Senha;
            DataNasc = usuario.DataNasc;
        }

        public ICommand LoginCommand { get; set; }

        void Login()
        {
            Usuario usuario = usuarioService.Consultar();

            if (usuario == null)
            {
                App.Current.MainPage.DisplayAlert("Erro", "Nenhum usuário cadastrado", "OK");
                return;
            }

            if (Email == usuario.Email && Senha == usuario.Senha)
            {
                //AbrirView(new MainPageView());
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Erro", "Email ou senha incorretos", "OK");
            }


        }

        public UsuarioViewModel()
        {
            CadastrarCommand = new Command(Cadastrar);
            ConsultarCommand = new Command(Consultar);
            LoginCommand = new Command(Login);
        }
    }
}
