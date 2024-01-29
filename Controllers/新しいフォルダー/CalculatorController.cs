using Microsoft.AspNetCore.Mvc;
using OrleansWebAPI7AppDemo.Models.Calculator;

[Route("api/calculator")]
[ApiController]
public class CalculatorController : ControllerBase
{
    [HttpGet("たし")]
    public IActionResult Add([FromQuery] int num1, [FromQuery] int num2)
    {
        int result = num1 + num2;
        //var data = new { 
        //    operation = "add", 
        //    result = result 
        //};
        //CalculatorResult data = new CalculatorResult();
        //data.Operation = "add";
        //data.Result = result;

        var data = new CalculatorResult<int> { 
            Operation = "add",
            Result = result 
        };

        return Ok(data);
    }

    [HttpGet("ひき")]
    public IActionResult Subtract([FromQuery] int num1, [FromQuery] int num2)
    {
        int result = num1 - num2;

        var data = new CalculatorResult<int>
        {
            Operation = "subtract",
            Result = result
        };
        return Ok(data);
    }

    [HttpGet("かけ")]
    public IActionResult Multiply([FromQuery] int num1, [FromQuery] int num2)
    {
        int result = num1 * num2;

        var data = new CalculatorResult<int>
        {
            Operation = "multiply",
            Result = result
        };
        return Ok(data);
    }

    [HttpGet("わり")]
    public IActionResult Divide([FromQuery] double num1, [FromQuery] double num2)
    {
        if (num2 == 0)
        {
            return BadRequest(new { error = "0では割れない" });
        }

        double result = num1 / num2;

        var data = new CalculatorResult<double>
        {
            Operation = "divide",
            Result = result
        };
        return Ok(data);
    }
}