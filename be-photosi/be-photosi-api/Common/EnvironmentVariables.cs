namespace be_photosi_api.Common
{
    public class EnvironmentVariables
    {
        public static string GetDatabaseConnection()
        {
            List<string> parameters = new();

            var server = Environment.GetEnvironmentVariable("DB_HOST") ?? "";
            var database = Environment.GetEnvironmentVariable("DB_NAME") ?? "";
            var user = Environment.GetEnvironmentVariable("DB_USER") ?? "";
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "";

            parameters.Add($"Server={server}");
            parameters.Add($"Database={database}");
            parameters.Add($"User Id={user}");
            parameters.Add($"Password={password}");

            return string.Join(";", parameters);
        }
    }
}
