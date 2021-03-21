using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar_Cipher.Services.IO
{
    public interface IFileReader
    {
        string ReadFileContents(string filePath);
    }
}