using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppLogin.Model;

namespace AppLogin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Protegida : ContentPage
    {
        App PropriedadesApp;
        public Protegida()
        {
            InitializeComponent();

            PropriedadesApp = (App)Application.Current;

            frm_dados.BackgroundColor = Color.FromRgba(1, 1, 1, .2);

            Set_Boas_Vindas();
        }

        private void Set_Boas_Vindas()
        {
            string email_login = PropriedadesApp.Properties["usuario_logado"].ToString();

            DadosUsuario usuario_logado = PropriedadesApp.list_usuarios.FirstOrDefault(i => i.Email == email_login);

            lbl_boasvindas.Text = "Bem-vindo (a) " + usuario_logado.Nome;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool confirm = await DisplayAlert("Tem certeza?", "Desconectar sua conta?", "Sim", "Não");

                if (confirm)
                {
                    App.Current.Properties.Remove("usuario_logado");
                    App.Current.MainPage = new Login();
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }
}