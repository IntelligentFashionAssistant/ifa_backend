using Microsoft.AspNetCore.Http;

namespace application.services
{
    public interface IImageService
    {
        Task<string> SaveOneIamge(FormFile image);
        Task<List<string>> SaveListOfImages(ICollection<FormFile> images);
    }
}
