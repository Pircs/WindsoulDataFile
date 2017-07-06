# WindsoulDataFile

[![Build Status](https://travis-ci.org/Eastrall/WindsoulDataFile.svg?branch=master)](https://travis-ci.org/Eastrall/WindsoulDataFile)

[Not available on NuGet yet]

WindsoulDataFile is a C# library for managing WDF files easily.

## What is Windsoul Data File ?

The Windsoul Data File (WDF) was originaly created by Cloud Wu within the Windsoul++ game programming library in 1999-2001. This file structure is mainly used in the `Conquer Online` game for storing resources (Maps, textures, etc...)

You can find the original `C++` source code [here](http://read.pudn.com/downloads76/sourcecode/game/281928/%E9%A3%8E%E9%AD%82/wdfpck.cpp__.htm).

The WDF file is structured has followed :

- **Header**
	- WDF Header (0x57444650)
	- File count
	- First file offset
- **Entries**
	- Id (Entry name hashed)
	- Start Address
	- Size
	- Reserved Space
- **Data**

The WDF files can be considered as "packages" containing one or several files. Just like a standard `zip` archive. The difference is that the name of all entries are hashed using a Hash algorithm (string_to_id). 

## How to use the WindsoulDataFile library ?

Download the package from NuGet : **[Soon]**

Open a new `WindsoulFile` :

```c#
using WindsoulDatFile;

using (var windsoul = new WindsoulFile("file.wdf"))
{
    // TODO: do your stuff
}
```
