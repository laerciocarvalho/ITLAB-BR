using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITLab.Challenges.EasterChallengeModels
{
    [KnownType(typeof(ITLab.Challenges.EasterChallengeModels.EasterDateSummary))]
    public class EasterDateSummary
    {
        public string EasterDatePortugueseShort { get; set; }
        public string EasterDatePortugueseLong { get; set; }
    }
}
