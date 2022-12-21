using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace teste_projeto_final.Model
{
    public class Lixo : ObservableObject, ICloneable
    {
        private string _item;
        private int _quantidade;
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
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}