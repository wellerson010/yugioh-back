using Back.DTO.API;
using Back.Models.Enumns;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Back.Services
{
    public class APIService
    {
        public async Task<IList<YgoProDeckAPICardDTO>> SynchronizeAll()
        {
            string url = "https://db.ygoprodeck.com/api/v7/cardinfo.php?misc=Yes";

            YgoProDeckAPIContainerCardDTO response = await new HTTPService().Get<YgoProDeckAPIContainerCardDTO>(url);

            IList<YgoProDeckAPICardDTO> data = response.data;

            return data;
        }

        public async Task<IList<YgoProDeckAPIArchetypeDTO>> SynchronizeArchetypes()
        {
            string url = "https://db.ygoprodeck.com/api/v7/archetypes.php";

            IList<YgoProDeckAPIArchetypeDTO> archetypes = await new HTTPService().Get<IList<YgoProDeckAPIArchetypeDTO>>(url);

            return archetypes;
        }

        private CardType TransformTypeToEnum(string type)
        {
            switch (type)
            {
                case "Effect Monster":
                    return CardType.EffectMonster;
                case "Flip Effect Monster":
                    return CardType.FlipEffectMonster;
                case "Flip Tuner Effect Monster":
                    return CardType.FlipTunerEffectMonster;
                case "Gemini Monster":
                    return CardType.GeminiMonster;
                case "Normal Monster":
                    return CardType.NormalMonster;
                case "Normal Tuner Monster":
                    return CardType.NormalTunerMonster;
                case "Pendulum Effect Monster":
                    return CardType.PendulumEffectMonster;
                case "Pendulum Flip Effect Monster":
                    return CardType.PendulumFlipEffectMonster;
                case "Pendulum Normal Monster":
                    return CardType.PendulumNormalMonster;
                case "Pendulum Tuner Effect Monster":
                    return CardType.PendulumTunerEffectMonster;
                case "Ritual Effect Monster":
                    return CardType.RitualEffectMonster;
                case "Ritual Monster":
                    return CardType.RitualMonster;
                case "Skill Card":
                    return CardType.SkillCard;
                case "Spell Card":
                    return CardType.SpellCard;
                case "Spirit Monster":
                    return CardType.SpiritMonster;
                case "Toon Monster":
                    return CardType.ToonMonster;
                case "Trap Card":
                    return CardType.TrapCard;
                case "Tuner Monster":
                    return CardType.TunerMonster;
                case "Union Effect Monster":
                    return CardType.UnionEffectMonster;
                case "Fusion Monster":
                    return CardType.FusionMonster;
                case "Link Monster":
                    return CardType.LinkMonster;
                case "Pendulum Effect Fusion Monster":
                    return CardType.PendulumEffectFusionMonster;
                case "Synchro Monster":
                    return CardType.SynchroMonster;
                case "Synchro Pendulum Effect Monster":
                    return CardType.SynchroPendulumEffectMonster;
                case "Synchro Tuner Monster":
                    return CardType.SynchroTunerMonster;
                case "XYZ Monster":
                    return CardType.XYZMonster;
                case "XYZ Pendulum Effect Monster":
                    return CardType.XYZPendulumEffectMonster;
                default:
                    return CardType.Undefined;
            }
        }

        private CardRace TransformRaceToEnum(string race)
        {
            switch (race)
            {
                case "Aqua":
                    return CardRace.Aqua;
                case "Beast":
                    return CardRace.Beast;
                case "Beast-Warrior":
                    return CardRace.BeastWarrior;
                case "Creator-God":
                    return CardRace.CreatorGod;
                case "Cyberse":
                    return CardRace.Cyberse;
                case "Dinosaur":
                    return CardRace.Dinosaur;
                case "Divine-Beast":
                    return CardRace.DivineBeast;
                case "Dragon":
                    return CardRace.Dragon;
                case "Fairy":
                    return CardRace.Fairy;
                case "Fiend":
                    return CardRace.Fiend;
                case "Fish":
                    return CardRace.Fish;
                case "Insect":
                    return CardRace.Insect;
                case "Machine":
                    return CardRace.Machine;
                case "Plant":
                    return CardRace.Plant;
                case "Psychic":
                    return CardRace.Psychic;
                case "Pyro":
                    return CardRace.Pyro;
                case "Reptile":
                    return CardRace.Reptile;
                case "Rock":
                    return CardRace.Rock;
                case "Sea Serpent":
                    return CardRace.SeaSerpent;
                case "Spellcaster":
                    return CardRace.Spellcaster;
                case "Thunder":
                    return CardRace.Thunder;
                case "Warrior":
                    return CardRace.Warrior;
                case "Winged Beast":
                    return CardRace.WingedBeast;
                case "Normal":
                    return CardRace.Normal;
                case "Field":
                    return CardRace.Field;
                case "Equip":
                    return CardRace.Equip;
                case "Continuous":
                    return CardRace.Continuous;
                case "Quick-Play":
                    return CardRace.QuickPlay;
                case "Ritual":
                    return CardRace.Ritual;
                case "Counter":
                    return CardRace.Counter;
                default:
                    return CardRace.Undefined;
            }
        }

        private CardAttribute TransformAttributeToEnum(string attribute)
        {
            switch (attribute){
                case "WIND":
                    return CardAttribute.Wind;
                case "WATER":
                    return CardAttribute.Water;
                case "DARK":
                    return CardAttribute.Dark;
                case "LIGHT":
                    return CardAttribute.Light;
                case "EARTH":
                    return CardAttribute.Earth;
                case "DIVINE":
                    return CardAttribute.Divine;
                case "FIRE":
                    return CardAttribute.Fire;
                default:
                    return CardAttribute.Undefined;
            }
        }

        private IList<CardLinkMarker> TransformCardLinkMarkersToEnum(IList<string> markers)
        {
            IList<CardLinkMarker> responseMarkers = markers.Select(x => TransformCardLinkMarkerToEnum(x)).ToList();

            return responseMarkers;
        }

        private DateTime TransformDate(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return DateTime.MinValue;
            }

            try { 
                DateTime date = DateTime.ParseExact(text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                return date;
            }
            catch (Exception e)
            {
                return DateTime.MinValue;
            }
        }

        private CardLinkMarker TransformCardLinkMarkerToEnum(string marker)
        {
            switch (marker)
            {
                case "Top":
                    return CardLinkMarker.Top;
                case "Bottom":
                    return CardLinkMarker.Bottom;
                case "Left":
                    return CardLinkMarker.Left;
                case "Right":
                    return CardLinkMarker.Right;
                case "Bottom-Left":
                    return CardLinkMarker.BottomLeft;
                case "Bottom-Right":
                    return CardLinkMarker.BottomRight;
                case "Top-Left":
                    return CardLinkMarker.TopLeft;
                case "Top-Right":
                    return CardLinkMarker.TopRight;
                default:
                    return CardLinkMarker.Undefined;
            }
        }
    }
}

