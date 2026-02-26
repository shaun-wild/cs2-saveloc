# Cs2SaveLoc

A CounterStrikeSharp plugin for Counter-Strike 2 that allows players to save and load their locations. This is particularly useful for practice, testing, or just having fun on a private server.

## Features

- Save a stack of your current position, rotation, and velocity (up to 5 locations).
- Teleport back to any saved location in your stack.
- Individual saved location stacks for each player.
- Supports both `css_` prefixed and non-prefixed commands.

## Commands

| Command | Description |
| --- | --- |
| `saveloc` / `css_saveloc` | Saves your current location to the top of your stack (max 5) and resets last loaded index to 0. |
| `loadloc [index]` / `css_loadloc [index]` | Teleports you to a saved location. Defaults to the last loaded index (or 0 if none). |

## Installation

1. Install [CounterStrikeSharp](https://github.com/roflmuffin/CounterStrikeSharp).
2. Download the latest `cs2-saveloc-plugin.zip` from the [Releases](https://github.com/yourusername/cs2-saveloc/releases) page.
3. Extract the contents of the zip into the `game/csgo/` directory of your CS2 server.
   - The DLL should end up at `game/csgo/addons/counterstrikesharp/plugins/cs2-saveloc/Cs2SaveLoc.dll`.
4. Restart the server or hot-reload the plugins.

## Requirements

- .NET 8.0 Runtime
- Counter-Strike 2
- CounterStrikeSharp

## Building from Source

To build the plugin yourself, follow these steps:

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/cs2-saveloc.git
   ```
2. Navigate to the project directory:
   ```bash
   cd cs2-saveloc
   ```
3. Build the project using the .NET CLI:
   ```bash
   dotnet build
   ```
   The compiled DLL will be located in `Cs2SaveLoc/bin/Debug/net8.0/Cs2SaveLoc.dll`.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details (if applicable).
