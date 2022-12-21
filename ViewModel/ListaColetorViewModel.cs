using System.Collections.ObjectModel;
using INF0999_Projeto.Model;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace INF0999_Projeto.ViewModel
{
    public class ListaColetorViewModel : ObservableObject
    {
        public ObservableCollection<Coletor> listaColetor { get; set; }
        private Model.Coletor _coletorSelecionado;
        private int _ativos;
        public RelayCommand Novox { get; set; }
        public RelayCommand Deletarx { get; set; }
        public RelayCommand Editarx { get; set; }
        public RelayCommand Sairx { get; set; }
        private void NovoCMD()
        {
            var coletorViewModel = new EditaColetorViewModel();
            WeakReferenceMessenger.Default.Send(new OpenWindowMessage(coletorViewModel));
            if (coletorViewModel.coletor != null)
            {
                this.listaColetor.Add(coletorViewModel.coletor);
                this.Ativos++;
                this.ColetorSelecionado = coletorViewModel.coletor;
            }
        }
        private void EditarCMD()
        {
            var coletorViewModel = new EditaColetorViewModel();
            var cloneColetor = (Model.Coletor)this.ColetorSelecionado.Clone();
            coletorViewModel.coletor = cloneColetor;
            WeakReferenceMessenger.Default.Send(new OpenWindowMessage(coletorViewModel));
            if (coletorViewModel.coletor != null)
            {
                this.ColetorSelecionado.Nome = cloneColetor.Nome;
                this.ColetorSelecionado.Telefone = cloneColetor.Telefone;
                this.ColetorSelecionado.Endereço = cloneColetor.Endereço;
            }
        }
        private void DeletarCMD()
        {
            this.listaColetor.Remove(this.ColetorSelecionado);
            this.Ativos--;
            if (this.listaColetor.Count > 0)
                this.ColetorSelecionado = this.listaColetor[0];
            else
                this.ColetorSelecionado = null;
        }
        private void SairCMD()
        {
            System.Windows.Application.Current.Shutdown();
        }
        private bool CanDeletarCMD()
        {
            return this.ColetorSelecionado != null;
        }
        private bool CanEditarCMD()
        {
            return this.ColetorSelecionado != null;
        }
        public Coletor ColetorSelecionado
        {
            get { return _coletorSelecionado; }
            set
            {
                SetProperty(ref _coletorSelecionado, value);
                Deletarx.NotifyCanExecuteChanged();
                Editarx.NotifyCanExecuteChanged();
            }
        }
        public int Ativos
        {
            get { return _ativos; }
            set
            {
                SetProperty(ref _ativos, value);
            }
        }
        public ListaColetorViewModel()
        {
            Novox = new RelayCommand(NovoCMD);
            Deletarx = new RelayCommand(DeletarCMD, CanDeletarCMD);
            Editarx = new RelayCommand(EditarCMD, CanEditarCMD);
            Sairx = new RelayCommand(SairCMD);
            listaColetor = new ObservableCollection<Coletor>();
            PreparaColetorCollection();
        }
        private void PreparaColetorCollection()
        {
            var Coletor1 = new Coletor
            {
                Nome = "João da Silva",
                Endereço = "Rua Dom Pedro",
                Telefone = "019-91234-5678"
            };
            this.listaColetor.Add(Coletor1);
            this.Ativos++;
            var Coletor2 = new Coletor
            {
                Nome = "Luís Miguel Ferreira",
                Endereço = "Rua Jardim Ibirapuera",
                Telefone = "019-99135-7911"
            };
            this.listaColetor.Add(Coletor2);
            this.Ativos++;
            var Coletor3 = new Coletor
            {
                Nome = "Maria Luiza Gomes",
                Endereço = "Rua Presidente Kennedy",
                Telefone = "019-3829-1046"
            };
            this.listaColetor.Add(Coletor3);
            this.Ativos++;
            ColetorSelecionado = this.listaColetor[0];
        }
    }
    public class OpenWindowMessage : ValueChangedMessage<EditaColetorViewModel>
    {
        public OpenWindowMessage(EditaColetorViewModel ColetorViewModel) : base(ColetorViewModel) {}
    }
}