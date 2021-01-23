# Untitled Engine
This is a Game Maker like game engine written just for fun.

## Components

### Objects
Each object have blocks to execute on specific event.
It should have a name, sprite (optional), draw code (optional).
### Sounds
Each sound just contains it's path.
### Rooms
Each room have it's own objects (stored X, Y, ID)
Room is a grid of objects.

## Compiling
Currently player just loads the game from project (yes, everyone can get the project)

Maybe in the future I will add *data.ueg*. File extension is an abbreviation which stands for Untitled Engine Game. 
It will work like that (looped until the end of the file):
- Get 4 bytes containing asset's name length
- Read asset's name until the end
- Read asset's type (Types are "0x00" for sound, "0x0A" for object, "0x0F" for room, length is 1 byte)
- Get 4 bytes containing asset's data length
- Read asset's data:
  - Sounds: Just file's bytes
  - Objects:
    - Get 4 bytes containing object's sprite length
	- Read object's sprite
	- Read 1 byte containing visible attribute (00 false, FF true)
	- Read 1 byte containing active attribute (00 false, FF true)
	- Read 1 byte containing solid attribute (00 false, FF true)
	- Loop until next asset:
		- Read events's type (Types are *coming soon*, length is *??*)
		- Get 4 bytes containing event's blocks length
		- Loop until next event:
		  - Read block's type (Types are *coming soon*, length is *??*)
		  - Get 4 bytes containing block's data length
		  - Read block's data
  - Rooms
    - Loop until next asset:
	  - Get 4 bytes containing object's name length
	  - Read object's name
	  - Read 4 bytes containing initial object's X position
	  - Read 4 bytes containing initial object's Y position

**NOTE: Anything above this is just an idea how it will work. It applies to EVERYTHING.**


