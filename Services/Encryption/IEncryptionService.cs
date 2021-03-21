using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar_Cipher.Services.Encryption
{
    public interface IEncryptionService
    {
        string DecryptMessage(string msg);

        string EncryptMessage(string msg);
    }
}