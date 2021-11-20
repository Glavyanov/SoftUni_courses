namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }

        public int MaxValue
        {
            get { return maxValue; }
            private set { maxValue = value; }
        }

        public int MinValue
        {
            get { return minValue; }
            private set { minValue = value; }
        }

        public override bool IsValid(object obj)
        {
            if ((int)obj < this.MinValue || (int)obj > this.MaxValue)
            {
                return false;
            }

            return true;
        }


    }
}
