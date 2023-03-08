using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using TareaS7.Models;
using Xamarin.Forms;

namespace TareaS7.ViewModels
{
    internal class ViewModelRegistro : INotifyPropertyChanged
    {
        public ViewModelRegistro() {

            registroUsuario = new Command(async () =>
            {
                HttpClient client = new HttpClient();

                var envio = await client.GetAsync(url + "/" + this.nombre + "/" +this.usuario + "/" + this.pass +"/" +"1" + "/" + "1");
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

        string usuario;
        public string Usuario 
        {
            get => usuario;
            set
            {
                usuario = value;
                var args = new PropertyChangedEventArgs(nameof(usuario));
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
        

        public Command registroUsuario { get; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
