using Back.DTO.API;
using Microsoft.Extensions.Configuration;
using Model.Models;
using Model.Enums;
using Model.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Model.Interfaces.Models;

namespace Back.Services
{
    public class SynchronizeService: ISynchronizeService
    {
        private readonly IRepository<Monster> MonsterRepository;
        private readonly IRepository<Magic> MagicRepository;
        private readonly IYgoProDeckAPIService YgoProDeckAPIService;
        Dictionary<string, string> racesNotFound = new Dictionary<string, string>();



        public SynchronizeService(IRepository<Monster> monsterRepository, IRepository<Magic> magicRepository, IYgoProDeckAPIService ygoProDeckApiService)
        {
            MonsterRepository = monsterRepository;
            MagicRepository = magicRepository;
            YgoProDeckAPIService = ygoProDeckApiService;
        }

        public async Task SynchronizeAllCards()
        {
            IList<YgoProDeckAPICardDTO> response = await YgoProDeckAPIService.GetAllCards();
            Dictionary<string, string> races = new Dictionary<string, string>();

            foreach (YgoProDeckAPICardDTO cardAPI in response)
            {
                ICard card = BuildCardFromAPI(cardAPI);

                if (!races.ContainsKey(cardAPI.race))
                {
                    races.Add(cardAPI.race, cardAPI.race);
                }

                if (card is Monster)
                {
                    await MonsterRepository.Save(card as Monster);
                }
                else
                {
                    await MagicRepository.Save(card as Magic);
                }
            }


        }

        private ICard BuildCardFromAPI(YgoProDeckAPICardDTO cardAPI)
        {
            CardType type = TransformTypeToEnum(cardAPI.type);

            if (type == CardType.Undefined)
            {
          //      throw new Exception("CardType não definido!");
            }

            ICard card;

            if (type == CardType.SkillCard || type == CardType.SpellCard || type == CardType.TrapCard)
            {
                card = new Magic();
            }
            else
            {
                card = new Monster();

                Monster monster = card as Monster;

                monster.Attribute = TransformAttributeToEnum(cardAPI.attribute);

                if (monster.Attribute == CardAttribute.Undefined)
                {
                //    throw new Exception("CardAttribute não definido!");
                }

                if (cardAPI.linkmarkers != null && cardAPI.linkmarkers.Count > 0)
                {
                    IList<CardLinkMarker> markers = TransformCardLinkMarkersToEnum(cardAPI.linkmarkers);
                    monster.LinkValue = cardAPI.linkval;
                }

                monster.ATK = cardAPI.atk;
                monster.DEF = cardAPI.def;
                monster.Level = cardAPI.level;
                monster.PendulumScale = cardAPI.scale;
            }

            if (cardAPI.card_images != null && cardAPI.card_images.Count > 0)
            {
                if (cardAPI.card_images.Count > 1)
                {

                }
            }
            else
            {

            }

            if (cardAPI.misc_info != null && cardAPI.misc_info.Count > 0)
            {
                if (cardAPI.misc_info.Count > 1)
                {

                }

                YgoProDeckAPIMiscInformationDTO miscInfo = cardAPI.misc_info.FirstOrDefault();
                card.Staple = (miscInfo.staple == "Yes");
                card.TCGDate = TransformDate(miscInfo.tcg_date);
                card.OCGDate = TransformDate(miscInfo.ocg_date);
            }
            else
            {

            }

            card.Race = TransformRaceToEnum(cardAPI.race);
            card.Passcode = cardAPI.id;
            card.Description = cardAPI.desc;
            card.Name = cardAPI.name;

            if (card.Race == CardRace.Undefined)
            {
                if (!racesNotFound.ContainsKey(cardAPI.race))
                {
                    racesNotFound.Add(cardAPI.race, cardAPI.race);
                }
            }

            return card;
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
                case "Token":
                    return CardType.Token;
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
                case "Wyrm":
                    return CardRace.Wyrm;
                case "Zombie":
                    return CardRace.Zombie;
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
            switch (attribute)
            {
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

            text = Regex.Replace(text, @"[^\d-]", "");

            try
            {
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

        /* public async Task SynchronizeCard(IConfiguration configuration, string name)
         {
             IList<YgoProDeckAPICardDTO> response = await new YgoProDeckAPIService().GetAllCards();

             foreach(var data in response)
             {
              //   Stream stream = await new HTTPService().GetByteFromUrl(response.card_images[0].image_url);


             //    await new CloudinaryAPIService(configuration["Cloudinary:CloudName"], configuration["Cloudinary:ApiKey"], configuration["Cloudinary:ApiSecret"]).UploadPicture("AAAA", stream);
             }

         }

         public async Task UploadAllPictures(IConfiguration configuration)
         {
             IList<YgoProDeckAPICardDTO> response = await new YgoProDeckAPIService().GetAllCards();

             foreach (var data in response)
             {
                 Stream stream = await new HTTPService().GetByteFromUrl(data.card_images[0].image_url);

                 await new CloudinaryAPIService(configuration["Cloudinary:CloudName"], configuration["Cloudinary:ApiKey"], configuration["Cloudinary:ApiSecret"]).UploadPicture("AAAA", stream);
             }

         }*/
    }
}
