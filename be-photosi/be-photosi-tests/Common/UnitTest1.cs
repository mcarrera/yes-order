using be_photosi_api.Common;
using Xunit;
namespace be_photosi_tests.Common
{
    public class UnitTest1
    {
        [Fact]
        public void GetEnvironmentVariables()
        {
            var connectionstring = EnvironmentVariables.GetDatabaseConnection();

            Assert.NotNull(connectionstring);
        }
    }
}