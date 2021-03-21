using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar_Cipher.Models
{
    public class EncryptionAction
    {
        public TransformMethod Choice { get; set; }
        public ProcessingMethod Method { get; set; }
    }
}