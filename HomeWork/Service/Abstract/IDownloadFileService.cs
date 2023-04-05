using HomeWork.DataObjects;
using HomeWork.Models;

namespace HomeWork.Service.Abstract;

public interface IDownloadFileService
{
    FileDataObject Download(Phone phone);
}