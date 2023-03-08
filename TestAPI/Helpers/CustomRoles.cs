namespace TestAPI.Helpers
{
    public class CustomRoles
    {
        private const string ADMIN = "Admin";
        private const string USER = "User";

        public const string USER_ROLE = USER;
        public const string ADMIN_ROLE = ADMIN;
        public const string ALL_ROLES = ADMIN + "," + USER;
    }
}
