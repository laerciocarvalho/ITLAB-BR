using ITLab.Challenges.EasterChallengeUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;

namespace ITLab.Challenges.EasterChallengeWebApi.Controllers
{
    public class EasterChallengeController : ApiController
    {
        [HttpGet]
        [Route("api/v1/easterchallenge/calculate/{year}")]
        public HttpResponseMessage Calculate(int year)
        {
            ITLab.Challenges.EasterChallengeInfra.Calculator calculator = new EasterChallengeInfra.Calculator();
            Result calculate = calculator.Calculate(year);

            if (!calculate.IsSuccessful)
            {
                calculate.HttpStatusCode = 400;
                calculate.HttpStatusCodeDescription = "400 Bad Request";
                return Request.CreateResponse(HttpStatusCode.BadRequest, calculate);
            }

            calculate.HttpStatusCode = 200;
            calculate.HttpStatusCodeDescription = "200 OK";

            return Request.CreateResponse(HttpStatusCode.OK, calculate);
        }
    }
}
