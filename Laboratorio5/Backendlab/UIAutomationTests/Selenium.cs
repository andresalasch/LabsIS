using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
namespace UIAutomationTests
{
    public class Selenium
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new FirefoxDriver();
        }

        [Test]
        public void Enter_To_List_Of_Countries_Test()
        {
            var URL = "http://localhost:8080/";
            var AddCountryURL = "http://localhost:8080/pais";
            var country = "Sudafrica";
            var continent = "África";
            var language = "English";

            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(AddCountryURL);
            Thread.Sleep(1000);

            var nameInput = _driver.FindElement(By.Id("name"));
            nameInput.SendKeys(country);
            Thread.Sleep(1000);

            var idiomaInput = _driver.FindElement(By.Id("idioma"));
            idiomaInput.SendKeys(language);
            Thread.Sleep(1000);

            var continenteSelect = new SelectElement(_driver.FindElement(By.Id("continente")));
            continenteSelect.SelectByText(continent);
            Thread.Sleep(1000);

            var submitButton = _driver.FindElement(By.XPath("//button[contains(text(), 'Guardar')]"));
            submitButton.Submit();
            Thread.Sleep(1000);


            _driver.Navigate().GoToUrl(URL);
            Thread.Sleep(10000);

            var tableBody = _driver.FindElement(By.Id("tabla"));
            var lastRow = tableBody.FindElements(By.TagName("tr")).Last();

            var cells = lastRow.FindElements(By.TagName("td"));
            var lastCountryName = cells[0].Text;
            var lastCountryContinent = cells[1].Text;

            Assert.AreEqual(country, lastCountryName);
            Assert.AreEqual(continent, lastCountryContinent);
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}