using ITLab.Challenges.EasterChallengeInfra;
using ITLab.Challenges.EasterChallengeModels;
using ITLab.Challenges.EasterChallengeUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;

namespace ITLab.Challenges.EasterChallengeWebService
{
    /// <summary>
    /// Summary description for EasterChallenge
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class EasterChallenge : System.Web.Services.WebService
    {
        [WebMethod(Description = "Inform a year so the calculator can show us on which day Easter Bunny showed up.")]
        [XmlInclude(typeof(ITLab.Challenges.EasterChallengeModels.EasterDateSummary))]
        public Result Calculate(int year)
        {
            return new Calculator().Calculate(year);
        }
    }
}
