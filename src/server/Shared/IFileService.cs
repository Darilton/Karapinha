using Microsoft.AspNetCore.Http;

namespace Shared;

public interface IFileService
{
    public byte[] ToByteArray(IFormFile file);
}
