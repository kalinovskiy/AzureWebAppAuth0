namespace Common
{
    public class Constants
    {
        public const string AUTH0_CLIENT_ID = "";

        public const string AUTH0_CLIENT_SECRET = "";

        public const string AUTH0_SITE_URL = "https://kalinovskiy.eu.auth0.com";

        public const string AUTH0_API_AUDIENCE = "https://kalinovskiy.eu.auth0.com/api/v2/";

        public const string AUTH0_API_AUTHORITY = AUTH0_SITE_URL;

        public static string AUTH0_AUTH_URL => $"{AUTH0_SITE_URL}/authorize?" +
                                               $"audience={AUTH0_API_AUDIENCE}&" +
                                               $"response_type=code&" +
                                               $"client_id={AUTH0_CLIENT_ID}&" +
                                               $"redirect_uri={CALLBACK_URL}&" +
                                               $"scope=openid";

        public static string AUTH0_LOGOUT_URL => $"{AUTH0_SITE_URL}/v2/logout?" +
                                                 $"client_id={AUTH0_CLIENT_ID}&" +
                                                 $"returnTo=https://localhost:44362";

        public static string AUTH0_TOKEN_URL => $"{AUTH0_SITE_URL}/oauth/token";
        
        public const string CALLBACK_URL = "https://localhost:44362/auth/callback";

        public const string EXECUTE_URL = "https://localhost:44364/api/value";
    }
}
