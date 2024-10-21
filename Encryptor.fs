namespace Encrypt

open System
open System.IO
open System.Security.Cryptography
open System.Text

module Encryptor =
    let encryptString (plainText: string) (key: string) =
        use aes = Aes.Create()
        aes.Key <- Encoding.UTF8.GetBytes(key.PadRight(32))
        aes.GenerateIV()
        let encryptor = aes.CreateEncryptor(aes.Key, aes.IV)
        use msEncrypt = new MemoryStream()
        msEncrypt.Write(aes.IV, 0, aes.IV.Length)
        use csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)
        use swEncrypt = new StreamWriter(csEncrypt)
        swEncrypt.Write(plainText)
        swEncrypt.Flush()
        csEncrypt.FlushFinalBlock()
        Convert.ToBase64String(msEncrypt.ToArray())

    let decryptString (encryptedText: string) (key: string) =
        try
            let fullCipher = Convert.FromBase64String(encryptedText)
            use aes = Aes.Create()
            let iv = Array.zeroCreate<byte> (aes.BlockSize / 8)
            let cipher = Array.zeroCreate<byte> (fullCipher.Length - iv.Length)
            Array.Copy(fullCipher, iv, iv.Length)
            Array.Copy(fullCipher, iv.Length, cipher, 0, cipher.Length)
            
            aes.Key <- Encoding.UTF8.GetBytes(key.PadRight(32))
            aes.IV <- iv
            let decryptor = aes.CreateDecryptor(aes.Key, aes.IV)
            
            use msDecrypt = new MemoryStream(cipher)
            use csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)
            use srDecrypt = new StreamReader(csDecrypt)
            srDecrypt.ReadToEnd()
        with
        | ex -> 
            printfn "[ERROR][decryptString]: %s" ex.Message
            raise ex
