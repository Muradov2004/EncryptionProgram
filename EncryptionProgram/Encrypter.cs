using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionProgram;

class Encrypter
{
    public int EncryptionKey { get; set; }

    public char Encrypt(char Character)
    {

        Character |= (char)EncryptionKey;
        return Character;
    }
}
