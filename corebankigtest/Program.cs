using corebankigtest;
using corebankigtest.DAL;
using corebankigtest.BLL;
using corebankigtest.DAL.Abstractions;
using corebankigtest.DAL.Factories;
using System.Configuration;
internal static class Program
{
    [STAThread]
    static void Main()
    {
        try
        {
            ApplicationConfiguration.Initialize();

            string provider = ConfigurationManager.AppSettings["DbProvider"];
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

            IDConnectionFactory factory;

            if (provider == "SqlServer")
                factory = new SqlConnectionFactory(cs);
            else
                factory = new SqliteConnectionFactory(cs);

            var  repository = new AccountRepository(factory);
            var accountService=new AccountService(repository);
            var transactionService = new TransactionService();

            Application.Run(new LoginForm(accountService,transactionService));
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Startup Error");
        }
    }
}
        
    
