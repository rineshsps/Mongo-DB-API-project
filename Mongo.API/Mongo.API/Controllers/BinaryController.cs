using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace Mongo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinaryController : ControllerBase
    {
        private readonly ILogger<BinaryController> _logger;

        public BinaryController(ILogger<BinaryController> logger)
        {
            this._logger = logger;
        }
        /// <summary>
        /// Enter binary string
        /// </summary>
        /// <param name="value">binary string</param>
        /// <returns></returns>
        //[HttpGet]
        [HttpGet()]
        [Route("ValidateBinary")]
        public bool Get([Required][StringLength(50, MinimumLength = 2, ErrorMessage = "Please add min two charater")] string value)
        {
            return ValidateBinary(value);
        }

        private bool ValidateBinary(string value)
        {
            int result = 0, count1 = 0, count0 = 0;

            for (int i = 0; i < value.Length; i++)
            {
                // Validate the value is '0' || '1'
                if (value[i] == '1')
                {
                    count1++;
                }
                else if (value[i] == '0')
                {
                    count0++;
                }
                else
                {
                    _logger.LogInformation($"Validation failed, value contains {value[i]}");

                    return false;
                }

                if (count1 == count0)
                {
                    result++;
                }
            }

            // Validate the binary value
            if (result == 0 || count1 != count0)
            {
                _logger.LogInformation($"Validation failed {result}; count 1 {count1} - count0 { count0} ");
                return false;
            }

            _logger.LogInformation($"Validation succeed {result}; count1 is {count1} - count0 is { count0}");

            return true;
        }
    }
}
