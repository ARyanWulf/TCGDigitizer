using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS_FOR_CSHARP
{
    //=======================================================================
    //index enum for database information retrieval
    //=======================================================================
    //Database Card Table
    enum DBcard { id, c_time, name, type, mana_cost,
        expansion, foil, prerelease, location, multiverse_id,
        power, toughness, subtype, color, identity,
        text, cmc, flavor, rarity, border,
        loyalty, artist, types, supertypes, set_num};

    //Database Card Table
    enum DBuser { id, fname, lname, priv_lvl, c_time, log_name, log_pass };

    //Database Card Table
    enum DBtrans { id, card_id, user_id, c_data, trans_type };
    
    //Database Card Table
    enum DBinvent { id, card_id, inv_count};
    //=======================================================================

    public class CharColor
    {
        public char colorChar { get; set; }
        public Color cardColor { get; set; }

        public CharColor(char ch, Color c)
        {
            colorChar = ch;
            cardColor = Color.FromArgb(c.A, c.R, c.G, c.B);
        }
    }


    //=======================================================================
    //Card Objects used during JSON parce
    //=======================================================================
    //not currently being used but necessary for JSON parsing
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
        public string artist { get; set; }//artist name
        public string borderColor { get; set; }//color of card border
        public List<string> colorIdentity { get; set; }//color identity of card
        public List<string> colors { get; set; }//card's colors
        public float convertedManaCost { get; set; }//card's converted mana cost
        public List<object> foreignData { get; set; }//maybe later with language support
        public string frameVersion { get; set; }//not currently being used
        public bool hasFoil { get; set; }//whether or not the card can be foil
        public bool hasNonFoil { get; set; }//whether or not the card can be non-foil
        public string layout { get; set; }//not currently being used
        public CardLegalities legalities { get; set; }//don't see a reason to keep
        public string manaCost { get; set; }//card's mana cost defined by color characters in braced e.g. "2{W}{B}" for 2 colorless, 1 White, and 1 Black mana
        public int multiverseId { get; set; }//card's multiverse id if present
        public string name { get; set; }//card's name
        public string number { get; set; }//card's number in the set
        public string originalText { get; set; }//not currently being used
        public string originalType { get; set; }//not currently being used
        public string power { get; set; }//holds card's power if present
        public List<string> printings { get; set; }//not currently being used
        public string rarity { get; set; }//card's rarity
        public List<object> rulings { get; set; }//don't see a reason to keep
        public string scryfallId { get; set; }//not currently being used
        public List<string> subtypes { get; set; }//holds card's subtypes if present
        public List<string> supertypes { get; set; }//holds card's supertypes if present
        public int tcgplayerProductId { get; set; }//not currently being used
        public string tcgplayerPurchaseUrl { get; set; }//not currently being used
        public string text { get; set; }//holds cards text if present
        public string toughness { get; set; }//holds card's toughness if present
        public string type { get; set; }//card's type e.g. "instant", "creature", "artifact creature", etc.
        public List<string> types { get; set; }//card's types
        public string uuid { get; set; }//not currently being used
        public List<string> variations { get; set; }//not currently being used
        public string flavorText { get; set; }//holds card's flavortext if present
        public bool? isAlternative { get; set; }//not currently being used
        public List<string> names { get; set; }//not currently being used
        public string watermark { get; set; }//not currently being used
        public string loyalty { get; set; }//holds card's loyalty if card is a planeswalker
        public bool? starter { get; set; }//not currently being used
        public int cardID;//holds card's card_id from local database
        public string setCode;//holds card's setcode
        public string imageURL;//holds card's image url from gatherer.com
    }

    //not currently being used but necessary for JSON parsing
    public class CardMeta
    {
        public string date { get; set; }
        public string version { get; set; }
    }

    //not currently being used but necessary for JSON parsing
    public class CardToken
    {
        public string artist { get; set; }
        public string borderColor { get; set; }
        public List<string> colorIdentity { get; set; }
        public List<string> colors { get; set; }
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

    //not currently being used but necessary for JSON parsing
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
    //=======================================================================




    //=======================================================================
    //Set Object for JSON set parce
    //=======================================================================
    // setlist object for https://mtgjson.com/json/AllSets.json
    public class SetObject
    {
        public string code { get; set; }
        public string name { get; set; }
        public string releaseDate { get; set; }
    }
    //=======================================================================

    //=======================================================================
    //UserWrapper for holding user information before comitting to database
    //=======================================================================
    public class userWrapper
    {
        public string first, last, prvlg;

        //constructor
        public userWrapper()
        {
            first = "";
            last = "";
            prvlg = "";
        }

        //deconstructor
        ~userWrapper()
        {
        }
    };
}
