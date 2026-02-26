# Cs2SaveLoc

A CounterStrikeSharp plugin for Counter-Strike 2 that allows players to save and load their locations. This is particularly useful for practice, testing, or just having fun on a private server.

## Features

- Save your current position, rotation, and velocity.
- Teleport back to your saved location at any time.
- Individual saved locations for each player.
- Supports both `css_` prefixed and non-prefixed commands.

## Commands

| Command | Description |
| --- | --- |
| `saveloc` / `css_saveloc` | Saves your current position, rotation, and velocity. |
| `loadloc` / `css_loadloc` | Teleports you back to your last saved location. |

## Installation

1. Install [CounterStrikeSharp](https://github.com/roflmuffin/CounterStrikeSharp).
2. Download the latest release of `Cs2SaveLoc`.
3. Extract the contents into the `game/csgo/addons/counterstrikesharp/plugins` directory of your CS2 server.
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
