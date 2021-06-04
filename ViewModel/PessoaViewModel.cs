using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WPFMVVM.Model;

namespace WPFMVVM.ViewModel
{
    public class PessoaViewModel : BaseNotifyPropertyChanged
    {
        public ObservableCollection<Pessoa> Pessoas { get; private set; }

        private Pessoa _pessoaSelecionada;
        public Pessoa PessoaSelecionada
        {
            get { return _pessoaSelecionada; }
            set { SetField(ref _pessoaSelecionada, value); }
        }

        public PessoaViewModel()
        {
            Pessoas = new ObservableCollection<Pessoa>();

            Pessoas.Add(new Pessoa()
            {
                Id = 1,
                Nome = "Jorge",
                Sobrenome = "Lima",
                CPF = "12345678910",
                DataNascimento = new DateTime(1984, 12, 31),
                Genero = Genero.Masculino,
                Logradouro = "Avenida Rio de Janeiro",
                Numero = 7095,
                Bairro = "Embratel",
                Cidade = "Porto Velho",
                Estado = "Rondônia",
                Complemento = "Casa",
                Cep = 76825320

            });

            Pessoas.Add(new Pessoa()
            {
                Id = 2,
                Nome = "Almerindo",
                Sobrenome = "Gomes",
                CPF = "10987654321",
                DataNascimento = new DateTime(1993, 10, 21),
                Genero = Genero.Masculino,
                Logradouro = "Rua João Pedro da Rocha",
                Numero = 8520,
                Bairro = "Embratel",
                Cidade = "Porto Velho",
                Estado = "Rondônia",
                Complemento = "Casa",
                Cep = 76812559
            });

            Pessoas.Add(new Pessoa()
            {
                Id = 3,
                Nome = "Caio",
                Sobrenome = "Blat",
                CPF = "74185236",
                DataNascimento = new DateTime(1980, 06, 02),
                Genero = Genero.Masculino,
                Logradouro = "Rua Machado de Assis",
                Numero = 1444,
                Bairro = "Alphaville",
                Cidade = "Goiânia",
                Estado = "Goiás",
                Complemento = "Apartamento",
                Cep = 76745823
            });

            Pessoas.Add(new Pessoa()
            {
                Id = 4,
                Nome = "Sabrina",
                Sobrenome = "Sato",
                CPF = "42573518421",
                DataNascimento = new DateTime(1980, 02, 04),
                Genero = Genero.Feminino,
                Logradouro = "Rua Pinheiro Machado",
                Numero = 2006,
                Bairro = "Santo Antônio",
                Cidade = "Maceió",
                Estado = "Alagoas",
                Complemento = "Casa",
                Cep = 48248634
            });

            Pessoas.Add(new Pessoa()
            {
                Id = 5,
                Nome = "Juliana",
                Sobrenome = "Paes",
                CPF = "42515973591",
                DataNascimento = new DateTime(1979, 03, 26),
                Genero = Genero.Feminino,
                Logradouro = "Rua Mato Grosso",
                Numero = 150,
                Bairro = "Três Marias",
                Cidade = "Fortaleza",
                Estado = "Ceará",
                Complemento = "Casa",
                Cep = 24596421
            });

            PessoaSelecionada = Pessoas.FirstOrDefault();
        }

        public NovoCommand Novo { get; private set; } = new NovoCommand();

        public class NovoCommand : BaseCommand
        {
            public override bool CanExecute(object parameter)
            {
                return parameter is PessoaViewModel;
            }

            public override void Execute(object parameter)
            {
                var viewModel = (PessoaViewModel)parameter;
                var pessoa = new Pessoa();
                var p_Id = 0;

                if (viewModel.Pessoas.Any())
                {
                    p_Id = viewModel.Pessoas.Max(p => p.Id);
                }

                pessoa.Id = p_Id + 1;

                var pw = new PessoaWindow();
                pw.DataContext = pessoa;
                pw.ShowDialog();

                if (pw.DialogResult.HasValue && pw.DialogResult.Value)
                {
                    viewModel.Pessoas.Add(pessoa);
                    viewModel.PessoaSelecionada = pessoa;
                }
            }
        }

        public ExcluirCommand Excluir { get; private set; } = new ExcluirCommand();
        public class ExcluirCommand : BaseCommand
        {
            public override bool CanExecute(object parameter)
            {
                var viewModel = parameter as PessoaViewModel;
                return viewModel != null && viewModel.PessoaSelecionada != null;
            }

            public override void Execute(object parameter)
            {
                var viewModel = (PessoaViewModel)parameter;
                viewModel.Pessoas.Remove(viewModel.PessoaSelecionada);
                viewModel.PessoaSelecionada = viewModel.Pessoas.FirstOrDefault();
            }
        }

        public EditarCommand Editar { get; private set; } = new EditarCommand();
        public class EditarCommand : BaseCommand
        {
            public override bool CanExecute(object parameter)
            {
                var viewModel = parameter as PessoaViewModel;
                return viewModel != null && viewModel.PessoaSelecionada != null;
            }

            public override void Execute(object parameter)
            {
                var viewModel = (PessoaViewModel)parameter;
                var clonePessoa = (Pessoa)viewModel.PessoaSelecionada.Clone();
                var pw = new PessoaWindow();
                pw.DataContext = clonePessoa;
                pw.ShowDialog();

                if (pw.DialogResult.HasValue && pw.DialogResult.Value)
                {
                    viewModel.PessoaSelecionada.Nome = clonePessoa.Nome;
                    viewModel.PessoaSelecionada.Sobrenome = clonePessoa.Sobrenome;
                    viewModel.PessoaSelecionada.CPF = clonePessoa.CPF;
                    viewModel.PessoaSelecionada.DataNascimento = clonePessoa.DataNascimento;
                    viewModel.PessoaSelecionada.Genero = clonePessoa.Genero;
                    viewModel.PessoaSelecionada.Logradouro = clonePessoa.Logradouro;
                    viewModel.PessoaSelecionada.Numero = clonePessoa.Numero;
                    viewModel.PessoaSelecionada.Bairro = clonePessoa.Bairro;
                    viewModel.PessoaSelecionada.Cidade = clonePessoa.Cidade;
                    viewModel.PessoaSelecionada.Estado = clonePessoa.Estado;
                    viewModel.PessoaSelecionada.Complemento = clonePessoa.Complemento;
                    viewModel.PessoaSelecionada.Cep = clonePessoa.Cep;
                }
            }
        }
    }
}
