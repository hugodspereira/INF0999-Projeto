using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using teste_projeto_final.Model;

namespace teste_projeto_final
{
    public class LoginWindowViewModel : ObservableObject
    {
        public Produtor produtor { get; set; }
        public RelayCommand OK { get; set; }
        public RelayCommand Cancelar { get; set; }
        private void OkCMD()
        {
            bool comando = true;
            WeakReferenceMessenger.Default.Send(new CloseLoginWindowMessage(comando));
        }
        private void CancelarCMD()
        {
            bool comando = false;
            WeakReferenceMessenger.Default.Send(new CloseLoginWindowMessage(comando));
            produtor = null;
        }
        public LoginWindowViewModel()
        {
            OK = new RelayCommand(OkCMD);
            Cancelar = new RelayCommand(CancelarCMD);
            produtor = new Produtor();
        }
    }
    public class CloseLoginWindowMessage : ValueChangedMessage<bool>
    {
        public CloseLoginWindowMessage(bool value) : base(value)
        {
            
        }
    }
}