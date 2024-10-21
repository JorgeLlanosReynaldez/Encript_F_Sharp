namespace Encrypt

open System
open System.IO
open System.Security.Cryptography
open System.Text

module Hasher =
    let hashWithSHA256 (input: string) =
        use sha256 = SHA256.Create()
        let bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input))
        BitConverter.ToString(bytes).Replace("-", "").ToLower()