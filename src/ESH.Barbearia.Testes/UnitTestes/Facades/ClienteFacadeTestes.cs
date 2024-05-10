using ESH.Barbearia.ApplicationService.Facades;
using ESH.Barbearia.ApplicationService.Views;
using ESH_Barbearia.DomainModel.Model;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ESH.Barbearia.Testes.UnitTestes.Facades
{
    public class ClienteFacadeTestes
    {
        [Fact(DisplayName = "Ao criar um novo cliente sem informar os campos obrigatórios deve lançar exception")]
        public void Test1()
        {
            var mocker = DefaultMocker();
            var sut = mocker.CreateInstance<ClienteFacade>();

            var result = Assert.Throws<ApplicationException>(() => sut.Salvar(new ClienteView()));

            Assert.Contains($"O campo {nameof(Cliente.Nome)} é obrigatório.", result.Message);
            Assert.Contains($"O campo {nameof(Cliente.Cpf)} é obrigatório.", result.Message);
        }

        [Fact(DisplayName = "Ao altera um cliente sem informar os campos obrigatórios deve lançar exception")]
        public void Test2()
        {
            var mocker = DefaultMocker();
            var sut = mocker.CreateInstance<ClienteFacade>();

            mocker.GetMock<IRepository>().Setup(p => p.Clientes.ObterPor(It.IsAny<int>())).Returns(new Cliente() { Id = 1 });

            var result = Assert.Throws<ApplicationException>(() => sut.Salvar(new ClienteView() { Id = 1}));

            Assert.Contains($"O campo {nameof(Cliente.Nome)} é obrigatório.", result.Message);
            Assert.Contains($"O campo {nameof(Cliente.Cpf)} é obrigatório.", result.Message);
        }

        [Fact(DisplayName = "Ao criar um novo cliente com os dados validos deve chamar o repositorio correspondente")]
        public void Test3()
        {
            var mocker = DefaultMocker();
            var sut = mocker.CreateInstance<ClienteFacade>();

            mocker.GetMock<IRepository>().Setup(p => p.Clientes.Salvar(It.IsAny<Cliente>()));

            sut.Salvar(new ClienteView() { Id = 0, Nome = "Cliente 1", Cpf="123456789"});

            mocker.GetMock<IRepository>().Verify(p => p.Clientes.Salvar(It.IsAny<Cliente>()), Times.Once());
        }

        [Fact(DisplayName = "Ao verificar cliente existente deve chamar o repositorio correspondente")]
        public void Test4()
        {
            var mocker = DefaultMocker();
            var sut = mocker.CreateInstance<ClienteFacade>();

            mocker.GetMock<IRepository>().Setup(p => p.Clientes.ClienteJahExiste(It.IsAny<string>())).Returns(true);

            sut.VerificaSeClienteJahExiste(It.IsAny<string>());

            mocker.GetMock<IRepository>().Verify(p => p.Clientes.ClienteJahExiste(It.IsAny<string>()), Times.Once());
        }

        [Fact(DisplayName = "Ao chamar um cliente existente por Id deve chamar o repositorio correspondente")]
        public void Test5()
        {
            var mocker = DefaultMocker();
            var sut = mocker.CreateInstance<ClienteFacade>();

            mocker.GetMock<IRepository>().Setup(p => p.Clientes.ObterPor(It.IsAny<int>())).Returns(new Cliente() { Id =1});

            sut.ObterPor(It.IsAny<int>());

            mocker.GetMock<IRepository>().Verify(p => p.Clientes.ObterPor(It.IsAny<int>()), Times.Once());
        }

        [Fact(DisplayName = "Ao chamar todos os clientes deve chamar o repositorio correspondente")]
        public void Test6()
        {
            var mocker = DefaultMocker();
            var sut = mocker.CreateInstance<ClienteFacade>();

            mocker.GetMock<IRepository>().Setup(p => p.Clientes.ObterTodos()).Returns(new List<Cliente>());

            sut.ObterTodos();

            mocker.GetMock<IRepository>().Verify(p => p.Clientes.ObterTodos(), Times.Once());
        }

        [Fact(DisplayName = "Ao excluir um clientes existente deve chamar o repositorio correspondente")]
        public void Test7()
        {
            var mocker = DefaultMocker();
            var sut = mocker.CreateInstance<ClienteFacade>();

            mocker.GetMock<IRepository>().Setup(p => p.Clientes.ObterPor(It.IsAny<int>())).Returns(new Cliente() { Id = 1 });
            mocker.GetMock<IRepository>().Setup(p => p.Clientes.Excluir(It.IsAny<Cliente>()));

            sut.Excluir(It.IsAny<int>());

            mocker.GetMock<IRepository>().Verify(p => p.Clientes.Excluir(It.IsAny<Cliente>()), Times.Once());
        }

        [Fact(DisplayName = "Ao tentar excluir um clientes inexistente não deve chamar o repositorio")]
        public void Test8()
        {
            var mocker = DefaultMocker();
            var sut = mocker.CreateInstance<ClienteFacade>();

            mocker.GetMock<IRepository>().Setup(p => p.Clientes.ObterPor(It.IsAny<int>())).Returns((Cliente)default);
            mocker.GetMock<IRepository>().Setup(p => p.Clientes.Excluir(It.IsAny<Cliente>()));

            sut.Excluir(It.IsAny<int>());

            mocker.GetMock<IRepository>().Verify(p => p.Clientes.Excluir(It.IsAny<Cliente>()), Times.Never());
        }

        private AutoMocker DefaultMocker()
        {
            return new AutoMocker();
        }
    }
}
