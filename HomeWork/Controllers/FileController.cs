using HomeWork.Models;
using HomeWork.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork.Controllers;

public class FileController : Controller
{
    private readonly IDownloadFileService _downloadFileService;

    public FileController(IDownloadFileService downloadFileService)
    {
        _downloadFileService = downloadFileService;
    }
    
    public IActionResult GetFile(int id)
    {
        var file = _downloadFileService.Download(id);

        if (string.IsNullOrEmpty(file.FileName))
            return NotFound();
        
        return PhysicalFile(file.FilePath, file.FileType, file.FileName);
    }
}