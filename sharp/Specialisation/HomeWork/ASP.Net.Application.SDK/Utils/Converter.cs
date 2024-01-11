using ASP.Net.Application.SDK.Models;

namespace ASP.Net.Application.SDK.Utils
{
    public static class Converter
    {
        public static ProductDto ConvertToDto(this ProductEntity entity)
        {
            return new ProductDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                CategoryId = entity.CategoryId,
                Cost = entity.Cost,
                Price = entity.Price,
                StorageId = entity.StorageId
            };

        }

        public static CategoryDto ConvertToDto(this CategoryEntity entity)
        {
            return new CategoryDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
            };

        }

        public static StorageDto ConvertToDto(this StorageEntity entity)
        {
            return new StorageDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
            };

        }

        public static ProductEntity ConvertToEntity(this ProductDto dto)
        {
            return new ProductEntity
            {
                Id = dto.Id ?? Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                StorageId = dto.StorageId,
                Price = dto.Price,
                Cost = dto.Cost,
                CategoryId = dto.CategoryId

            };

        }

        public static CategoryEntity ConvertToEntity(this CategoryDto dto)
        {
            return new CategoryEntity
            {
                Id = dto.Id ?? Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
            };

        }

        public static StorageEntity ConvertToEntity(this StorageDto dto)
        {
            return new StorageEntity
            {
                Id = dto.Id ?? Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
            };

        }
    }
}
