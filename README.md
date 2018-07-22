# Bookcase [![](http://cf.way2muchnoise.eu/297252.svg)](https://stardewvalley.curseforge.com/projects/297252)

Bookcase is a core API mod for Stardew Valley. The aim of this mod is to provide other moders with helpful utilities and improve general compatability between mods.

## Features

- Log - This class allows you to create a logger for your mod with wrappers for different log levels.
- Utilities - There are many utility classes and helper methods. They can be found in Bookcase.Utils.
- Events - This mod gives mods event hooks which they can use. See Bookcase.Events.BookcaseEvents for a full list.

## Getting Started

Note: These steps are written with Visual Studio as the IDE. They should work for other IDEs as well, however they may not use the same names or layouts. 

### Prerequisites
- You should already know how to create a Stardew Valley mod using SMAPI. You can find more info about that [here](https://gist.github.com/darkhax/3acb02667bcaa450f8276c514c9dd82e).
- You will need Stardew Valley and SMAPI installed on your computer. They should both be for the version of the game you are targeting.

### Adding Bookcase
1. Download Bookcase from the [official download site](https://stardewvalley.curseforge.com/projects/bookcase). It is recommended that you download the latest stable release.
2. Install Bookcase by extracting the Zip into the Stardew Valley mods folder. 
3. Run Stardew Valley using SMAPI and confirm that Bookcase is shown in the console.
4. In Visual Studio, right click on References in the solution explorer for your project.
5. Click on `Add References...`
6. Click on Browse on the left side, then on `Browse...` on the bottom right.
7. Navigate to the Bookcase.dll file you installed in step 2 and add it as a reference.
8. Expand References in the Solution Explorer.
9. Locate Bookcase in the reference list and click on it.
10. On the bottom of the explorer, in the properties section, set `Copy Local` to `False`.
11. Open up your manifest.json and add Bookcase as a dependency.

```json
	"Dependencies": [{
		"UniqueID": "darkhax.bookcase",
		"MinimumVersion": "MIN_VERSION_HERE"
	}]
```

### Confirming / Using Bookcase Classes
If you have sucessfully added Bookcase to your project, you should now be able to reference Bookcase classes. You can test this by adding the following to one of your classes.

```cs
using Bookcase.Utils
```

Adding this will give the class access to all the util classes such as ItemUtils. If you don't get an error on this it means you have installed everything correctly.