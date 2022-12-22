using System.Collections.ObjectModel;
using INF0999_Projeto.Model;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

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
        JsonArray catadores = new JsonArray();
        JsonObject listaDeCatadores = new JsonObject();
        private void NovoCMD()
        {
            var coletorViewModel = new EditaColetorViewModel();
            WeakReferenceMessenger.Default.Send(new OpenWindowMessage(coletorViewModel));
            if (coletorViewModel.coletor != null)
            {
                this.listaColetor.Add(coletorViewModel.coletor);
                this.Ativos++;
                this.ColetorSelecionado = coletorViewModel.coletor;
                InsereColetorJson(coletorViewModel.coletor);
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
                foreach (JsonObject json in this.catadores)
                {
                    if (json["Nome"].ToString() == this.ColetorSelecionado.Nome)
                    {
                        json["Nome"] = cloneColetor.Nome;
                        json["Telefone"] = cloneColetor.Telefone;
                        json["Endereco"] = cloneColetor.Endereço;
                    }
                }
                CriaJson();
                this.ColetorSelecionado.Nome = cloneColetor.Nome;
                this.ColetorSelecionado.Telefone = cloneColetor.Telefone;
                this.ColetorSelecionado.Endereço = cloneColetor.Endereço;
            }
        }
        private void DeletarCMD()
        {
            int index = 0;
            foreach (var json in this.catadores)
            {
                if (json["Nome"].ToString() == this.ColetorSelecionado.Nome)
                {
                    index = catadores.IndexOf(json);
                }
            }
            catadores.RemoveAt(index);
            CriaJson();
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
        private void InsereColetorJson(Coletor coletor)
        {

            var novocoletor = new JsonObject();
            novocoletor["Nome"] = coletor.Nome;
            novocoletor["Endereco"] = coletor.Endereço;
            novocoletor["Telefone"] = coletor.Telefone;
            this.catadores.Add(novocoletor);
            CriaJson();
        }

        public void CriaJson()
        {
            var output_filepath = "Dados/Catadores.json";
            listaDeCatadores["Catadores"] = catadores;
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            using FileStream fs = new(output_filepath, FileMode.Create, FileAccess.Write);
            using StreamWriter sw = new(fs);
            sw.Write(listaDeCatadores.ToJsonString(options));
            sw.Flush();
            sw.Close();
        }

        private void LeJson()
        {
            using (FileStream fs = File.OpenRead("Dados/Catadores.json"))
            {
                JsonDocument jsonDoc = JsonDocument.ParseAsync(fs).Result;
                JsonElement element = jsonDoc.RootElement;

                foreach (JsonProperty j in element.EnumerateObject())
                {
                    foreach (JsonElement i in j.Value.EnumerateArray())
                    {
                        var newperson = new JsonObject();
                        foreach (JsonProperty property in i.EnumerateObject())
                        {
                            newperson[property.Name] = property.Value.ToString();
                        }
                        this.catadores.Add(newperson);
                        PreparaColetorCollection(newperson);
                    }
                }
            }
        }
        public ListaColetorViewModel()
        {
            Novox = new RelayCommand(NovoCMD);
            Deletarx = new RelayCommand(DeletarCMD, CanDeletarCMD);
            Editarx = new RelayCommand(EditarCMD, CanEditarCMD);
            Sairx = new RelayCommand(SairCMD);
            listaColetor = new ObservableCollection<Coletor>();
            LeJson();
        }
        private void PreparaColetorCollection(JsonObject newperson)
        {
            Coletor coletor = new Coletor();
            string nome = newperson["Nome"].ToString();
            string telefone = newperson["Telefone"].ToString();
            string endereco = newperson["Endereco"].ToString();
            coletor.Nome = nome;
            coletor.Telefone = telefone;
            coletor.Endereço = endereco;
            listaColetor.Add(coletor);
        }
    }
    public class OpenWindowMessage : ValueChangedMessage<EditaColetorViewModel>
    {
        public OpenWindowMessage(EditaColetorViewModel ColetorViewModel) : base(ColetorViewModel) { }
    }
}