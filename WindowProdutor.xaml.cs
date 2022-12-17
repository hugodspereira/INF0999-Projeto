using CommunityToolkit.Mvvm.Messaging;
using System.Windows;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.IO;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


namespace INF0999_Projeto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WindowProdutor : Window
    {
        public WindowProdutor()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string output_filepath = "Catadores.json";
            using (TextWriter writer = File.CreateText(output_filepath))
            {
                writer.WriteLine("Hello World!");
            }
        }


    }

    public class Person
    {
        public string Name { get; set; }
        public string Favourite { get; set; }
        public string Desc { get; set; }
    }

    public class ManageJSON
    {
        List<Person> people = new List<Person>();
        string output_filepath = "catadores/Catadores.json";
        JsonObject textjson = new JsonObject();
        JsonArray array = new JsonArray();
        StreamReader r = new StreamReader("catadores/Catadores.json");

        string text = File.ReadAllText(@"./catadores/Catadores.json");

        List<Person> people = JsonSerializer.Deserialize<List<Person>>(text);


        public void AddPerson(Person person)
        // {
        //     array.Add(person);
        // }

        // public void WriteJSON()
        // {
        //     using FileStream fs = new(output_filepath, FileMode.Create, FileAccess.Write);
        //     using StreamWriter sw = new(fs);

        // }

    }









}

