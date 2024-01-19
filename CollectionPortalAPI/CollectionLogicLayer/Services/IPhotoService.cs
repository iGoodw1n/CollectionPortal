﻿using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace CollectionLogicLayer.Services;

public interface IPhotoService
{
    Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    Task<DeletionResult> DeletePhotoAsync(string publicId);
}
