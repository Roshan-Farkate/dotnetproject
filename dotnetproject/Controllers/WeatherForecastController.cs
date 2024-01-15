using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public IEnumerable<string> Get()
    {
        // Security Hotspot: Sensitive Information in Code
        // This should be stored securely, not hard-coded in the code
        return new string[] { "SonarQube ASP.NET CORE", "DEMO POC" };
    }

    [HttpGet("insecure")]
    public IEnumerable<string> GetInsecureData()
    {
        // Manual Error: Exception Handling
        try
        {
            // Intentionally causing an exception for analysis
            //int result = 10 / 0;
        }
        catch (Exception ex)
        {
            // In a real scenario, log the exception and handle it appropriately
            return new string[] { "Error occurred" };
        }

        return new string[] { "SonarQube ASP.NET CORE", "DEMO POC" };
    }

    [HttpGet("injection")]
    public IEnumerable<string> GetWithInjection()
    {
        // Manual Error: Missing Input Validation
        // This is vulnerable to injection attacks, validate user input
        string userInput = Request.Query["input"];
        // Add input validation logic here

        return new string[] { "SonarQube ASP.NET CORE", "DEMO POC" };
    }

    [HttpGet("insecurecomment")]
    public IEnumerable<string> GetWithInsecureComment()
    {
        // Manual Error: Insecure Comment
        // This comment reveals sensitive information
        // It should be removed or obfuscated
        return new string[] { "SonarQube ASP.NET CORE", "DEMO POC" };
    }
}
