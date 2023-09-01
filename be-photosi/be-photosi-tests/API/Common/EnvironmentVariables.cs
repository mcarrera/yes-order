using Xunit.Sdk;

namespace be_photosi_tests.API.Common
{
    public class EnvironmentVariables
    {
        [Fact]
        public void GetEnvironmentVariables()
        {
            var connectionString = be_photosi_api.Common.EnvironmentVariables.GetDatabaseConnection();
            Assert.NotNull(connectionString);
            throw new SkipException("Test method is inconclusive");
        }
    }
}