using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace teste_projeto_final.Model
{
    public class Coletor : ObservableObject, ICloneable
    {
        private string _nome;
        private string _endereço;
        private string _telefone;
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
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}