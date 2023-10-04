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

        /*protected async override void OnSleep()
        {
            base.OnSleep();
            await AppVM.ToDosManagerVM.SaveToDatabase();
        }*/

        // I would like to do it on QUIT/DESTROY but it doesn't even exist in MAUI
    }
}