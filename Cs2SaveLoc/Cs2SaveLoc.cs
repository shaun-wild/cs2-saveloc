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

public class Cs2SaveLoc : BasePlugin
{
    public override string ModuleName => "Cs2SaveLoc Plugin";

    public override string ModuleVersion => "0.0.1";

    private readonly Dictionary<int, PlayerLocation> _savedLocations = new();

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

        _savedLocations[player.Slot] = new PlayerLocation
        {
            Position = new Vector(pawn.AbsOrigin!.X, pawn.AbsOrigin.Y, pawn.AbsOrigin.Z),
            Rotation = new QAngle(pawn.AbsRotation!.X, pawn.AbsRotation.Y, pawn.AbsRotation.Z),
            Velocity = new Vector(pawn.AbsVelocity!.X, pawn.AbsVelocity.Y, pawn.AbsVelocity.Z)
        };

        player.PrintToChat(" [Cs2SaveLoc] Location saved!");
    }

    [ConsoleCommand("css_loadloc", "Load saved location")]
    [ConsoleCommand("loadloc", "Load saved location")]
    public void OnLoadLoc(CCSPlayerController? player, CommandInfo command)
    {
        if (player == null || !player.IsValid || player.IsBot) return;

        if (!_savedLocations.TryGetValue(player.Slot, out var location))
        {
            player.PrintToChat(" [Cs2SaveLoc] No saved location found!");
            return;
        }

        var pawn = player.PlayerPawn.Value;
        if (pawn == null || !pawn.IsValid) return;

        pawn.Teleport(location.Position, location.Rotation, location.Velocity);
        player.PrintToChat(" [Cs2SaveLoc] Location loaded!");
    }
}
