using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Xamarin.Forms;
using TareaS7.Views;
using TareaS7.Models;

namespace TareaS7.ViewModels
{
    public class ViewModelMainPage : INotifyPropertyChanged
    {
        public ViewModelMainPage()
        {

            inicioSesion = new Command(async () => {


                HttpClient cliente = new HttpClient();


                var respuesta = await cliente.GetAsync(url + "/" + this.usuario + "/" + this.pass);

                if (respuesta.IsSuccessStatusCode)
                {

                    var contenido = await respuesta.Content.ReadAsStringAsync();



                    var inicioSesion = System.Text.Json.JsonSerializer.Deserialize<List<login>>(contenido);
                    var inicioSesio = System.Text.Json.JsonSerializer.Deserialize<List<login>>(contenido);

                 
                    if (inicioSesion[0].is_valid == 1  )
                    {
                        if (inicioSesio[0].id_rol == 1)
                        {
                            await Application.Current.MainPage.Navigation.PushAsync(new ViewInicio());
                        }
                       

                    }
                    else
                    {

                        Resultado = "Inicio de Sesión Erroneo";
                    }

                }

            });


        }

        INavigation navigation;

        string url = "https://desfrlopez.me/acaceres/api/login";

        string usuario;
        public string Usuario
        {
            get => usuario;
            set
            {
                usuario = value;
                var args = new PropertyChangedEventArgs(nameof(Usuario));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string pass;
        public string Pass
        {
            get => pass;
            set
            {
                pass = value;
                var args = new PropertyChangedEventArgs(nameof(Pass));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string resultado;
        public string Resultado
        {
            get => resultado;
            set
            {
                resultado = value;
                var args = new PropertyChangedEventArgs(nameof(Resultado));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public Command inicioSesion { get; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
