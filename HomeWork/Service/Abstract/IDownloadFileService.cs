using HomeWork.DataObjects;
namespace HomeWork.Service.Abstract;

public interface IDownloadFileService
{
    FileDataObject Download(string fileName);
}