namespace DataModel
{
    public static class Role
    {
        public const string Admin = "admin";
        public const string User = "user";
    }

    public class MessageInstance
    {
        public string Timestamp { get; set; }
        public string From { get; set; }
        public string Message { get; set; }
    }
}