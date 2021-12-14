using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryConverterAPI.Controllers
{
    [ApiController]
    public class ConverterController : Controller
    {
        [Route("api/BinaryToDecimal")]
        [HttpPost]
        public IActionResult BinaryToDecimal(ConverterModel converterModel)
        {
            char[] BinaryArray = converterModel.BinaryString.ToCharArray();
            Array.Reverse(BinaryArray);
            int result = 0;

            for (int i = 0; i < BinaryArray.Length; i++)
            {
                if (BinaryArray[i] == '1')
                {
                    if (i == 0)
                    {
                        result += 1;
                    }
                    else
                    {
                        result += (int)Math.Pow(2, i);
                    }
                }

            }

            return Ok(new { Status = "200", Message = "Convert from binary: " + converterModel.BinaryString + " to decimal: " + result });
        }

        [Route("api/DecimalToBinary")]
        [HttpPost]
        public IActionResult DecimalToBinary(ConverterModel converterModel)
        {
            int check;
            int value;
            value = Convert.ToInt32(converterModel.DecimalString);

            string result = string.Empty;
            while (value > 0)
            {
                check = value / 2;
                result += (value % 2).ToString();
                value = check;
            }

            string whiteSpace = " ";
            for (int i = result.Length - 1; i >= 0; i--)
            {
                whiteSpace =  whiteSpace + result[i];
            }

            return Ok(new { Status = "200", Message = "Convert from decimal: " + converterModel.DecimalString + " to binary: " + whiteSpace });

        }
    }
}
