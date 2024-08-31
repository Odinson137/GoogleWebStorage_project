using Google.Cloud.Storage.V1;
using System;
using System.IO;
using Google.Apis.Auth.OAuth2;

var uploader = new UploadFileSample();

uploader.UploadFile();

// uploader.DownloadFile("2181f564-6478-443c-83ab-60bd1ab20717", "jpeg");

public class UploadFileSample
{
    private const string BucketName = "test_yuri_buryy";
    private const string Credential = "pilot-433511-82bf33c3cee3.json";
    
    public void UploadFile()
    {
        var googleCredential = GoogleCredential.FromFile(Credential);
        var storage = StorageClient.Create(googleCredential);
        var stream = new FileStream("1a17355c-a448-4162-8b69-c049f330dd95.jpeg", FileMode.OpenOrCreate);
        storage.UploadObject(BucketName, Guid.NewGuid().ToString(), "image/jpeg", stream);
        Console.WriteLine("Good save");
    }
    
    public void DownloadFile(string objectName, string type)
    {
        var googleCredential = GoogleCredential.FromFile(Credential);
        var storage = StorageClient.Create(googleCredential);
        var stream = new FileStream(objectName + $".{type}", FileMode.OpenOrCreate);
        storage.DownloadObject(BucketName, objectName, stream);
        Console.WriteLine($"Downloaded {objectName}");
    }
}

