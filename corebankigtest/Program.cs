using CoreBanking.BusinessLogic;
using CoreBanking.DataAccess;
using CoreBanking.DataAccess.Abstractions;
using System.Configuration;
using CoreBanking.DataAccess.Factories;


internal static class Program
{
    [STAThread]
    static void Main()
    {
        try
        {
            ApplicationConfiguration.Initialize();

            string provider = ConfigurationManager.AppSettings["DbProvider"]?? string.Empty;
            string cs = ConfigurationManager.ConnectionStrings["dbcs"]?.ConnectionString?? throw new Exception("Connection string not found");

            IDConnectionFactory factory;

            if (provider == "SqlServer")
                factory = new SqlConnectionFactory(cs);
            else
                factory = new SqliteConnectionFactory(cs);

            var accountrepository = new AccountRepository(factory);
            var accountService = new AccountService(accountrepository);
            var transactionRepository = new TransactionRepository(factory);
            var transactionService = new TransactionService(transactionRepository);

            Application.Run(new corebankigtest.LoginForm(accountService, transactionService));
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Startup Error");
        }
    }
}


