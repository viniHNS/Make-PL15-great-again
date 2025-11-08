using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Common;            // MongoId
using SPTarkov.Server.Core.Models.Eft.Common.Tables; // TemplateItem, TemplateItemProperties
using SPTarkov.Server.Core.Models.Spt.Mod;           // AbstractModMetadata, IOnLoad, OnLoadOrder, NewItemFromCloneDetails, LocaleDetails
using SPTarkov.Server.Core.Models.Utils;             // SemanticVersioning
using SPTarkov.Server.Core.Servers;                  // DatabaseServer
using SPTarkov.Server.Core.Services.Mod;             // CustomItemService
using SPTarkov.Server.Core.Services;
using IOPath = System.IO.Path;

namespace makepl15greatagain;

/// <summary>
/// This is the replacement for the former package.json data. This is required for all mods.
///
/// This is where we define all the metadata associated with this mod.
/// You don't have to do anything with it, other than fill it out.
/// All properties must be overriden, properties you don't use may be left null.
/// It is read by the mod loader when this mod is loaded.
/// </summary>
public record ModMetadata : AbstractModMetadata
{
    /// <summary>
    /// Any string can be used for a modId, but it should ideally be unique and not easily duplicated
    /// a 'bad' ID would be: "mymod", "mod1", "questmod"
    /// It is recommended (but not mandatory) to use the reverse domain name notation,
    /// see: https://docs.oracle.com/javase/tutorial/java/package/namingpkgs.html
    /// </summary>
    public override string ModGuid { get; init; } = "com.vinihns.makepl15greatagain"; // ID único para seu mod
    public override string Name { get; init; } = "Make PL-15 Great Again";
    public override string Author { get; init; } = "ViniHNS";
    public override SemanticVersioning.Version Version { get; init; } = new("1.4.0");
    public override SemanticVersioning.Range SptVersion { get; init; } = new("~4.0.0");
    public override List<string>? Contributors { get; init; }
    public override List<string>? Incompatibilities { get; init; }
    public override Dictionary<string, SemanticVersioning.Range>? ModDependencies { get; init; }
    public override string? Url { get; init; }
    public override bool? IsBundleMod { get; init; }
    public override string? License { get; init; } = "MIT";
}

// We want to load after PostDBModLoader is complete, so we set our type priority to that, plus 1.
[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class Mod(
    ISptLogger<Mod> logger, // We are injecting a logger similar to example 1, but notice the class inside <> is different
    DatabaseService databaseService)
    : IOnLoad // Implement the `IOnLoad` interface so that this mod can do something
{
    
    private const string PL15_TPL = "602a9740da11d6478d5a06dc";
    private const string PL15_SLIDE_TPL = "60228924961b8d75ee233c32";
    
    public Task OnLoad()
    {
        logger.Success("[ViniHNS] Making the PL-15 great again!");

        var items = databaseService.GetItems();
        
        if (!items.TryGetValue(PL15_TPL, out var pl15) || !items.TryGetValue(PL15_SLIDE_TPL, out var pl15Slide))
        {
            logger.Error($"Could not find PL-15 ({PL15_TPL}) or its slide ({PL15_SLIDE_TPL}). Aborting.");
            return Task.CompletedTask;
        }

        // --- SOLUÇÃO CORRETA ---

        // Pega o HashSet<MongoId> de filtros de cada slot
        var rearSightFilterSet = pl15Slide.Properties.Slots.ElementAt(0).Properties.Filters.First().Filter;
        var frontSightFilterSet = pl15Slide.Properties.Slots.ElementAt(1).Properties.Filters.First().Filter;

        // Define as listas de novos TPLs (como strings)
        var newRearSightIds = new List<string>
        {
            "56ea7293d2720b8d4b8b45ba", 
            "5cadd954ae921500103bb3c2", 
            "61963a852d2c397d660036ad", 
            "5a7d912f159bd400165484f3", 
            "5a6f5d528dc32e00094b97d9",
            "630765cb962d0247b029dc45", 
            "5a71e0fb8dc32e00094b97f2", 
            "5a7d9122159bd4001438dbf4"  
        };

        var newFrontSightIds = new List<string>
        {
            "5a7d9104159bd400134c8c21", 
            "5a6f58f68dc32e000a311390", 
            "630765777d50ff5e8a1ea718", 
            "5a71e0048dc32e000c52ecc8", 
            "5a7d90eb159bd400165484f1"  
        };
        
        foreach (var id in newRearSightIds)
        {
            rearSightFilterSet.Add(new MongoId(id));
        }

        foreach (var id in newFrontSightIds)
        {
            frontSightFilterSet.Add(new MongoId(id));
        }
        
        pl15.Properties.DeviationMax = 9;

        logger.Info("PL-15 modded successfully!");

        return Task.CompletedTask;
    }
}
