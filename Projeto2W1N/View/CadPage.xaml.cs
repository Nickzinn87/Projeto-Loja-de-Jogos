using Projeto2W1N.ViewModel;

namespace Projeto2W1N.View;

public partial class CadPage : ContentPage
{
	public CadPage()
	{
		InitializeComponent();
		BindingContext = new UsuarioViewModel();
    }

    private void btnCadastrar_Clicked(object sender, EventArgs e)
    {

    }
}