using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Projeto2W1N.ViewModel
{
    public class BaseViewModel : BaseNotifyViewModel
    {
        public ICommand VoltarCommand { get; set; }

        public async void Voltar()
        {
            await Application.Current.MainPage.
                Navigation.PopAsync();
        }

        public async void AbrirView(ContentPage view)
        {
            //Abriremos a tela recebida via parametro
            await Application.Current.MainPage.
                Navigation.PushAsync(view);
        }

        public BaseViewModel()
        {
            VoltarCommand = new Command(Voltar);
        }
    }
}
