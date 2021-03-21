using Caesar_Cipher.Models;

namespace Caesar_Cipher.Services.Encryption
{
    public interface IEncryptionService
    {
        bool DecryptMessage(EncryptionAction action);

        bool EncryptMessage(EncryptionAction action);
    }
}