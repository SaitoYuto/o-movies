using Azure.Storage.Blobs;

namespace OMovies.Services;

public class AzureBlobService
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly string _containerName = "poster";

    public AzureBlobService(IConfiguration configuration)
    {
        _blobServiceClient = new BlobServiceClient(configuration.GetConnectionString("AzureBlobStorage"));
    }

    public async Task<string> UploadImageAsync(Stream content, string fileName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
        await containerClient.CreateIfNotExistsAsync();

        var blobClient = containerClient.GetBlobClient(fileName);
        await blobClient.UploadAsync(content, true);

        return blobClient.Uri.ToString();
    }
}