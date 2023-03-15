using Microsoft.Win32;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KillTarget
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void importSockClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = @"C:\txt"; 
            openFile.Filter = "Text Files Only (*.txt) | *.txt";
            openFile.DefaultExt = "txt";
            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = openFile.ShowDialog();
            if (openFile.ShowDialog() == true)
            {
                listBoxSock.Items.Clear();
                // load the lines to the list box
                List<string> lines = new List<string>();
                using (StreamReader r = new StreamReader(openFile.OpenFile()))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        listBoxSock.Items.Add(line);

                    }
                }
            }
        }

        private void bttImportKeyword(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = @"C:\txt"; 
            openFile.Filter = "Text Files Only (*.txt) | *.txt";
            openFile.DefaultExt = "txt";
            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = openFile.ShowDialog();
            if (openFile.ShowDialog() == true)
            {
                listboxKeyword.Items.Clear();
                // load the lines to the list box
                List<string> lines = new List<string>();
                using (StreamReader r = new StreamReader(openFile.OpenFile()))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        listboxKeyword.Items.Add(line);

                    }
                }
            }
        }

        private void bttTargetDomain(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = @"C:\txt"; 
            openFile.Filter = "Text Files Only (*.txt) | *.txt";
            openFile.DefaultExt = "txt";
            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = openFile.ShowDialog();
            if (openFile.ShowDialog() == true)
            {
                listBox3.Items.Clear();
                // load the lines to the list box
                List<string> lines = new List<string>();
                using (StreamReader r = new StreamReader(openFile.OpenFile()))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        listBox3.Items.Add(line);

                    }
                }
            }
        }

        private void bttStart(object sender, RoutedEventArgs e)
        {
            string currentdate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            foreach (string item in listBoxSock.Items)
            {
                listBox2.Items.Add(currentdate + " | " + item.ToString()); 
            } 
            _ = StartBrowser( "laptop chính hãng");
        }

        //* Xu ly viec start chrome
        public async Task StartBrowser(string keyword )
        {
            await Task.Run(() =>
            {
                ChromeOptions op = InitializeOptions();
                //var chromeDriverService = ChromeDriverService.CreateDefaultService();
                //chromeDriverService.HideCommandPromptWindow = true;
                ChromeDriver driver = new ChromeDriver("chromedriver.exe", op, TimeSpan.FromSeconds(30));
                // Add optional driver handling procedures (like timeout management)
                driver.Navigate().GoToUrl("https://www.google.com"); 
            });
        }

        private ChromeOptions InitializeOptions()
        {
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--headless");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--safebrowsing-disable-download-protection");
            options.AddArguments("no-sandbox");
            options.AddArgument("enable-automation");
            options.AddArgument("test-type=browser");
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("safebrowsing", "enabled");
            options.AddUserProfilePreference("disable-popup-blocking", "true");
            // Your set of options
            return options;
        } 

        public async Task CloseBrowser(ChromeDriver driver)
        {
            await Task.Run(() => driver.Quit());
        }
    }
}
