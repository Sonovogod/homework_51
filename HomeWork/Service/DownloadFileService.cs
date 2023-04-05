using HomeWork.DataObjects;
using HomeWork.Service.Abstract;

namespace HomeWork.Service;

public class DownloadFileService : IDownloadFileService
{
    private readonly IHostEnvironment _hostEnvironment;
    private readonly IPhoneService _phoneService;

    public DownloadFileService(IHostEnvironment hostEnvironment, IPhoneService phoneService)
    {
        _hostEnvironment = hostEnvironment;
        _phoneService = phoneService;
    }

    public FileDataObject Download(int id)
    {
        var phone = _phoneService.GetById(id);
        string fileName = $"{phone.Title.Replace(' ', '_')}.txt";
        string filePath = Path.Combine(_hostEnvironment.ContentRootPath, $"Specs/{fileName}");
        string content = $"{phone.Title} - лучший телефон, 5000mp камера, луну снимать можно, " +
                         $"{phone.Manufacture} - лучший производитель телефоно, не то что сяёми. " +
                         $"\n Процессор выдает много попугаев и любых других зверей";
        File.WriteAllText(filePath, content);
        return new FileDataObject()
        {
            FileName = fileName,
            FileType = "application/txt",
            FilePath = Path.Combine(_hostEnvironment.ContentRootPath, $"Specs/{fileName}")
        };
    }
}