using Microsoft.AspNetCore.Http;

namespace application.services
{
    public interface IImageService
    {
        Task<string> SaveOneIamge(IFormFile image);
        Task<List<string>> SaveListOfImages(ICollection<IFormFile> images);
    }
}
