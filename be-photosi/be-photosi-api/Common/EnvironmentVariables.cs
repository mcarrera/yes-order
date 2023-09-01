namespace be_photosi_api.Common
{
    public class EnvironmentVariables
    {
        public static string GetDatabaseConnection()
        {
            List<string> parameters = new();

            var server = Environment.GetEnvironmentVariable("DB_HOST");
            var database = Environment.GetEnvironmentVariable("DB_NAME");
            var user = Environment.GetEnvironmentVariable("DB_USER");
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

            if (string.IsNullOrWhiteSpace(server)) ThrowEnvironmentVariableMissingException("DB_HOST");
            if (string.IsNullOrWhiteSpace(database)) ThrowEnvironmentVariableMissingException("DB_NAME");
            if (string.IsNullOrWhiteSpace(user)) ThrowEnvironmentVariableMissingException("DB_USER");
            if (string.IsNullOrWhiteSpace(password)) ThrowEnvironmentVariableMissingException("DB_PASSWORD");
          

            parameters.Add($"Server={server}");
            parameters.Add($"Database={database}");
            parameters.Add($"User Id={user}");
            parameters.Add($"Password={password}");

            return string.Join(";", parameters);
        }

        private static void ThrowEnvironmentVariableMissingException(string variableName)
        {
            throw new Exception($"Environment variable \"{variableName}\" is missing");
        }
    }
}
