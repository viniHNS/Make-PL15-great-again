<div align="center">

# Make PL-15 Great Again!

A server mod for SPT 4.1.6 that lets the PL-15 use Glock sights and a few sight mounts, and tightens its accuracy.

![Version](https://img.shields.io/badge/version-1.5.0-orange?style=flat)
![SPT](https://img.shields.io/badge/SPT-4.1.6-blue?style=flat)
![.NET](https://img.shields.io/badge/.NET-10-512BD4?style=flat&logo=dotnet)
![License](https://img.shields.io/badge/license-MIT-green?style=flat)

[Features](#features) · [Install](#install) · [Sights](#sights) · [Build](#build-from-source)

**English** · [Português](README_BR.md)

</div>

---

## Features

| Change | Game | Mod |
|---|---|---|
| Rear sight slot (slide) | PL-15 sights | + 5 Glock rear sights and 3 sight mounts |
| Front sight slot (slide) | PL-15 sights | + 5 Glock front sights |
| Max deviation | 11 | 9 |

> Why Glock sights? The real PL-15 has removable dovetail front and rear sights that are fully interchangeable with sights made for Glock pistols.

---

## Install

Extract `makepl15greatagain.zip` into your SPT game folder:

```
<game folder>/
└── SPT_Runtime/user/mods/makepl15greatagain/
    └── makepl15greatagain.dll
```

Server only, no client plugin needed.

---

## Sights

| Slot | Item |
|---|---|
| Rear | Glock rear sight |
| Rear | Glock 19X rear sight |
| Rear | Glock TruGlo TFX rear sight |
| Rear | Glock ZEV Tech rear sight |
| Rear | Glock Dead Ringer Snake Eye rear sight |
| Rear | P226 Sight Mount 220-239 rear sight bearing |
| Rear | M9A3 Sight Mount rear sight rail |
| Rear | HK USP Red Dot sight mount |
| Front | Glock front sight |
| Front | Glock 19X front sight |
| Front | Glock TruGlo TFX front sight |
| Front | Glock ZEV Tech front sight |
| Front | Glock Dead Ringer Snake Eye front sight |

---

## Build from Source

**Requirements:** .NET 10 SDK.

```sh
dotnet build makepl15greatagain.sln -c Release
```

The build creates `makepl15greatagain.zip` in the solution folder.

> The `.csproj` copies the build output into `D:\Jogos\SPT4.1` for testing when that folder exists. Change `SptModsDir` to your own SPT folder. Close the SPT server before building, or the copy fails because the DLL is in use.

### Project Structure

```
Make-PL15-great-again/
├── makepl15greatagain.sln
└── Server/                         .NET 10 server mod
    ├── Mod.cs                      mod metadata
    └── PL15Changes.cs              sight slots and deviation changes
```

---

## Resources

| Resource | URL |
|---|---|
| SPT Server C# | https://github.com/SP-Tushonka/server-csharp |
| Server Mod Examples | https://github.com/SP-Tushonka/server-mod-examples |
| SPT Wiki — Modding Resources | https://wiki.sp-tushonka.com/en/modding/Modding_Resources |
| SPT Scaffold | https://github.com/viniHNS/spt-scaffold |
