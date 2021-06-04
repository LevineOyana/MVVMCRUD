using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using WPFMVVM.Model;

namespace WPFMVVM
{
    /// <summary>
    /// Lógica interna para PessoaWindow.xaml
    /// </summary>
    public partial class PessoaWindow : Window
    {
        public PessoaWindow()
        {
            InitializeComponent();
            GeneroComboBox.ItemsSource = Enum.GetValues(typeof(Genero)).Cast<Genero>();

        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (nome.Text == "" || sobrenome.Text == "" ||
            cpf.Text == "" || datanascimento.Text == "" ||
            logradouro.Text == "" || numero.Text == "" ||
            bairro.Text == "" || cidade.Text == "" ||
            estado.Text == "" || cep.Text == "")
            {
                MessageBox.Show("Preencha o(s) campo(s) em branco!");

                if (cpf.Text.Length < 11)
                {
                    MessageBox.Show("O CPF contém 11 dígitos. Tente novamente.");
                }

                if (cep.Text.Length < 8)
                {
                    MessageBox.Show("O Cep contém 8 dígitos. Tente novamente.");
                }
            }
            else if ((cpf.Text.Length >= 11) && (cep.Text.Length >= 8))
            {
                DialogResult = true;
            }

        }

        private static int CalcularIdade(DateTime datanascimento)
        {
            int idade = DateTime.Now.Year - datanascimento.Year;
            if(DateTime.Now.DayOfYear < datanascimento.DayOfYear)
            {
                idade = idade - 1;
            }
            return idade;
        }
    }
}
