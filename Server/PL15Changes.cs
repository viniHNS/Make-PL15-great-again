using SPTarkov.Common.Models.Logging;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Spt.Tables;

namespace MakePL15GreatAgain;

/// <summary>
/// Lets the PL-15 slide accept Glock sights and some sight mounts, and lowers the pistol's deviation (MOA).
/// </summary>
[Injectable(TypePriority = OnLoadOrder.PostLoad + 1)]
public class PL15Changes(
    ISptLogger<PL15Changes> logger,
    TemplateTable templateTable) : IOnLoad
{
    private static readonly MongoId Pl15Tpl = "602a9740da11d6478d5a06dc";
    private static readonly MongoId Pl15SlideTpl = "60228924961b8d75ee233c32";

    private const string RearSightSlot = "mod_sight_rear";
    private const string FrontSightSlot = "mod_sight_front";

    private const double NewDeviationMax = 9;

    private static readonly MongoId[] NewRearSights =
    [
        "56ea7293d2720b8d4b8b45ba", // P226 Sight Mount 220-239 rear sight bearing
        "5cadd954ae921500103bb3c2", // M9A3 Sight Mount rear sight rail
        "61963a852d2c397d660036ad", // HK USP Red Dot sight mount
        "5a7d912f159bd400165484f3", // Glock TruGlo TFX rear sight
        "5a6f5d528dc32e00094b97d9", // Glock rear sight
        "630765cb962d0247b029dc45", // Glock 19X rear sight
        "5a71e0fb8dc32e00094b97f2", // Glock ZEV Tech rear sight
        "5a7d9122159bd4001438dbf4", // Glock Dead Ringer Snake Eye rear sight
    ];

    private static readonly MongoId[] NewFrontSights =
    [
        "5a7d9104159bd400134c8c21", // Glock TruGlo TFX front sight
        "5a6f58f68dc32e000a311390", // Glock front sight
        "630765777d50ff5e8a1ea718", // Glock 19X front sight
        "5a71e0048dc32e000c52ecc8", // Glock ZEV Tech front sight
        "5a7d90eb159bd400165484f1", // Glock Dead Ringer Snake Eye front sight
    ];

    public Task OnLoadAsync(CancellationToken cancellationToken)
    {
        logger.Success("[ViniHNS] Making the PL-15 great again!");

        var items = templateTable.Items;

        if (!items.TryGetValue(Pl15Tpl, out var pl15) || !items.TryGetValue(Pl15SlideTpl, out var pl15Slide))
        {
            logger.Error($"Could not find PL-15 ({Pl15Tpl}) or its slide ({Pl15SlideTpl}). Aborting.");
            return Task.CompletedTask;
        }

        AddToSlotFilter(pl15Slide, RearSightSlot, NewRearSights);
        AddToSlotFilter(pl15Slide, FrontSightSlot, NewFrontSights);

        if (pl15.Properties != null)
        {
            pl15.Properties.DeviationMax = NewDeviationMax;
        }
        else
        {
            logger.Error($"PL-15 ({Pl15Tpl}) has no properties, deviation not changed.");
        }

        logger.Info("PL-15 modded successfully!");

        return Task.CompletedTask;
    }

    private void AddToSlotFilter(TemplateItem item, string slotName, IEnumerable<MongoId> newTpls)
    {
        var filter = item.Properties?.Slots?
            .FirstOrDefault(slot => slot.Name == slotName)?
            .Properties?.Filters?
            .FirstOrDefault()?
            .Filter;

        if (filter == null)
        {
            logger.Error($"Slot '{slotName}' not found on {item.Id}, sights not added.");
            return;
        }

        foreach (var tpl in newTpls)
        {
            filter.Add(tpl);
        }
    }
}
