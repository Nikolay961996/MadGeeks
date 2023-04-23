namespace Mad.Api
{
    public class CorrectSummaries
    {
        public int CalculateIndex(int temperature)
        {
            int index = 0;

            switch (temperature)
            {
                case -30:
                    index = 0;
                    break;
                case > -30 when temperature < -20:
                    index = 1;
                    break;
                case >= -20 when temperature < -10:
                    index = 2;
                    break;
                case >= -10 when temperature < 0:
                    index = 3;
                    break;
                case 0:
                    index = 4;
                    break;
                case > 0 when temperature < 10:
                    index = 5;
                    break;
                case >= 10 when temperature < 20:
                    index = 6;
                    break;
                case >= 20 when temperature < 30:
                    index = 7;
                    break;
                case >= 30 when temperature < 40:
                    index = 8;
                    break;
                case 40:
                    index = 9;
                    break;
            }

            return index;
        }
    }
}
