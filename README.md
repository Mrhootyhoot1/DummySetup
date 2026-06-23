# DummySetup
An SCP SL plugin used to add extra RA buttons to set up roles.

## Installation 
1. Download the latest release found here [https://github.com/Mrhootyhoot1/DummySetup/releases] and drop the file into {PATHTOEXILED}/Plugins.
2. Download the RA Custom Menu plugin's exiled release here [https://github.com/Bankokwak/RaCustomMenu/releases/tag/1.1.3] and drop the file into {PATHTOEXILED}/Plugins.
3. Add the permission "rcm.actions" to any roles you wish to have the ability to use the buttons created by this plugin to your permissions file.
4. Restart your server. This will generate a default config file with an example role at the path {PATHTOEXILED}/Configs/DummySetup/DummySetupRoles.yaml.
5. Configure roles in the DummySetupRoles.yaml file. Once you have configured the roles, restart the server for them to take effect.

## On Role Set Commands
The following will be replaced with certain values determined at runtime when put into a command to be executed when the role is set.\
"The player" references the player who's role is being set.<br>

%PLAYERID% - The id of the player.\
%PLAYERDISPLAYNAME% - The display nickname of the player.\
%PLAYERNAME% - The name of the player. This is independent from any nickname set in SL.\
%PLAYERUSERID% - The steam64 id of the player.\
%PLAYERIP% - The IP Address of the player.\
%ROLENAME% - The name of the role that the player is being set to.\
%CATEGORY% - The category of the role that the player is being set to.\

## Dependencies
[https://github.com/Bankokwak/RaCustomMenu]\
RACustomMenu is Copyright (c) 2025 Bankokwak\

