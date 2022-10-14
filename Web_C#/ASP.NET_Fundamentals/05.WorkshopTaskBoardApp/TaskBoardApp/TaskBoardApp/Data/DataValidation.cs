namespace TaskBoardApp.Data
{
    public static class DataValidation
    {
        public static class UserConstants
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 15;
            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 15;
            public const int UserNameMinLength = 2;
            public const int UserNameMaxLength = 15;
        }

        public static class TaskConstants
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 70;
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 1000;
        }

        public static class BoardConstants
        {

            public const int BoardNameMinLength = 3;
            public const int BoardNameMaxLength = 30;
        }
    }
}
