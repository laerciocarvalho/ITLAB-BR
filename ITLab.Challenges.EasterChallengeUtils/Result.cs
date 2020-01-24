using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLab.Challenges.EasterChallengeUtils
{
    public class Result
    {
        public int HttpStatusCode { get; set; }
        public string HttpStatusCodeDescription { get; set; }
        public object Return { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsSuccessful { get; set; }
        public string Caller { get; set; }
        public List<string> AdditionalInfo { get; set; }

        public void Log()
        {
            string subject = Caller;
            string caminhoArquivoLog = ConfigurationManager.AppSettings["BrasilRisk.Marfrig.Tms.Log.Path"];
            string logFile = string.Format("{0}{1}.txt", caminhoArquivoLog, subject);

            Logger.Log(logFile, this);
        }

        public void Log(string source)
        {
            string subject = Caller + "." + source;
            string caminhoArquivoLog = ConfigurationManager.AppSettings["BrasilRisk.Marfrig.Tms.Log.Path"];
            string logFile = string.Format("{0}{1}.txt", caminhoArquivoLog, subject);

            Logger.Log(logFile, this);
        }
    }
}