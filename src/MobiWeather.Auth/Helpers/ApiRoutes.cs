namespace MobiWeather.Auth.WebApi.Helpers
{
    public static class ApiRoutes
    {
        private const string Root = "api";

        public static class User
        {
            public const string Login = Root + "/user/login";
            public const string Register = Root + "/user/register";
        }
    }
}