using FCWebApplication.Service;
using NUnit.Framework;

namespace FCWebApplication.Tests
{
    [TestFixture]
    public class IMCTest
    {
        private JogadorService _jogadorService;

        [SetUp]
        public void SetUp()
        {
            _jogadorService = new JogadorService();
        }

        [Test]
        public void Return_Correct_Message_if_Case_1()
        {
            var result = _jogadorService.ClassificarIMC(15);

            Assert.That(result, Is.EqualTo("Abaixo do peso normal"));
        }
        [Test]
        public void Return_Correct_Message_if_Case_2()
        {
            var result = _jogadorService.ClassificarIMC(21);

            Assert.That(result, Is.EqualTo("Peso normal"));
        }
        [Test]
        public void Return_Correct_Message_if_Case_3()
        {
            var result = _jogadorService.ClassificarIMC(28);

            Assert.That(result, Is.EqualTo("Excesso de peso"));
        }
        [Test]
        public void Return_Correct_Message_if_Case_4()
        {
            var result = _jogadorService.ClassificarIMC(32);

            Assert.That(result, Is.EqualTo("Obesidade classe I"));
        }
        [Test]
        public void Return_Correct_Message_if_Case_5()
        {
            var result = _jogadorService.ClassificarIMC(37);

            Assert.That(result, Is.EqualTo("Obesidade classe II"));
        }
        [Test]
        public void Return_Correct_Message_if_Case_6()
        {
            var result = _jogadorService.ClassificarIMC(50);

            Assert.That(result, Is.EqualTo("Obesidade classe III"));
        }
    }
}

//if (imc < 18.5m) return "Abaixo do peso normal";
//else if (imc >= 18.5m && imc < 24.9m) return "Peso normal";
//else if (imc >= 24.9m && imc < 29.9m) return "Excesso de peso";
//else if (imc >= 29.9m && imc < 34.9m) return "Obesidade classe I";
//else if (imc >= 34.9m && imc < 39.9m) return "Obesidade classe II";
//else return "Obesidade classe III";