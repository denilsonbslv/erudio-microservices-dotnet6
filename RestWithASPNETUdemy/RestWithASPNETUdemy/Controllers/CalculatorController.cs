using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Helpers;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (Helper.IsNumeric(firstNumber) && Helper.IsNumeric(secondNumber))
            {
                var sum = Helper.ConvertToDecimal(firstNumber) + Helper.ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input.");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if (Helper.IsNumeric(firstNumber) && Helper.IsNumeric(secondNumber))
            {
                var div = Helper.ConvertToDecimal(firstNumber) / Helper.ConvertToDecimal(secondNumber);
                return Ok(div.ToString());
            }
            return BadRequest("Invalid Input.");
        }
    
        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult Mult(string firstNumber, string secondNumber)
        {
            if (Helper.IsNumeric(firstNumber) && Helper.IsNumeric(secondNumber))
            {
                var div = Helper.ConvertToDecimal(firstNumber) * Helper.ConvertToDecimal(secondNumber);
                return Ok(div.ToString());
            }
            return BadRequest("Invalid Input.");
        }
    
        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if (Helper.IsNumeric(firstNumber) && Helper.IsNumeric(secondNumber))
            {
                var div = Helper.ConvertToDecimal(firstNumber) - Helper.ConvertToDecimal(secondNumber);
                return Ok(div.ToString());
            }
            return BadRequest("Invalid Input.");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (Helper.IsNumeric(firstNumber) && Helper.IsNumeric(secondNumber))
            {
                var media = (Helper.ConvertToDecimal(firstNumber) + Helper.ConvertToDecimal(secondNumber)) / 2;
                return Ok(media.ToString());
            }
            return BadRequest("Invalid Input.");
        }
    
        [HttpGet("sqrt/{firstNumber}/{secondNumber}")]
        public IActionResult Sqrt(string firstNumber, string secondNumber)
        {
            if (Helper.IsNumeric(firstNumber) && Helper.IsNumeric(secondNumber))
            {
                var raiz1 = Math.Sqrt(Helper.ConvertToDouble(firstNumber));
                var raiz2 = Math.Sqrt(Helper.ConvertToDouble(secondNumber));
                return Ok(raiz1.ToString() + " " + raiz2.ToString());
            }
            return BadRequest("Invalid Input.");
        }
    }
}
