using teste_projeto_final.Model;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace teste_projeto_final
{
    public class EditaColetorViewModel : ObservableObject
    {
        public Coletor coletor { get; set; }
        public RelayCommand OK { get; set; }
        public RelayCommand Cancelar { get; set; }
        private void OkCMD()
        {
            bool comando = true;
            WeakReferenceMessenger.Default.Send(new CloseWindowMessage(comando));
        }
        private void CancelarCMD()
        {
            bool comando = false;
            WeakReferenceMessenger.Default.Send(new CloseWindowMessage(comando));
            coletor = null;
        }
        public EditaColetorViewModel()
        {
            OK = new RelayCommand(OkCMD);
            Cancelar = new RelayCommand(CancelarCMD);
            coletor = new Coletor();
        }
    }
    public class CloseWindowMessage : ValueChangedMessage<bool>
    {
        public CloseWindowMessage(bool value) : base(value)
        {
            
        }
    }
}