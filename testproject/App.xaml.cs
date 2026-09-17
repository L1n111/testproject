namespace testproject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Services.DataRepo.Init();
            MainPage = new AppShell();
        }
    }
}
