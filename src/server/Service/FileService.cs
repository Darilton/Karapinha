using Microsoft.AspNetCore.Http;
using Shared;

namespace Service;

public class FileService : IFileService
{
    public byte[] ToByteArray(IFormFile file)
    {
        MemoryStream ms = new MemoryStream();
        file.CopyTo(ms);

        return ms.ToArray();
    }
}
