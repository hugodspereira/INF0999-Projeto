using teste_projeto_final.Model;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace teste_projeto_final
{
    public class EditaLixoViewModel : ObservableObject
    {
        public Lixo lixo { get; set; }
        public RelayCommand OK { get; set; }
        public RelayCommand Cancelar { get; set; }
        private void OkCMD()
        {
            bool comando = true;
            WeakReferenceMessenger.Default.Send(new CloseLixoWindowMessage(comando));
        }
        private void CancelarCMD()
        {
            bool comando = false;
            WeakReferenceMessenger.Default.Send(new CloseLixoWindowMessage(comando));
            lixo = null;
        }
        public EditaLixoViewModel()
        {
            OK = new RelayCommand(OkCMD);
            Cancelar = new RelayCommand(CancelarCMD);
            lixo = new Lixo();
        }
    }
    public class CloseLixoWindowMessage : ValueChangedMessage<bool>
    {
        public CloseLixoWindowMessage(bool value) : base(value)
        {
            
        }
    }
}