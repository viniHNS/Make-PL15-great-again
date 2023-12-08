import { DependencyContainer } from "tsyringe";
import { IPostDBLoadMod } from "@spt-aki/models/external/IPostDBLoadMod";
import { DatabaseServer } from "@spt-aki/servers/DatabaseServer";
import { IPreAkiLoadMod } from "@spt-aki/models/external/IPreAkiLoadMod";
import { ILogger } from "@spt-aki/models/spt/utils/ILogger";
import { LogTextColor } from "@spt-aki/models/spt/logging/LogTextColor";

class Mod implements IPostDBLoadMod, IPreAkiLoadMod
{
    preAkiLoad(container: DependencyContainer): void 
    {
        // get the logger from the server container
        const logger = container.resolve<ILogger>("WinstonLogger");
        logger.logWithColor("Making the PL-15 great again!", LogTextColor.GREEN);
    }

    public postDBLoad(container: DependencyContainer): void 
    {
        // get database from server
        const databaseServer = container.resolve<DatabaseServer>("DatabaseServer");

        // Get all the in-memory json found in /assets/database
        const tables = databaseServer.getTables();

        // Find the PL-15 item by its Id
        const pl15 = tables.templates.items["602a9740da11d6478d5a06dc"];
        const pl15Slide = tables.templates.items["60228924961b8d75ee233c32"];
        const alphaDogSupressor = tables.templates.items["5a33a8ebc4a282000c5a950d"];
       
        // Adds sights mounts from others pistols
        pl15Slide._props.Slots[0]._props.filters[0].Filter.push("56ea7293d2720b8d4b8b45ba"); // P226 Sight Mount 220-239 rear sight bearing
        pl15Slide._props.Slots[0]._props.filters[0].Filter.push("5cadd954ae921500103bb3c2"); // M9A3 Sight Mount rear sight rail
        pl15Slide._props.Slots[0]._props.filters[0].Filter.push("61963a852d2c397d660036ad"); // HK USP Red Dot sight mount

        // Adds rear sights from others pistols
        pl15Slide._props.Slots[0]._props.filters[0].Filter.push("5a7d912f159bd400165484f3"); // Glock TruGlo TFX rear sight
        pl15Slide._props.Slots[0]._props.filters[0].Filter.push("5a6f5d528dc32e00094b97d9"); // Glock rear sight 
        pl15Slide._props.Slots[0]._props.filters[0].Filter.push("630765cb962d0247b029dc45"); // Glock 19X rear sight
        pl15Slide._props.Slots[0]._props.filters[0].Filter.push("5a71e0fb8dc32e00094b97f2"); // Glock ZEV Tech rear sight
        pl15Slide._props.Slots[0]._props.filters[0].Filter.push("5a7d9122159bd4001438dbf4"); // Glock Dead Ringer Snake Eye rear sight
        

        // Adds front sights from others pistols
        pl15Slide._props.Slots[1]._props.filters[0].Filter.push("5a7d9104159bd400134c8c21"); // Glock TruGlo TFX front sight
        pl15Slide._props.Slots[1]._props.filters[0].Filter.push("5a6f58f68dc32e000a311390"); // Glock front sight 
        pl15Slide._props.Slots[1]._props.filters[0].Filter.push("630765777d50ff5e8a1ea718"); // Glock 19X front sight
        pl15Slide._props.Slots[1]._props.filters[0].Filter.push("5a71e0048dc32e000c52ecc8"); // Glock ZEV Tech front sight
        pl15Slide._props.Slots[1]._props.filters[0].Filter.push("5a7d90eb159bd400165484f1"); // Glock Dead Ringer Snake Eye front sight

        alphaDogSupressor._props.Slots[0]._props.filters[0].Filter.push("5a37ca54c4a282000d72296a"); // JP Enterprises Flat-Top 30mm ring scope mount
        alphaDogSupressor._props.Slots[0]._props.filters[0].Filter.push("57c69dd424597774c03b7bbc"); // Lobaev Arms 30mm scope mount
        alphaDogSupressor._props.Slots[0]._props.filters[0].Filter.push("5aa66a9be5b5b0214e506e89"); // Nightforce Magmount 34mm ring scope mount
        alphaDogSupressor._props.Slots[0]._props.filters[0].Filter.push("5aa66c72e5b5b00016327c93"); // Nightforce 34mm Mount for installation of sights with Multimount
        alphaDogSupressor._props.Slots[0]._props.filters[0].Filter.push("5b2389515acfc4771e1be0c0"); // 
        alphaDogSupressor._props.Slots[0]._props.filters[0].Filter.push("5b3b99265acfc4704b4a1afb"); // Nightforce Magmount 30mm ring scope mount
        alphaDogSupressor._props.Slots[0]._props.filters[0].Filter.push("5dff77c759400025ea5150cf"); // Leapers UTG 25mm ring scope mount
        alphaDogSupressor._props.Slots[0]._props.filters[0].Filter.push("61713cc4d8e3106d9806c109"); // Recknagel Era-Tac 34mm ring scope mount
        alphaDogSupressor._props.Slots[0]._props.filters[0].Filter.push("6171407e50224f204c1da3c5"); // Recknagel Era-Tac 30mm ring scope mount
        alphaDogSupressor._props.Slots[0]._props.filters[0].Filter.push("618b9643526131765025ab35"); // Geissele Super Precision 30mm ring scope mount
        alphaDogSupressor._props.Slots[0]._props.filters[0].Filter.push("618bab21526131765025ab3f"); // Geissele Super Precision 30mm ring scope mount (DDC)
        
        // change deviation
        pl15._props.DeviationMax = 9;
    }
}

module.exports = { mod: new Mod() }