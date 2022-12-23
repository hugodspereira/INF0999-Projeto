using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace INF0999_Projeto.Model
{
    public class Lixo : ObservableObject, ICloneable
    {
        private string _item;
        private int _quantidade;
        private string _dono;
        public string Item
        {
            get { return _item; }
            set
            {
                SetProperty(ref _item, value);
            }
        }
        public int Quantidade
        {
            get { return _quantidade; }
            set
            {
                SetProperty(ref _quantidade, value);
            }
        }
        public string Dono
        {
            get { return _dono; }
            set
            {
                SetProperty(ref _dono, value);
            }
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}