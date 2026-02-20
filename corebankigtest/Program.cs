using corebankigtest;
using corebankigtest.BLL;
using corebankigtest.DAL.Abstractions;
using corebankigtest.DAL.Factories;
using System.Configuration;
using System.Linq.Expressions;
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

            var accountService = new AccountService(factory);

            Application.Run(new LoginForm(accountService));
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Startup Error");
        }
    }
}
        
    
