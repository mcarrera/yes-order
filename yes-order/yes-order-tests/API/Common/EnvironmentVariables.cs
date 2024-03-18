using AutoFixture;
using Xunit.Sdk;

namespace yes_orders_tests.API.Common
{
    public class EnvironmentVariables
    {
        
        [Fact]
        public void GetDatabaseConnection_ReturnsString()
        {
            // Arrange
            Environment.SetEnvironmentVariable("DB_HOST", "DB_HOST");
            Environment.SetEnvironmentVariable("DB_NAME", "DB_NAME");
            Environment.SetEnvironmentVariable("DB_USER", "DB_USER");
            Environment.SetEnvironmentVariable("DB_PASSWORD", "DB_PASSWORD");
            // Act
            var connectionString = yes_orders_api.Common.EnvironmentVariables.GetSQLDatabaseConnection();
            // Assert
            Assert.NotEmpty(connectionString);
        }

     

        [Fact(Skip ="Exception to be revised")]
        public void GetDatabaseConnection_MissingEnvironmentVariable_ThrowsException()
        {
            // Arrange
            Environment.SetEnvironmentVariable("DB_HOST", null);
            Environment.SetEnvironmentVariable("DB_NAME", "DB_NAME");
            Environment.SetEnvironmentVariable("DB_USER", "DB_USER");
            Environment.SetEnvironmentVariable("DB_PASSWORD", "DB_PASSWORD");

            // Act and Assert
            Assert.Throws<Exception>(() =>
            {
                yes_orders_api.Common.EnvironmentVariables.GetSQLDatabaseConnection();
            });
        }


    }
}