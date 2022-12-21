using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace INF0999_Projeto.Model
{
    public class Produtor : ObservableObject, ICloneable
    {
        private string _nome;
        private string _endereço;
        private string _telefone;
        private string _email;
        public string Nome
        {
            get { return _nome; }
            set
            {
                SetProperty(ref _nome, value);
            }
        }
        public string Endereço
        {
            get { return _endereço; }
            set
            {
                SetProperty(ref _endereço, value);
            }
        }
        public string Telefone
        {
            get { return _telefone; }
            set
            {
                SetProperty(ref _telefone, value);
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                SetProperty(ref _email, value);
            }
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}