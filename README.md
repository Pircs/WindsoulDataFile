# WindsoulDataFile

[![Build Status](https://travis-ci.org/Eastrall/WindsoulDataFile.svg?branch=master)](https://travis-ci.org/Eastrall/WindsoulDataFile)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/2e0d27e6b4b0484d9e22bca534187696)](https://www.codacy.com/app/Eastrall/WindsoulDataFile?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=Eastrall/WindsoulDataFile&amp;utm_campaign=Badge_Grade)

[Not available on NuGet yet]

WindsoulDataFile is a C# library for managing WDF files easily.

## Details 

- Language : `C#`
- Framework : `.NET Standard 1.3`
- Type : `Library`
- Environment : Visual Studio 2017

## What is Windsoul Data File ?

The Windsoul Data File (WDF) was originaly created by Cloud Wu within the Windsoul++ game programming library in 1999-2001. This file structure is mainly used in the `Conquer Online` game for storing resources (Maps, textures, etc...)

You can find the original `C++` source code [here](http://read.pudn.com/downloads76/sourcecode/game/281928/%E9%A3%8E%E9%AD%82/wdfpck.cpp__.htm).

The WDF file is structured has followed :

### Header
```c#
[uint] WDF Header (0x57444650)
[int] fileCount
[uint] fileListOffset
```
	
### Entries
```c#
[uint] fileHashId
[uint] offset
[int] size
[uint] reserved
```
### Data

All data

----


The WDF files can be considered as "packages" containing one or several files. Just like a standard `zip` archive. The difference is that the name of all entries are hashed using a Hash algorithm (string_to_id). 

## How to use the WindsoulDataFile library ?

Download the package from NuGet : **[Soon]**

Open a new `WindsoulFile` :

```c#
using WindsoulDatFile;

using (var windsoul = new WindsoulFile("file.wdf"))
{
    // Display the number of files that the package contains
    System.Console.WriteLine("File Count: {0}", windsoul.Count);
    
    foreach (var fileEntry in windsoul.Files)
    {
        // Loop through files
    }
    
    // TODO: do your stuff
}
```
