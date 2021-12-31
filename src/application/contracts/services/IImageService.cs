using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.contracts.services
{
    public interface IImageService
    {
        Task<string> SaveOneIamge(FormFile image);
        Task<List<string>> SaveListOfImages(ICollection<FormFile> images);
    }
}
