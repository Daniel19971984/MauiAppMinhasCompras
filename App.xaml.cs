using MauiAppMinhasCompras.Helpers;

namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {

        static SQLiteDatabaseHelper _DB;

        public static SQLiteDatabaseHelper DB 
        { 
             get 

             {
                  if(_DB ==null)
                  {
                    string path = Path.Combine(Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData),
                 "banco_sqlite_compras.db3");
                  
                    _DB = new SQLiteDatabaseHelper(path);
                  }

                return _DB; 
            
             } 
        
        }
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}
