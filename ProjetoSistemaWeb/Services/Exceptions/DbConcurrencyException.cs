namespace ProjetoSistemaWeb.Services.Exceptions
{
    public class DbConcurrencyException : Exception
    {
        public DbConcurrencyException(string message) : base(message)
        {

        }
    }
}
