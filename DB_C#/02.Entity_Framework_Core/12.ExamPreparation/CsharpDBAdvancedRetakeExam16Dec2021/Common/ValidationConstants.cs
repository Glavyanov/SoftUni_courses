namespace Artillery.Common
{
    public static class ValidationConstants
    {
        //Country
        public const int CountryNameMinLength = 4;
        public const int CountryNameMaxLength = 60;
        public const int CountryArmySizeMaxLength = 10000000;
        public const int CountryArmySizeMinLength = 50000;

        //Manufacturer
        public const int ManufacturerNameMaxLength = 40;
        public const int ManufacturerNameMinLength = 4;
        public const int ManufacturerFoundedMinLength = 10;
        public const int ManufacturerFoundedMaxLength = 100;

        //Shell
        public const double ShellWeightMinValue = 2;
        public const double ShellWeightMaxValue = 1680;
        public const int ShellCaliberMaxLength = 30;
        public const int ShellCaliberMinLength = 4;

        //Gun
        public const int GunWeightMaxValue = 1350000;
        public const int GunWeightMinValue = 100;
        public const double GunBarrelLengthMinValue = 2.00;
        public const double GunBarrelLengthMaxValue = 35.00;
        public const int GunRangeMinValue = 1;
        public const int GunRangeMaxValue = 100000;



    }
}
