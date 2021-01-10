# backend-challenge
Desafio Itau

A aplicação foi desenvolvida em .NET Core 3.0.

Foram assumidas como premissas:
- Por se tratar de uma senha, decidi utilizar uma chamada POST para nao expos a senha em uma URL.
- A senha é case insensitive, ou seja, combinações de letras maiúscula e minúscula não serão permitidas. 
ex: "1!Qwertyq" e "1!QwertyQ" nao serão permitidos


Endereço para consumo da api:
https://localhost:(porta)/ValidarSenha
Request:
{
    "Senha": "1@Qwertyu"
}

Para permitir que seja diferenciado letras minúsculas e maiúsculas utilizar a request:
{
    "Senha": "1@Qwertyuq",
    "CaseSensitive": true
}
desta forma, a senha "1!Qwertyq" será válida, porém "1!QwertyQ", não será válido.
