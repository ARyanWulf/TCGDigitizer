using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS_FOR_CSHARP
{
    public class CardLegalities
    {
        public string __invalid_name__1v1 { get; set; }
        public string commander { get; set; }
        public string duel { get; set; }
        public string legacy { get; set; }
        public string modern { get; set; }
        public string penny { get; set; }
        public string vintage { get; set; }
        public string pauper { get; set; }
        public string brawl { get; set; }
        public string frontier { get; set; }
        public string future { get; set; }
        public string standard { get; set; }
    }

    public class CardObject
    {
        public string artist { get; set; }//
        public string borderColor { get; set; }//
        public List<object> colorIdentity { get; set; }//
        public List<object> colors { get; set; }//
        public double convertedManaCost { get; set; }//
        public List<object> foreignData { get; set; }//maybe later with language support
        public string frameVersion { get; set; }//not currently being used
        public bool hasFoil { get; set; }//not currently being used
        public bool hasNonFoil { get; set; }//not currently being used
        public string layout { get; set; }//not currently being used
        public CardLegalities legalities { get; set; }//don't see a reason to keep
        public string manaCost { get; set; }//
        public int multiverseId { get; set; }//
        public string name { get; set; }//
        public string number { get; set; }//
        public string originalText { get; set; }//not currently being used
        public string originalType { get; set; }//not currently being used
        public string power { get; set; }//
        public List<string> printings { get; set; }//not currently being used
        public string rarity { get; set; }//
        public List<object> rulings { get; set; }//don't see a reason to keep
        public string scryfallId { get; set; }//not currently being used
        public List<object> subtypes { get; set; }//
        public List<object> supertypes { get; set; }//
        public int tcgplayerProductId { get; set; }//not currently being used
        public string tcgplayerPurchaseUrl { get; set; }//not currently being used
        public string text { get; set; }//
        public string toughness { get; set; }//
        public string type { get; set; }//
        public List<string> types { get; set; }//
        public string uuid { get; set; }//not currently being used
        public List<string> variations { get; set; }//not currently being used
        public string flavorText { get; set; }//
        public bool? isAlternative { get; set; }//not currently being used
        public List<object> names { get; set; }//not currently being used
        public string watermark { get; set; }//not currently being used
        public string loyalty { get; set; }//
        public bool? starter { get; set; }//not currently being used
    }

    public class CardMeta
    {
        public string date { get; set; }
        public string version { get; set; }
    }

    public class CardToken
    {
        public string artist { get; set; }
        public string borderColor { get; set; }
        public List<object> colorIdentity { get; set; }
        public List<object> colors { get; set; }
        public string name { get; set; }
        public string number { get; set; }
        public string power { get; set; }
        public List<string> reverseRelated { get; set; }
        public string scryfallId { get; set; }
        public string toughness { get; set; }
        public string type { get; set; }
        public string uuid { get; set; }
        public string text { get; set; }
    }

    // not currently being used
    public class CardRootObject
    {
        public int baseSetSize { get; set; }
        public string block { get; set; }
        public List<object> boosterV3 { get; set; }
        public List<CardObject> cards { get; set; }
        public string code { get; set; }
        public CardMeta meta { get; set; }
        public string mtgoCode { get; set; }
        public string name { get; set; }
        public string releaseDate { get; set; }
        public int tcgplayerGroupId { get; set; }
        public List<CardToken> tokens { get; set; }
        public int totalSetSize { get; set; }
        public string type { get; set; }
    }

    // setlist object for https://mtgjson.com/json/AllSets.json
    public class SetObject
    {
        public string code { get; set; }
        public string name { get; set; }
        public string releaseDate { get; set; }
    }




}
