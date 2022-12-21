using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using INF0999_Projeto.Model;

namespace INF0999_Projeto
{
    public class EditaProdutorViewModel : ObservableObject
    {
        public Produtor produtor { get; set; }
        public RelayCommand OK { get; set; }
        public RelayCommand Cancelar { get; set; }
        private void OkCMD()
        {
            bool comando = true;
            WeakReferenceMessenger.Default.Send(new CloseAgendamentoWindowMessage(comando));
        }
        private void CancelarCMD()
        {
            bool comando = false;
            WeakReferenceMessenger.Default.Send(new CloseAgendamentoWindowMessage(comando));
            produtor = null;
        }
        public EditaProdutorViewModel()
        {
            OK = new RelayCommand(OkCMD);
            Cancelar = new RelayCommand(CancelarCMD);
            produtor = new Produtor();
        }
    }
    public class CloseAgendamentoWindowMessage : ValueChangedMessage<bool>
    {
        public CloseAgendamentoWindowMessage(bool value) : base(value)
        {
            
        }
    }
}