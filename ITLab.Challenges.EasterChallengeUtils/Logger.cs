using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ITLab.Challenges.EasterChallengeUtils
{
    public enum LogCategory
    {
        INFO, WARN, ERROR, DEBUG
    }
    public class Logger
    {
        public static void Log(string logFilePath, string origem, LogCategory categoria, string mensagem)
        {
            try
            {
                FileInfo fi = new FileInfo(logFilePath);

                if (fi.Exists)
                {
                    if (fi.Length > 10485760)
                    {
                        fi.Delete();
                    }
                }

                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine(string.Format("{0} - {1} - {2} - {3}", DateTime.Now, origem, categoria, mensagem));
                    writer.Flush();
                }
            }
            catch
            {
            }
        }

        public static void Log(string logFilePath, Result resultado)
        {
            try
            {
                FileInfo fi = new FileInfo(logFilePath);

                if (fi.Exists)
                {
                    if (fi.Length > 10485760)
                    {
                        fi.Delete();
                    }
                }

                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    StringBuilder mensagem = new StringBuilder();
                    mensagem.AppendFormat("{0}", DateTime.Now);
                    mensagem.Append(" - ");
                    mensagem.AppendFormat("{0}", resultado.IsSuccessful ? LogCategory.INFO : LogCategory.ERROR);
                    mensagem.Append(" - ");
                    mensagem.AppendFormat("{0}", resultado.Caller);

                    if (resultado.IsSuccessful)
                    {
                        mensagem.Append(" - ");
                        mensagem.Append("Sucesso.");
                    }
                    else if (!resultado.IsSuccessful && !string.IsNullOrEmpty(resultado.ErrorMessage))
                    {
                        mensagem.Append(" - ");
                        mensagem.AppendFormat("Erro (gravidade descrita a seguir) {0}", resultado.ErrorMessage);
                    }
                    else
                    {
                        mensagem.Append(" - ");
                        mensagem.Append("Erro (sem gravidade).");
                    }

                    if (resultado.AdditionalInfo != null && resultado.AdditionalInfo.Count > 0)
                    {
                        mensagem.Append(Environment.NewLine);
                        mensagem.Append("O processamento também considera os dados abaixo relevantes para análise:");
                        mensagem.Append(Environment.NewLine);

                        int infoCounter = 1;
                        foreach (string additionalInfo in resultado.AdditionalInfo)
                        {
                            mensagem.AppendFormat("{0}. {1}", infoCounter, additionalInfo);
                            mensagem.Append(Environment.NewLine);
                            infoCounter++;
                        }
                    }

                    writer.WriteLine(mensagem.ToString());
                    writer.Flush();
                }
            }
            catch
            {
            }
        }
    }
}
