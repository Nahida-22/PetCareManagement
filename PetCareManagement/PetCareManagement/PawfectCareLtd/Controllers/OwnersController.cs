using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OwnersController : ControllerBase
{
    private readonly CsvReaderService _csvReaderService;

    public OwnersController(CsvReaderService csvReaderService)
    {
        _csvReaderService = csvReaderService;
    }

    // Endpoint to load Owners data from a CSV file
    [HttpPost("load-owners-csv")]
    public IActionResult LoadOwnersCsv()
    {
        // Path to your CSV file (you can also pass the path dynamically)
        var filePath = "C:\\Users\\23052\\Desktop\\Coursework\\PetCareLtd\\PetCareManagement\\PetCareManagement\\PawfectCareLtd\\CSV\\Owner.csv";
        _csvReaderService.ReadOwnersFromCsv(filePath);

        return Ok("Owners data loaded successfully.");
    }

    
    
}
