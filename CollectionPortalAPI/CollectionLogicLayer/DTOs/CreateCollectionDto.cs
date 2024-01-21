using Microsoft.AspNetCore.Http;

namespace CollectionLogicLayer.DTOs;

public class CreateCollectionDto : CollectionDto
{
    public IFormFile? Image { get; set; }
}


