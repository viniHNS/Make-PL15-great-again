<div align="center">

# Make PL-15 Great Again!

Um mod de server para o SPT 4.1.6 que libera miras de Glock e alguns suportes de mira na PL-15, e melhora a precisão dela.

![Version](https://img.shields.io/badge/version-1.5.0-orange?style=flat)
![SPT](https://img.shields.io/badge/SPT-4.1.6-blue?style=flat)
![.NET](https://img.shields.io/badge/.NET-10-512BD4?style=flat&logo=dotnet)
![License](https://img.shields.io/badge/license-MIT-green?style=flat)

[Funcionalidades](#funcionalidades) · [Instalação](#instalação) · [Miras](#miras) · [Build](#build-a-partir-do-código)

[English](README.md) · **Português**

</div>

---

## Funcionalidades

| Alteração | Jogo | Mod |
|---|---|---|
| Slot de mira traseira (ferrolho) | Miras da PL-15 | + 5 miras traseiras de Glock e 3 suportes de mira |
| Slot de mira frontal (ferrolho) | Miras da PL-15 | + 5 miras frontais de Glock |
| Desvio máximo | 11 | 9 |

> Por que miras de Glock? A PL-15 real tem miras frontal e traseira removíveis, de encaixe dovetail, totalmente intercambiáveis com as miras feitas para pistolas Glock.

---

## Instalação

Extraia o `makepl15greatagain.zip` na pasta do jogo SPT:

```
<pasta do jogo>/
└── SPT_Runtime/user/mods/makepl15greatagain/
    └── makepl15greatagain.dll
```

Só server, não precisa de plugin no client.

---

## Miras

| Slot | Item |
|---|---|
| Traseira | Glock rear sight |
| Traseira | Glock 19X rear sight |
| Traseira | Glock TruGlo TFX rear sight |
| Traseira | Glock ZEV Tech rear sight |
| Traseira | Glock Dead Ringer Snake Eye rear sight |
| Traseira | P226 Sight Mount 220-239 rear sight bearing |
| Traseira | M9A3 Sight Mount rear sight rail |
| Traseira | HK USP Red Dot sight mount |
| Frontal | Glock front sight |
| Frontal | Glock 19X front sight |
| Frontal | Glock TruGlo TFX front sight |
| Frontal | Glock ZEV Tech front sight |
| Frontal | Glock Dead Ringer Snake Eye front sight |

---

## Build a partir do código

**Requisitos:** .NET 10 SDK.

```sh
dotnet build makepl15greatagain.sln -c Release
```

O build gera o `makepl15greatagain.zip` na pasta da solution.

> O `.csproj` copia o build para `D:\Jogos\SPT4.1` para teste, quando essa pasta existe. Troque o `SptModsDir` pela sua pasta do SPT. Feche o server do SPT antes de compilar, senão a cópia falha porque a DLL está em uso.

### Estrutura do projeto

```
Make-PL15-great-again/
├── makepl15greatagain.sln
└── Server/                         server mod .NET 10
    ├── Mod.cs                      metadata do mod
    └── PL15Changes.cs              alterações nos slots de mira e no desvio
```

---

## Recursos

| Recurso | URL |
|---|---|
| SPT Server C# | https://github.com/SP-Tushonka/server-csharp |
| Exemplos de server mod | https://github.com/SP-Tushonka/server-mod-examples |
| SPT Wiki — Modding Resources | https://wiki.sp-tushonka.com/en/modding/Modding_Resources |
| SPT Scaffold | https://github.com/viniHNS/spt-scaffold |
