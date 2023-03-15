using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TareaS7.Models;
using TareaS7.Views;
using Xamarin.Forms;

namespace TareaS7.ViewModels
{
    public class ViewModelRegistro : INotifyPropertyChanged
    {
        public ViewModelRegistro() {

            registroUsuario = new Command(async () =>
            {
                using (var httpClient = new HttpClient())
                {
                    registro body1 = new registro()
                    {
                        nombre_cliente = this.nombre,
                        email = this.email,
                        pass = this.pass,
                        active = 1,
                        id_rol = 1
                    };
                    var myContent = JsonConvert.SerializeObject(body1);
                    var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

                    var respuesta = await httpClient.PostAsync(url, stringContent);

                    if (respuesta.IsSuccessStatusCode)
                    {
                       // getPersonas();
                        await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
                    }
                }
            });
        }
        INavigation navigation;

        string url = "https://desfrlopez.me/acaceres/api/tbl_cliente";

        string nombre;
        public string Nombre
        {
            get => nombre;
            set
            {
                nombre = value;
                var args = new PropertyChangedEventArgs(nameof(nombre));
                PropertyChanged?.Invoke(this, args);
            }
        }

        string email;
        public string Email 
        {
            get => email;
            set
            {
                email = value;
                var args = new PropertyChangedEventArgs(nameof(email));
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
                var args = new PropertyChangedEventArgs(nameof(pass));
                PropertyChanged?.Invoke(this, args);
            }
        }
        
        registro personaSeleccionada = new registro();

        public registro PersonaSeleccionada
        {
            get => personaSeleccionada;
            set
            {
                personaSeleccionada = value;
                var args = new PropertyChangedEventArgs(nameof(PersonaSeleccionada));
                PropertyChanged?.Invoke(this, args);

            }
        }

        private async void getPersonas()
        {

            ListPersonas = new ObservableCollection<registro>();

            HttpClient httpClient = new HttpClient();

            var respuesta = await httpClient.GetAsync(url);

            if (respuesta.IsSuccessStatusCode)
            {

                var contenido = await respuesta.Content.ReadAsStringAsync();
                JsonSerializerOptions opciones = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                var listado = System.Text.Json.JsonSerializer.Deserialize<List<registro>>(contenido, opciones);


                foreach (var item in listado)
                {

                    ListPersonas.Add(item);


                }

            }
        }

        ObservableCollection<registro> listPersonas = new ObservableCollection<registro>();

        public ObservableCollection<registro> ListPersonas
        {
            get => listPersonas;
            set
            {

                listPersonas = value;
                var args = new PropertyChangedEventArgs(nameof(ListPersonas));
                PropertyChanged?.Invoke(this, args);

            }


        }

        public Command registroUsuario { get; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
