using System.IO;
using Microsoft.Extensions.Configuration;

namespace Caesar_Cipher.Services.IO
{
    public class FileService : IFileReader, IFileWriter
    {
        private IConfiguration _config;
        private string _defaultFilePath = string.Empty;

        public FileService()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("./appsettings.json", optional: false);

            _config = builder.Build();

            _defaultFilePath = _config["FileToEncryptPath"];
        }

        public string ExtractFileContents(string filePath = "")
        {
            if (string.IsNullOrEmpty(filePath))
            {
                filePath = _defaultFilePath;
            }

            using (var fileReader = new StreamReader(filePath))
            {
                var contents = fileReader.ReadToEnd();
                return contents;
            }
        }

        public void WriteContentsToFile(string contents, string filePath = "")
        {
            if (string.IsNullOrEmpty(filePath))
            {
                filePath = _defaultFilePath;
            }

            using (var writer = new StreamWriter(filePath, append: false))
            {
                writer.Write(contents);
            }
        }
    }
}