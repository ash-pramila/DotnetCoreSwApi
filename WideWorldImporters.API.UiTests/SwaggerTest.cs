using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]     
    class Program {
        private IWebDriver driver {get; set;}
        private String _url = "https://dotnetcoreswapi.azurewebsites.net/swagger/index.html";      
    
    [SetUp]
    public void SetupTest()
    {                   
        //Configuration to Windows
        //  String driverPath = @"D:\Projetos\VsCode\SeleniumDotNetCore\bin\Debug\netcoreapp2.1";
        //  String driverExecutableFileName = "chromedriver.exe";         
        //  ChromeOptions options = new ChromeOptions();
        //  options.AddArguments("window-size=1200x600");      
        //Configuration to Linux - Container
        String driverPath = "/opt/selenium/";
        String driverExecutableFileName = "chromedriver";
        //String driverPath = @"/home/pramilaraju/softwares/chromedriverlinux64"; 
        //Give the path of the geckodriver.exe    
        //FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"/home/pramilaraju/softwares/geckodriver-v0.26.0-linux64","geckodriver");
        //Give the path of the Firefox Browser        
        //service.FirefoxBinaryPath = @"/opt/google/chrome/chrome";
        //IWebDriver driver = new FirefoxDriver(service);
        //driver.Navigate().GoToUrl("https://www.google.com");
        ChromeDriverService service = ChromeDriverService.CreateDefaultService(driverPath,driverExecutableFileName);
        ChromeOptions options = new ChromeOptions();
        options.AddArguments("headless");
        options.AddArguments("no-sandbox");        
        options.BinaryLocation = @"/opt/google/chrome/chrome";
        driver = new ChromeDriver(service, options,TimeSpan.FromSeconds(30));
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
        driver.Manage().Window.Maximize();                    
    }

    [TearDown]
    public void TeardownTest()
    {
       driver.Quit();
    }

    [Test]
    public void testMethod()
    {   
        try{

            this.driver.Navigate().GoToUrl(this._url);
            var swaggerText = driver.FindElement(By.XPath("/html/body/div/section/div[1]/div/div/a/span")).Text;
            Console.WriteLine(swaggerText);
            Assert.AreEqual("swagger", swaggerText);
            var apiText = driver.FindElement(By.XPath("/html/body/div/section/div[2]/div[2]/div[4]/section/div/span/div/h4/a/span")).Text;
            Console.WriteLine(apiText); 
            Assert.AreEqual("Warehouse",apiText);                                      
            /*IWebElement bodyElement = this.driver.FindElement(By.XPath("//div[contains(@class,'main-header')]/h2"));
            String strContent= bodyElement.GetAttribute("textContent");
            Assert.AreEqual("A JQuery plugin to create AJAX based CRUD tables." , strContent);*/

        
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.ToString());
        }      
    }

}
}
