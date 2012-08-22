using System;
using TechTalk.SpecFlow;
using DiarioEscolar.AcceptanceTests.StepHelpers;
using WatiN.Core;
using NUnit.Framework;

namespace DiarioEscolar.AcceptanceTests.Steps
{
    [Binding]
    public class CadastraDeSeriesSteps
    {

        //[Given(@"we clean the database")]
        //public void GivenWeCleanTheDatabase()
        //{
        //    SqlConnection ThisConnection = new SqlConnection(@"Server=1.10.26;Database=410_LK;Trusted_Connection=True");
        //    ThisConnection.Open();
        //    SqlCommand thisCommand = ThisConnection.CreateCommand();
        //    thisCommand.CommandText = "delete from costcentre where linstid = 410";
        //    SqlDataReader thisReader = thisCommand.ExecuteReader();
        //    thisReader.Close();
        //    ThisConnection.Close();
        //}

        [Given(@"Eu estou logado no site Diario Escolar")]
        public void GivenEuEstouLogadoNoSiteDiarioEscolar()
        {
            WeBrowser.Current.GoTo("http://localhost:4199/Account/Login");
            WeBrowser.Current.TextField(Find.ByName("UserName")).TypeText("sergio");
            WeBrowser.Current.TextField(Find.ByName("Password")).TypeText("123456");

            WeBrowser.Current.Button(Find.ByValue("Entrar")).Click();

            Assert.IsTrue(WeBrowser.Current.Link(Find.ByText("Sair")).Exists);

        }
        
        [Given(@"Estou na página principal")]
        public void GivenEstouNaPaginaPrincipal()
        {
            WeBrowser.Current.GoTo("http://localhost:4199/");
        }
        
        [When(@"Eu clico no link Séries")]
        public void WhenEuClicoNoLinkSeries()
        {
            var link = WeBrowser.Current.Link(Find.ByText("Séries"));
            if (!link.Exists)
                Assert.Fail("Não encontrado link para acesso ao cadastro de séries");

            link.Click();
        }
        
        [When(@"Eu clico no link Cadastrar nova série")]
        public void WhenEuClicoNoLinkCadastrarNovaSerie()
        {
            var link = WeBrowser.Current.Link(Find.ByText("Cadastrar nova série"));
            if (!link.Exists)
                Assert.Fail("Não encontrado link para criação de uma nova série");

            link.Click();
        }
        
        [When(@"Eu preencho o formulário com os seguintes campos")]
        public void WhenEuPreenchoOFormularioComOsSeguintesCampos(TechTalk.SpecFlow.Table table)
        {                       

            foreach (var tableRow in table.Rows)
            {                
                var field = WeBrowser.Current.ElementOfType<TextFieldExtended>(tableRow["Field"]);
                if(!field.Exists)
                    Assert.Fail(String.Format("Não encontrado campo {0} na página", field));

                string value = String.Format("{0}{1}", tableRow["Value"], new Random().Next(1000).ToString());
                field.TypeText(value);
            }
        }
        
        [When(@"Eu clico em Salvar")]
        public void WhenEuClicoEmSalvar()
        {
            WeBrowser.Current.Button(Find.ByValue("Salvar")).Click();
        }
        
        [Then(@"Eu devo ser redirecionado para a página de listagem de séries e ver a mensagem ""(.*)""")]
        public void ThenEuDevoSerRedirecionadoParaAPaginaDeListagemDeSeriesEVerAMensagem(string p0)
        {
            //var mensagem = WeBrowser.Current.Text;
            //Assert.IsTrue(mensagem.Contains("com sucesso!"));
            
            Assert.That(WeBrowser.Current.ContainsText("com sucesso!"));

            var currentUrlPath = WeBrowser.Current.Uri.PathAndQuery;
            Assert.That(currentUrlPath, Is.EqualTo("/AnoSerie"));
            
        }
    }
}
