namespace ASP_Web_Api.Models
{
    public class DbSetting
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string AccountCollection { get; set; } = null!;
    }
}
