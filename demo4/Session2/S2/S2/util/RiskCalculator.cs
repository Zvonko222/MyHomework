namespace S2.util
{
    public static class RiskCalculator
    {
        public const int HighRiskScore = 30;

        public static int Calculate(string rating, string riskGrade, bool hasExceptionIn12Months)
        {
            int ratingRisk = rating == "AEO Advanced" ? -20
                : rating == "AEO General" ? -10
                : rating == "Discredited" ? 30
                : 0;
            int hsRisk = riskGrade == "High" ? 20
                : riskGrade == "Middle" ? 10
                : 0;
            int historyRisk = hasExceptionIn12Months ? 30 : -5;
            return ratingRisk + hsRisk + historyRisk;
        }
    }
}
