using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Threading;

namespace ProjetoAutomacao130401
{
    public class Tests
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new EdgeDriver();
            driver.Navigate().GoToUrl("https://hportal.webmotors.com.br/");
            driver.Manage().Window.Maximize();

            Thread.Sleep(4500);
        }

        [Test]
        public void BuscandoVeiculo()
        {
            PageObject Page = new PageObject(driver);
            Page.pesquisandoVeiculo();
            Page.novaAba();
            Page.verParcelas();
            Page.validandoDados();
        }

        [TearDown]
        public void Dispose()
        {
            driver.Quit();
        }
    }
}