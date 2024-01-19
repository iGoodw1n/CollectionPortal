using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CollectionDataLayer.Entities;
using CollectionLogicLayer.Helpers;
using CollectionLogicLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace API.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;
        public PhotoService(IOptions<CloudinarySettings> config)
        {
            var acc = new Account
            (
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
        }

        public async Task<Photo?> AddPhotoAsync(IFormFile? file)
        {
            Photo? photo = null;
            if (file is not null && file.Length > 0)
            {
                photo = await UploadPhoto(file);
            }

            return photo;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);

            var result = await _cloudinary.DestroyAsync(deleteParams);

            return result;
        }

        private async Task<Photo> UploadPhoto(IFormFile file)
        {
            var uploadResult = await UploadPhotoOnCloudServer(file);
            if (uploadResult.Error != null)
            {
                throw new InvalidOperationException("Some errors on photo service");
            }
            var photo = CreatePhoto(uploadResult);
            return photo;
        }

        private async Task<ImageUploadResult> UploadPhotoOnCloudServer(IFormFile file)
        {
            using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Transformation = new Transformation().Height(500).Width(500).Crop("fill")
            };
            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            return uploadResult;
        }

        private Photo CreatePhoto(ImageUploadResult uploadResult)
        {
            var photo = new Photo
            {
                Url = uploadResult.SecureUrl.AbsoluteUri,
                PublicId = uploadResult.PublicId
            };

            return photo;
        }

    }
}