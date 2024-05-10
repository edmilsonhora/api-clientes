using ESH_Barbearia.DomainModel.Model;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ESH.Barbearia.Testes.UnitTestes.Models
{
    public class ClienteTestes
    {
        [Fact(DisplayName = "Ao validar cliente sem informar campos obrigatórios deve lançar exception")]
        public void Test1()
        {
            var sut = new Cliente();

           var result = Assert.Throws<ApplicationException>(() => sut.Validar());

            Assert.Contains($"O campo {nameof(Cliente.Nome)} é obrigatório.", result.Message);
            Assert.Contains($"O campo {nameof(Cliente.Cpf)} é obrigatório.", result.Message);
        }

        [Fact(DisplayName = "Ao validar cliente informando os campos obrigatórios a validação deve passar")]
        public void Test2()
        { 
            var sut = new Cliente();
            sut.Cpf = "12345678910";
            sut.Nome = "NomeDoCliente";           

            sut.Validar();

            Assert.NotNull(sut);
        }
    }
}
