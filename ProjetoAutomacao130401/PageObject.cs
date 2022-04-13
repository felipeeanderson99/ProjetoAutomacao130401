using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Collections;
using NUnit.Framework;

namespace ProjetoAutomacao130401
{
    class PageObject
    {
        private IWebDriver driver;
        public PageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void pesquisandoVeiculo()
        {
            IWebElement btnVoltarCategorias = driver.FindElement
           (By.Id("searchBar"));

            btnVoltarCategorias.SendKeys("honda civic");
            Thread.Sleep(1000);

            //Clicando no botão pesquisar
            driver.FindElement(By.XPath("/html/body/div[1]/main/div[2]/div/div[1]/div[2]/div/div/a")).Click();

            Thread.Sleep(2000);

            //Clicando no veiculo escolhido

            driver.FindElement(By.XPath("//h2[text()='HONDA CITY']")).Click();
            Thread.Sleep(2000);

        }


        public void novaAba()
        {
            driver.SwitchTo().NewWindow(WindowType.Tab);

            Thread.Sleep(500);
            driver.FindElement(By.CssSelector("body")).SendKeys(Keys.Control + "\t");
            Thread.Sleep(500);


            ((IJavaScriptExecutor)driver).ExecuteScript("window.open()");
            List<string> tabs1 = new List<string>(driver.WindowHandles);
            Thread.Sleep(500);
            driver.SwitchTo().Window(tabs1[2]);
        }


        public void verParcelas()
        {
            Thread.Sleep(5000);

            //Clicando no botão ver parcelas
            IWebElement btnVerParcelas =
           driver.FindElement(By.XPath("//button[text()='Ver parcelas']"));
            IJavaScriptExecutor executor111 = (IJavaScriptExecutor)driver;
            executor111.ExecuteScript("arguments[0].click();", btnVerParcelas);

            Thread.Sleep(2000);

            //Ir para o topo da tela
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,-650)", "");
            js.ExecuteScript("window.scrollBy(0,-650)", "");
            js.ExecuteScript("window.scrollBy(0,-625)", "");

            Thread.Sleep(1000);
        }

        public void validandoDados()
        {
            //Validando os dados da tela

            string ano_modelo = driver.FindElement(By.Id("VehiclePrincipalInformationYear")).Text;
            Assert.AreEqual(ano_modelo, "2012/2012");

            string cidade = driver.FindElement(By.Id("VehiclePrincipalInformationState")).Text;
            Assert.AreEqual(cidade, "São Paulo, SP");

            string modeloVeiculo = driver.FindElement(By.Id("VehicleBasicInformationTitle")).Text;
            Assert.AreEqual(modeloVeiculo, "HONDA CITY\r\n1.5 EX 16V FLEX 4P MANUAL");

            string versao = driver.FindElement(By.Id("VehicleBasicInformationDescription")).Text;
            Assert.AreEqual(versao, "1.5 EX 16V FLEX 4P MANUAL");

            string valor = driver.FindElement(By.Id("vehicleSendProposalPrice")).Text;
            Assert.AreEqual(valor, "R$ 75.000");
        }
    }
}
