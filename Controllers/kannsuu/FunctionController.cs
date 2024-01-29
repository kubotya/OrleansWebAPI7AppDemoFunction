using Microsoft.AspNetCore.Mvc;
using OrleansWebAPI7AppDemo.Models.Calculator;

[ApiController]
[Route("api/[controller]")]
public class FunctionController : ControllerBase
{
    [HttpGet("sin")]
    public ActionResult<double> Sin([FromQuery] double angle)
    {
        double result = Math.Sin(angle);
        return Ok(result);
    }

    [HttpGet("cos")]
    public ActionResult<double> Cos([FromQuery] double angle)
    {
        double result = Math.Cos(angle);
        return Ok(result);
    }

    [HttpGet("tan")]
    public ActionResult<double> Tan([FromQuery] double angle)
    {
        double result = Math.Tan(angle);
        return Ok(result);
    }

    [HttpGet("asin")]
    public ActionResult<double> Asin([FromQuery] double value)
    {
        if (value < -1 || value > 1)
        {
            return BadRequest("Input value must be in the range [-1, 1].");
        }

        double result = Math.Asin(value);
        return Ok(result);
    }

    [HttpGet("acos")]
    public ActionResult<double> Acos([FromQuery] double value)
    {
        if (value < -1 || value > 1)
        {
            return BadRequest("Input value must be in the range [-1, 1].");
        }

        double result = Math.Acos(value);
        return Ok(result);
    }

    [HttpGet("atan")]
    public ActionResult<double> Atan([FromQuery] double value)
    {
        double result = Math.Atan(value);
        return Ok(result);
    }
}