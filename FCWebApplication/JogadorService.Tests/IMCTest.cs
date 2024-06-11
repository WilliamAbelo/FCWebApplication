using FCWebApplication.Service;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            public void IsPrime_InputIs1_ReturnFalse()
            {
                var result = _jogadorService.ClassificarIMC(1);

                Assert.That(result, Is.True, "1 should not be prime");
            }
    }
}