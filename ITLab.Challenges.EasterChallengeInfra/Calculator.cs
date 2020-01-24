using ITLab.Challenges.EasterChallengeUtils;
using ITLab.Challenges.EasterChallengeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLab.Challenges.EasterChallengeInfra
{
    public class Calculator
    {
        const int FirstCouncilOfNicaea = 325;
        const int EndOfWorld = 2120;
        public Result Calculate(int year)
        {
            Result result = new Result();
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            result.Caller = string.Format("{0}.{1}", method.ReflectedType.FullName, method.Name);
            result.IsSuccessful = false;
            result.AdditionalInfo = new List<string>();

            int httpStatusCode = 0;
            string httpStatusCodeDescription = string.Empty;

            try
            {
                EasterDateSummary summary = new EasterDateSummary();
                summary.EasterDatePortugueseShort = string.Empty;
                summary.EasterDatePortugueseLong = string.Empty;

                // Begin of validations pipeline
                bool isValid = true;
                string errorMessage = string.Empty;

                if (year < FirstCouncilOfNicaea)
                {
                    isValid = false;
                    errorMessage = "You kidding... at that time, Easter wasn't even invented yet.";
                }

                if (year > EndOfWorld)
                {
                    isValid = false;
                    errorMessage = "Hmmm... the human race may disappear far before that. But congrats. You look quite optimist.";
                }

                if (!isValid)
                {
                    result.ErrorMessage = errorMessage;
                    result.Return = summary;
                    return result;
                }
                // End of validations pipeline

                int nRest = (year % 19) + 1;
                DateTime day = new DateTime();
                switch (nRest)
                {
                    case 1: day = new System.DateTime(year, 4, 14, 0, 0, 0, 0); break;
                    case 2: day = new System.DateTime(year, 4, 3, 0, 0, 0, 0); break;
                    case 3: day = new System.DateTime(year, 3, 23, 0, 0, 0, 0); break;
                    case 4: day = new System.DateTime(year, 4, 11, 0, 0, 0, 0); break;
                    case 5: day = new System.DateTime(year, 3, 31, 0, 0, 0, 0); break;
                    case 6: day = new System.DateTime(year, 4, 18, 0, 0, 0, 0); break;
                    case 7: day = new System.DateTime(year, 4, 8, 0, 0, 0, 0); break;
                    case 8: day = new System.DateTime(year, 3, 28, 0, 0, 0, 0); break;
                    case 9: day = new System.DateTime(year, 4, 16, 0, 0, 0, 0); break;
                    case 10: day = new System.DateTime(year, 4, 5, 0, 0, 0, 0); break;
                    case 11: day = new System.DateTime(year, 3, 25, 0, 0, 0, 0); break;
                    case 12: day = new System.DateTime(year, 4, 13, 0, 0, 0, 0); break;
                    case 13: day = new System.DateTime(year, 4, 2, 0, 0, 0, 0); break;
                    case 14: day = new System.DateTime(year, 3, 22, 0, 0, 0, 0); break;
                    case 15: day = new System.DateTime(year, 4, 10, 0, 0, 0, 0); break;
                    case 16: day = new System.DateTime(year, 3, 30, 0, 0, 0, 0); break;
                    case 17: day = new System.DateTime(year, 4, 17, 0, 0, 0, 0); break;
                    case 18: day = new System.DateTime(year, 4, 7, 0, 0, 0, 0); break;
                    case 19: day = new System.DateTime(year, 3, 27, 0, 0, 0, 0); break;
                }

                for (int n = 1; n <= 13; n++)
                {
                    day = day.AddDays(1);

                    if (day.DayOfWeek == DayOfWeek.Sunday)
                    {
                        string month = day.Month == 3 ? "março" : "abril";

                        summary.EasterDatePortugueseShort = DateTime.Parse(day.ToString(), new System.Globalization.CultureInfo("pt-BR")).ToString();
                        summary.EasterDatePortugueseLong = string.Format("Domingo, {0} de {1} de {2}", day.Day.ToString(), month, year.ToString());

                        break;
                    }
                }

                result.IsSuccessful = true;
                result.Return = summary;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.ToString();
            }
            finally
            {
                result.HttpStatusCode = httpStatusCode;
                result.HttpStatusCodeDescription = httpStatusCodeDescription;
            }

            return result;
        }
    }
}
