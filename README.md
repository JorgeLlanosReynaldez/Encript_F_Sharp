# README: Librería de Encriptación y Hashing en F#

## Descripción

`Encrypt` es una biblioteca desarrollada en F# para realizar operaciones de cifrado, descifrado y generación de hashes de manera sencilla y reutilizable. Fue diseñada para integrarse en proyectos .NET y puede ser llamada desde aplicaciones C#. 

- **Encryptor**: Módulo que proporciona métodos para cifrar (`encryptString`) y descifrar (`decryptString`) un texto utilizando el algoritmo AES.
- **Hasher**: Módulo que permite generar un hash seguro mediante el algoritmo SHA-256.

## Características

- **Cifrado AES**: Utiliza AES (Advanced Encryption Standard) con un **IV (Vector de Inicialización)** aleatorio para asegurar que cada encriptación del mismo texto con la misma clave produzca resultados diferentes.
- **IV Aleatorio**: Cada vez que se realiza un cifrado, se genera un IV diferente, lo que asegura que el texto cifrado no se repita, incluso con los mismos datos y la misma clave.
- **Hashing con SHA-256**: Método para generar hashes seguros, ideal para almacenar contraseñas o realizar verificaciones de integridad de datos.

## Integración en un Proyecto C#

### Requisitos

1. Tener un proyecto .NET (C# o F#) con la biblioteca `Encrypt` referenciada.
2. Asegurarse de que ambos proyectos (la biblioteca y la aplicación de consola) tengan como `TargetFramework` la misma versión, como `net8.0`.

### Ejemplo de Uso desde C#

```csharp
using System;
using Encrypt; 

string Text = "Password123";
string key = "8995-32-114002-ABC";
string texthash = "Password123";
try
{
    string encrypted = Encryptor.encryptString(Text, key);
    Console.WriteLine($"Encrypt: {encrypted}");

    string decrypted = Encryptor.decryptString(encrypted, key);
    Console.WriteLine($"Decrypt: {decrypted}");

    string hash = Hasher.hashWithSHA256(texthash);
    Console.WriteLine($"SHA256 Hash: {hash}");
}
catch (Exception ex)
{
    throw ex;
}
```
### Resultados

```console
Encryp: TYNTx2rWj+EGyVAd1FEk9hpuWo7i/sgOTMzc1f+YrZ0=
Decryp: Password123
SHA256 Hash: 008c70392e3abfbd0fa47bbc2ed96aa99bd49e159727fcba0f2e6abeb3a9d601

Encryp: iYyzX3xbhhF6DhhU5De0IkRwySeK610JFsOFRjbAYsE=
Decryp: Password123
SHA256 Hash: 008c70392e3abfbd0fa47bbc2ed96aa99bd49e159727fcba0f2e6abeb3a9d601

Encryp: sHTZ6DkIi8Pb0bF0P6zch5lM7vLh1cCGqqBB3nOhGlQ=
Decryp: Password123
SHA256 Hash: 008c70392e3abfbd0fa47bbc2ed96aa99bd49e159727fcba0f2e6abeb3a9d601
```
