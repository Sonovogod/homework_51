using HomeWork.DataObjects;
using HomeWork.Models;
using HomeWork.Service.Abstract;

namespace HomeWork.Service;

public class DownloadFileService : IDownloadFileService
{
    private readonly IHostEnvironment _hostEnvironment;

    public DownloadFileService(IHostEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;
    }

    public FileDataObject Download(Phone phone)
    {
        string fileName = phone.Title;
        string filePath = Path.Combine(_hostEnvironment.ContentRootPath, $"Specs/{fileName}.pdf");
        string content = $"{phone.Title} - лучший телефон, 5000mp камера, луну снимать можно, " +
                         $"{phone.Manufacture} - лучший производитель телефоно, не то что сяёми. " +
                         $"\n Процессор выдает много попугаев и любых других зверей";
        File.WriteAllText(filePath, content);
        return new FileDataObject()
        {
            FileName = fileName,
            FileType = "application/pdf",
            FilePath = Path.Combine(_hostEnvironment.ContentRootPath, $"Specs/{fileName}.pdf")
        };
    }
}