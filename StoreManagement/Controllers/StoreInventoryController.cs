using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace StoreManagement.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]

    //public class StoreInventoryController : ControllerBase
    //{
    //    private readonly IUnitOfWork _unitOfWork;
    //    private readonly IMapper _mapper;

    //    public StoreInventoryController(IUnitOfWork unitOfWork, IMapper mapper)
    //    {
    //        _unitOfWork = unitOfWork;
    //        _mapper = mapper;
    //    }

    //    private FileDirectory MapToFileDirectory(FileDirectoryDto directory)
    //    {
    //        return _mapper.Map<FileDirectory>(directory);
    //    }

    //    [HttpGet("GetDirectory")]
    //    public async Task<ActionResult> GetDirectory()
    //    {
    //        try
    //        {
    //            var item = await _unitOfWork.backupRepo.GetBackupDirectory();
    //            return Ok(item);
    //        }
    //        catch (Exception ex)
    //        {
    //            //add logging of bad requests here
    //            return BadRequest(ex.Message);
    //        }
    //    }

    //    [HttpPost("AddDirectory")]
    //    public async Task<ActionResult> AddDirectory([FromBody] FileDirectoryDto directory)
    //    {
    //        try
    //        {
    //            var newDirectory = MapToFileDirectory(directory);

    //            var isDuplicateDirectory = _unitOfWork.backupRepo.DuplicateCheck(newDirectory);

    //            if (isDuplicateDirectory)
    //            {
    //                return StatusCode(209);
    //            }

    //            _unitOfWork.backupRepo.AddBackupDirectory(newDirectory);

    //            return Ok(200);
    //        }
    //        catch (Exception ex)
    //        {
    //            //add logging of bad requests here
    //            return BadRequest(ex.Message.ToString());
    //        }
    //    }

    //    [HttpPost("UpdateDirectory")]
    //    public async Task<ActionResult> UpdateDirectory([FromBody] FileDirectoryDto directory)
    //    {
    //        try
    //        {
    //            var newDirectory = MapToFileDirectory(directory);
    //            var isDuplicateDirectory = _unitOfWork.backupRepo.DuplicateCheck(newDirectory);
    //            if (isDuplicateDirectory)
    //            {
    //                return StatusCode(209);
    //            }

    //            _unitOfWork.backupRepo.UpdateBackupDirectory(newDirectory);

    //            return Ok(200);
    //        }
    //        catch (Exception ex)
    //        {
    //            //add logging of bad requests here
    //            return BadRequest(ex.Message.ToString());
    //        }
    //    }

    //    [HttpPost("RemoveDirectory")]
    //    public async Task<ActionResult> RemoveDirectory([FromBody] FileDirectoryDto directory)
    //    {
    //        try
    //        {
    //            var targetDirectory = MapToFileDirectory(directory);
    //            _unitOfWork.backupRepo.DeleteBackupDirectory(targetDirectory);
    //            return Ok(200);
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest(ex.Message.ToString());
    //        }
    //    }

    //}
}