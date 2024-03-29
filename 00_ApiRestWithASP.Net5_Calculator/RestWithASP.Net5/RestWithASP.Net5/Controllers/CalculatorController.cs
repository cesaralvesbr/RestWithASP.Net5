﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP.Net5.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = Convert.ToDecimal (firstNumber) + Convert.ToDecimal (secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = Convert.ToDecimal(firstNumber) - Convert.ToDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = Convert.ToDecimal(firstNumber) * Convert.ToDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = Convert.ToDecimal(firstNumber) / Convert.ToDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid Input");
        }


        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = (Convert.ToDecimal(firstNumber) + Convert.ToDecimal(secondNumber)) / 2;
                return Ok(result.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("square-root/{firstNumber}")]
        public IActionResult SquareRoot(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var squareRoot = Math.Sqrt((double)Convert.ToDecimal(firstNumber));
                return Ok(squareRoot.ToString());
            }
            return BadRequest("Invalid Input");
        }



        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);

            return isNumber;
        }

        //private decimal ConvertToDecimal(string strNumber)
        //{
        //    decimal decimalValue;
        //    if (decimal.TryParse(strNumber, out decimalValue))
        //        return decimalValue;
        //    return 0;
        //}

       
    }
}
