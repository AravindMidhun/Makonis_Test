using Makonis.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Makonis.Repository.Configurations;

namespace Makonis.Repository.DataAccess.Helpers
{
    public class FileHelper : IFileHelper
    {
        private string _fileLocation;
        private readonly object _lockObject = new object();

        public FileHelper(IOptions<FileLocationOptions> options)
        {
            if (options is null)
            {
                throw new System.ArgumentNullException(nameof(options));
            }
            _fileLocation = Path.Combine(Directory.GetCurrentDirectory(),options.Value.FilePath);
        }

        public List<T> ReadFile<T>() where T : class
        {
            lock (_lockObject)
            {
                string data = File.ReadAllText(_fileLocation);
                if (!string.IsNullOrEmpty(data))
                {
                    return JsonConvert.DeserializeObject<List<T>>(data);
                }
                return null;
            }
        }

        public void WriteFile(string data)
        {
            lock (_lockObject)
            {
                File.WriteAllText(_fileLocation, data);
            }
        }
    }
}
