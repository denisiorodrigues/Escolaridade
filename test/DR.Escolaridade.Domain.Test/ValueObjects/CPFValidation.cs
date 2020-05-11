using DR.Escolaridade.Domain.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DR.Escolaridade.Domain.Test.ValueObjects
{
    [TestClass]
    public class CPFValidation
    {
        [TestMethod]
        public void CPF_Valido_True()
        {
            //Arrange
            var CPFTest = "15633485602";

            //Act
            var result = CPF.Validar(CPFTest);
            //Assert

            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("1563.34.856-01")]
        [DataRow("15633485601")]
        [DataRow("11111111111")]
        [DataRow("111111")]
        public void CPF_Valido_False(string cpf)
        {
            //Act
            var result = CPF.Validar(cpf);
            
            //Assert
            Assert.IsFalse(result);
        }
    }
}