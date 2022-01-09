using Microsoft.AspNetCore.Http;

namespace application.services
{
    public class ImageService : IImageService
    {
        private static Random random = new Random();

        public async Task<string> SaveOneIamge(FormFile image)
        {
            string imgName = "";
            var fileName = Path.GetFileName(image.FileName);
            var randomString = _randomString(15);

            if (image != null && _isPicture(fileName))
            {

                var path = $"c:\\Images\\{randomString + fileName}";
                try
                {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    imgName = $"{randomString + fileName}";
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            else
            {
                throw new Exception("Extension photo invalid or photo is null");
            }

            return imgName;
        }

        public async Task<List<string>> SaveListOfImages(ICollection<FormFile> images)
        {
            var imagesName = new List<string>();

            if (images.Count() > 0)
            {
                foreach (var image in images)
                {
                    var randomString = _randomString(15);
                    var imageName = Path.GetFileName(image.FileName);
                    if ( _isPicture(imageName) )
                    {
                        var path = $"c:\\Images\\{randomString + imageName}";
                        try
                        {
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await image.CopyToAsync(stream);
                            }

                            imagesName.Add($"{randomString + imageName}");
                        }
                        catch (Exception ex)
                        {
                            return null;
                        }
                    }

                }

            }
            else
            {
                throw new Exception("It must contain at least one photo");
            }

            return imagesName;
        }

        private string _randomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private bool _isPicture(string fileName)
        {
            var ext = Path.GetExtension(fileName);
            List<string> supportedTypes = new List<string>() { ".jpg", ".jpeg", ".jfif", ".pjpeg", ".pjp", ".png", ".svg", ".webp" };
            if (supportedTypes.Contains(ext))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
