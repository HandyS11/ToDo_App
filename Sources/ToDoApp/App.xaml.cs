using ToDoApp.ViewModels;

namespace ToDoApp
{
    public partial class App : Application
    {
        public AppVM AppVM { get; private set; }

        public App(AppVM appVM)
        {
            InitializeComponent();
            MainPage = new AppShell();

            AppVM = appVM;
        }
    }
}