using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace InfoTrackRanking.Services
{
    public class GoogleScraperService : IScraperService
    {
        const string iTUrl = "https://www.infotrack.co.uk";

        public async Task<List<int>> Scrape(string url)
        {
            List<int> positions = new List<int>();

            ChromeOptions chromeOptions = GetChromeOptions();

            using (IWebDriver driver = new ChromeDriver(chromeOptions))
            {
                await driver.Navigate().GoToUrlAsync(url);

                MimicUserInteraction(driver);

                // Extract search result elements (links of each search result)
                var searchResults = driver.FindElements(By.CssSelector("div.MjjYud span a")); // Adjust selector if needed

                int position = 1;
                foreach (var result in searchResults)
                {
                    string resultText = result.GetAttribute("href");

                    // Check if the InfoTrack URL appears in the result
                    if (string.IsNullOrEmpty(resultText) == false && resultText.TrimStart().StartsWith(iTUrl))
                    {
                        positions.Add(position);
                    }
                    position++;
                }
                return positions;
            }
        }

        private ChromeOptions GetChromeOptions()
        {
            // Set Chrome options to prevent google from detecting automation
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.84 Safari/537.36");
            chromeOptions.AddArgument("--headless=new");
            chromeOptions.AddArgument("--disable-gpu");
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--disable-dev-shm-usage");
            chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
            chromeOptions.AddExcludedArguments("enable-automation");
            return chromeOptions;
        }

        private void MimicUserInteraction(IWebDriver driver)
        {
            // Random delay to simulate human browsing
            Random rand = new Random();
            Thread.Sleep(rand.Next(1000, 2000));

            // Scroll down to mimic user interaction
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,1000);");
            Thread.Sleep(rand.Next(1000, 2000));
        }
    }
}
