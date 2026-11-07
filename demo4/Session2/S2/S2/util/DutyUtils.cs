using System;

namespace S2.util
{
    /// <summary>
    /// Duty calculation rules (same as Session1):
    /// duty = hsRate x amount + countryRate x amount.
    /// Country rate 0% => no duty; Bonded => 0; Processing Trade => 50%.
    /// </summary>
    public static class DutyUtils
    {
        public static decimal CalcDuty(decimal hsRate, decimal countryRate, string tradeModeName, decimal cargoAmount)
        {
            if (countryRate == 0) return 0;
            if (tradeModeName == "Bonded" || tradeModeName == "Bonded Trade") return 0;

            decimal duty = cargoAmount * hsRate + cargoAmount * countryRate;

            if (tradeModeName == "Processing Trade")
            {
                duty = duty * 0.5m;
            }
            return Round2(duty);
        }

        /// <summary>Round a value to two decimal places</summary>
        public static decimal Round2(decimal value)
        {
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }
    }
}
