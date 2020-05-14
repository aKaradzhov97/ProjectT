namespace ProjectT.CloudinaryHelper
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;

    public class CloudinaryExtension
    {
        public static async Task<List<string>> UploadAsync(Cloudinary cloudinary, ICollection<IFormFile> files)
        {
            var urlList = new List<string>();

            foreach (var file in files)
            {
                byte[] destinationImage;

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    destinationImage = memoryStream.ToArray();
                }

                using (var destinationStream = new MemoryStream(destinationImage))
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.FileName,destinationStream),
                    };

                    var result = await cloudinary.UploadAsync(uploadParams);

                    urlList.Add(result.Uri.AbsoluteUri);
                }
            }

            return urlList;
        }

        public static async Task DeleteAsync(Cloudinary cloudinary, string imageId)
        {
            var deletionParams = new DeletionParams(imageId);

            var deletionResult = cloudinary.DestroyAsync(deletionParams);

            if (deletionResult.IsCompleted)
            {
                return;
            }
        }
    }
}