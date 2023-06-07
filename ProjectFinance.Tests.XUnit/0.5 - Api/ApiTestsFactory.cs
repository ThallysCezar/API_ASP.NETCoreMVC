

using Microsoft.AspNetCore.Mvc.Testing;

namespace ProjectFinance.Tests.XUnit._0._5___Api
{
    public class ApiTestsFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
    }
}
