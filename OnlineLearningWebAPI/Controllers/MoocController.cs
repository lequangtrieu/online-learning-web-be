using Microsoft.AspNetCore.Mvc;
using OnlineLearningWebAPI.DTOs.request.MoocRequest;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoocController : ControllerBase
{
    private readonly IMoocService _moocService;

    public MoocController(IMoocService moocService)
    {
        _moocService = moocService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMoocs()
    {
        var moocs = await _moocService.GetAllMoocsAsync();
        return Ok(moocs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMoocById(int id)
    {
        var mooc = await _moocService.GetMoocByIdAsync(id);
        if (mooc == null) return NotFound(new { message = "Mooc not found" });

        return Ok(mooc);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMooc([FromBody] CreateMoocDTO createMoocDTO)
    {
        var result = await _moocService.CreateMoocAsync(createMoocDTO);
        if (!result) return BadRequest(new { message = "Failed to create Mooc" });

        return Ok(new { message = "Mooc created successfully" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMooc(int id, [FromBody] UpdateMoocDTO updateMoocDTO)
    {
        var result = await _moocService.UpdateMoocAsync(id, updateMoocDTO);
        if (!result) return NotFound(new { message = "Mooc not found or update failed" });

        return Ok(new { message = "Mooc updated successfully" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMooc(int id)
    {
        var result = await _moocService.DeleteMoocAsync(id);
        if (!result) return NotFound(new { message = "Mooc not found or delete failed" });

        return Ok(new { message = "Mooc deleted successfully" });
    }
}
