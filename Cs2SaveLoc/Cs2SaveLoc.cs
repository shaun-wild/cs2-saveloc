using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Utils;

namespace Cs2SaveLoc;

public class PlayerLocation
{
    public Vector Position { get; set; } = new Vector();
    public QAngle Rotation { get; set; } = new QAngle();
    public Vector Velocity { get; set; } = new Vector();
}

public class PlayerData
{
    public List<PlayerLocation> Locations { get; set; } = new List<PlayerLocation>();
    public int LastLoadedIndex { get; set; } = 0;
}

public class Cs2SaveLoc : BasePlugin
{
    public override string ModuleName => "Cs2SaveLoc Plugin";

    public override string ModuleVersion => "0.0.2";

    private readonly Dictionary<int, PlayerData> _playerData = new();

    public override void Load(bool hotReload)
    {
        Console.WriteLine("Cs2SaveLoc Plugin Loaded!");
    }

    [ConsoleCommand("css_saveloc", "Save current location")]
    [ConsoleCommand("saveloc", "Save current location")]
    public void OnSaveLoc(CCSPlayerController? player, CommandInfo command)
    {
        if (player == null || !player.IsValid || player.IsBot) return;

        var pawn = player.PlayerPawn.Value;
        if (pawn == null || !pawn.IsValid) return;

        if (!_playerData.TryGetValue(player.Slot, out var data))
        {
            data = new PlayerData();
            _playerData[player.Slot] = data;
        }

        data.Locations.Insert(0, new PlayerLocation
        {
            Position = new Vector(pawn.AbsOrigin!.X, pawn.AbsOrigin.Y, pawn.AbsOrigin.Z),
            Rotation = new QAngle(pawn.AbsRotation!.X, pawn.AbsRotation.Y, pawn.AbsRotation.Z),
            Velocity = new Vector(pawn.AbsVelocity!.X, pawn.AbsVelocity.Y, pawn.AbsVelocity.Z)
        });

        if (data.Locations.Count > 5)
        {
            data.Locations.RemoveAt(5);
        }

        data.LastLoadedIndex = 0;

        player.PrintToChat(" [Cs2SaveLoc] Location saved!");
    }

    [ConsoleCommand("css_loadloc", "Load saved location")]
    [ConsoleCommand("loadloc", "Load saved location")]
    public void OnLoadLoc(CCSPlayerController? player, CommandInfo command)
    {
        if (player == null || !player.IsValid || player.IsBot) return;

        if (!_playerData.TryGetValue(player.Slot, out var data) || data.Locations.Count == 0)
        {
            player.PrintToChat(" [Cs2SaveLoc] No saved locations found!");
            return;
        }

        int index = data.LastLoadedIndex;
        if (command.ArgCount > 1)
        {
            if (!int.TryParse(command.ArgByIndex(1), out index) || index < 0 || index >= data.Locations.Count)
            {
                player.PrintToChat($" [Cs2SaveLoc] Invalid index! Please provide a number between 0 and {data.Locations.Count - 1}.");
                return;
            }
            data.LastLoadedIndex = index;
        }

        var location = data.Locations[index];

        var pawn = player.PlayerPawn.Value;
        if (pawn == null || !pawn.IsValid) return;

        pawn.Teleport(location.Position, location.Rotation, location.Velocity);
        player.PrintToChat(" [Cs2SaveLoc] Location loaded!");
    }
}
