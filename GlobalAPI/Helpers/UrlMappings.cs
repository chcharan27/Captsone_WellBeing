namespace GlobalAPI.Helpers
{
    public static class UrlMappings
    {
        public static readonly Dictionary<string, string> BaseUrls = new()
        {
            { "Auth", "AuthAPI" },
            { "MindCare", "MindCareAPI" },
            { "Contacts", "EmergencyContactAPI" },
            { "Alerts", "SafetyAlertAPI" }
        };
    }
}
