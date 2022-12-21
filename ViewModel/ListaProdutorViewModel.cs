using System.Collections.ObjectModel;
using teste_projeto_final.Model;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace teste_projeto_final.ViewModel
{
    public class ListaProdutorViewModel : ObservableObject
    {
        public ObservableCollection<Produtor> listaProdutor { get; set; }
        private Model.Produtor _produtorSelecionado;
        public RelayCommand Novox { get; set; }
        public RelayCommand Deletarx { get; set; }
        public RelayCommand Editarx { get; set; }
        public RelayCommand Sairx { get; set; }
        public RelayCommand Loginx { get; set; }
        private void NovoCMD()
        {
            var produtorViewModel = new CadastroWindowViewModel();
            WeakReferenceMessenger.Default.Send(new CadastroWindowMessage(produtorViewModel));
            if (produtorViewModel.produtor != null)
            {
                this.listaProdutor.Add(produtorViewModel.produtor);
                this.ProdutorSelecionado = produtorViewModel.produtor;
            }
        }
        private void EditarCMD()
        {
            var produtorViewModel = new CadastroWindowViewModel();
            var cloneProdutor = (Model.Produtor)this.ProdutorSelecionado.Clone();
            produtorViewModel.produtor = cloneProdutor;
            WeakReferenceMessenger.Default.Send(new CadastroWindowMessage(produtorViewModel));
            if (produtorViewModel.produtor != null)
            {
                this.ProdutorSelecionado.Nome = cloneProdutor.Nome;
                this.ProdutorSelecionado.Telefone = cloneProdutor.Telefone;
                this.ProdutorSelecionado.Endereço = cloneProdutor.Endereço;
            }
        }
        private void DeletarCMD()
        {
            this.listaProdutor.Remove(this.ProdutorSelecionado);
            if (this.listaProdutor.Count > 0)
                this.ProdutorSelecionado = this.listaProdutor[0];
            else
                this.ProdutorSelecionado = null;
        }
        private void SairCMD()
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void LoginCMD()
        {
            var produtorViewModel = new LoginWindowViewModel();
            WeakReferenceMessenger.Default.Send(new LoginWindowMessage(produtorViewModel));
        }
        private bool CanDeletarCMD()
        {
            return this.ProdutorSelecionado != null;
        }
        private bool CanEditarCMD()
        {
            return this.ProdutorSelecionado != null;
        }
        public Produtor ProdutorSelecionado
        {
            get { return _produtorSelecionado; }
            set
            {
                SetProperty(ref _produtorSelecionado, value);
                Deletarx.NotifyCanExecuteChanged();
                Editarx.NotifyCanExecuteChanged();
            }
        }
        public ListaProdutorViewModel()
        {
            Novox = new RelayCommand(NovoCMD);
            Deletarx = new RelayCommand(DeletarCMD, CanDeletarCMD);
            Editarx = new RelayCommand(EditarCMD, CanEditarCMD);
            Sairx = new RelayCommand(SairCMD);
            Loginx = new RelayCommand(LoginCMD);
            listaProdutor = new ObservableCollection<Produtor>();
        }
    }
    public class CadastroWindowMessage : ValueChangedMessage<CadastroWindowViewModel>
    {
        public CadastroWindowMessage(CadastroWindowViewModel ProdutorViewModel) : base(ProdutorViewModel) {}
    }
    public class LoginWindowMessage : ValueChangedMessage<LoginWindowViewModel>
    {
        public LoginWindowMessage(LoginWindowViewModel ProdutorViewModel) : base(ProdutorViewModel) {}
    }
}