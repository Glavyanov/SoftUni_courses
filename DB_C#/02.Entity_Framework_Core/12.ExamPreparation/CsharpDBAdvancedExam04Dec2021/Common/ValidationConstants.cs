namespace Theatre.Common
{
    public static class ValidationConstants
    {
        //Theatre
        public const int TheatreNameMinLength = 4;
        public const int TheatreNameMaxLength = 30;
        public const string TheatreNumberOfHallsMinRange = "1";
        public const string TheatreNumberOfHallsMaxRange= "10";
        public const int TheatreDirectorMinLength = 4;
        public const int TheatreDirectorMaxLength = 30;

        //Play
        public const int PlayTitleMinLength = 4;
        public const int PlayTitleMaxLength = 50;
        public const int PlayScreeenwriterMinLength = 4;
        public const int PlayScreeenwriterMaxLength = 30;
        public const int PlayDescriptionMaxLength = 700;

        //Cast
        public const int CastFullNameMinLength = 4;
        public const int CastFullNameMaxLength = 30;

        //Ticket
        public const string TicketPriceMinRange = "1.00";
        public const string TicketPriceMaxRange = "100.00";
        public const string TicketRowNumberMinRange = "1";
        public const string TicketRowNumberMaxRange = "10";


    }
}
