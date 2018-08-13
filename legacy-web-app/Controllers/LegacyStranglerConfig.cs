namespace legacy_web_app.Controllers
{
    public class LegacyStranglerConfig
    {
        private LegacyStranglerConfig()
        {
            NewApp = "http://localhost:4200/";
        }

        public string NewApp { get; set; }

        public static LegacyStranglerConfig Instance { get; } = new LegacyStranglerConfig();
    }
}