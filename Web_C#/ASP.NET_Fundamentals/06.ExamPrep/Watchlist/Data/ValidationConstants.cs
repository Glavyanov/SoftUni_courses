namespace Watchlist.Data
{
    public static class ValidationConstants
    {
        public static class MovieConstants
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;

            public const int DirectorMinLength = 5;
            public const int DirectorMaxLength = 50;

            public const decimal RatingMinRange = 0.00M;
            public const decimal RatingMaxRange = 10.00M;
        }

        public static class GenreConstants
        {

            public const int NameMinLength = 5;
            public const int NameMaxLength = 50;
        }

        public static class UserConstants
        {

            public const int NameMinLength = 5;
            public const int NameMaxLength = 20;

            public const int EmailMinLength = 10;
            public const int EmailMaxLength = 60;

            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 20;
        }
    }
}
