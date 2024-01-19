using CloudinaryDotNet.Actions;
using CollectionDataLayer.Entities;
using Microsoft.AspNetCore.Http;

namespace CollectionLogicLayer.Services;

public interface IPhotoService
{
    Task<Photo?> AddPhotoAsync(IFormFile? file);
    Task<DeletionResult> DeletePhotoAsync(string publicId);
}
