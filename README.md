# nso-pc
NinjaSchool Online PC (v148) - Assembly source

### Can I modify game source?
This version written in C# (Unity & .Net core), almost actions do in client side and then send to server.
So you can modify anything you can do. Such as makes auto attack/pick items, long-range attack/pick, etc.


### Notice
Cannot delay the game, almost tasks must be run in another thread.
Can embed scripting language to use the APIs easier, like Lua with NLua.

### Classes

Name | Description
--|--
Main | Called first for load game resources
GameScr | Game activity
Char | Character/player
Mob | Target
Service | Message to server
Resources | Game resources (string, image, sound)
TileMap | Maps
mFont, mGraphics | Drawing
