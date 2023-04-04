using HomeWork.DataObjects;
using HomeWork.Service.Abstract;

namespace HomeWork.Service;

public class DownloadFileService : IDownloadFileService
{
    private readonly IHostEnvironment _hostEnvironment;

    public DownloadFileService(IHostEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;
    }

    public FileDataObject Download(string fileName)
    {
        List<string> file = Directory
            .GetFiles(_hostEnvironment.ContentRootPath, $"{fileName}*", SearchOption.AllDirectories)
            .ToList();
        fileName = file.FirstOrDefault(x => string.Equals(x, fileName, StringComparison.CurrentCultureIgnoreCase));
        return new FileDataObject()
        {
            FileName = fileName,
            FileType = "application/pdf",
            FilePath = Path.Combine(_hostEnvironment.ContentRootPath, $"Specs/{fileName}")
        };
    }
}