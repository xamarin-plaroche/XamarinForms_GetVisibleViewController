using Xamarin.Forms;

namespace VisibleViewController
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new VisibleViewControllerPage();

            //MainPage = new NavigationPage(new TestsPage());

            var tabP = new TabbedPage();
            tabP.Children.Add(new NavigationPage(new VisibleViewControllerPage()));
            var p2 = new SecondVisibleViewControllerPage();
            tabP.Children.Add(p2);
            tabP.CurrentPage = p2;
            //MainPage = tabP;

            //MainPage = new MasterDetailPage()
            //{
            //    Master = new VisibleViewControllerPage() { Title = "Menu" },
            //    Detail = new NavigationPage(new SecondVisibleViewControllerPage())
            //};

            MainPage = new MasterDetailPage()
            {
                Master = new VisibleViewControllerPage() { Title = "Menu" },
                Detail = new NavigationPage(tabP)
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
