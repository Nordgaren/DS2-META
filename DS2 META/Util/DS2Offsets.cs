using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS2_META
{
    internal class DS2Offsets
    {
        #region BaseA

        public const string BaseAAoB = "8B F1 8B 0D ? ? ? 01 8B 01 8B 50 28 FF D2 84 C0 74 0C";
        public const int BaseOffset1 = 0x4;
        public const int BaseOffset2 = 0x0;
        public const string BaseABabyJumpAoB = "49 BA ? ? ? ? ? ? ? ? 41 FF E2 90 74 2E";
        public const int BasePtrOffset1 = 0x3;
        public const int BasePtrOffset2 = 0x7;
        public const int PlayerTypeOffset = 0x90;
        public enum PlayerType
        {
            ChrNetworkPhantomId = 0x3C,
            TeamType = 0x3D,
            CharType = 0x48
        }
        public const int GameDataManagerOffset = 0x60;
        public enum PlayerName
        {
            Name = 0xA4
        }

        public const string ItemGiveFunc = "55 8B EC 83 EC 10 53 8B 5D 0C 56 8B 75 08 57 53 56 8B F9";
        public const int AvailableItemBagOffset = 0x8;
        public const int ItemGiveWindowPointer = 0x22E0;
        public const string ItemStruct2dDisplay = "40 53 48 83 EC 20 45 33 D2 45 8B D8 48 8B D9 44 89 11";
        public const string DisplayItem = "48 8B 89 D8 00 00 00 48 85 C9 0F 85 40 5E 00 00";

        public const int PlayerBaseMiscOffset = 0x60;
        public enum PlayerBaseMisc
        {
            Class = 0x64,
            NewGame = 0x68,
            //SaveSlot = 0x18A8
        }
        public const int PlayerCtrlOffset = 0x74;
        public enum PlayerCtrl
        {
            HP = 0xFC,
            HPMin = 0x100,
            HPMax = 0x104,
            HPCap = 0x108,
            SP = 0x140,
            SPMax = 0x148,
            SpeedModifier = 0x208,
        }
        public enum PlayerEquipment
        {
            Legs = 0x920,
            Arms = 0x90C,
            Chest = 0x8F8,
            Head = 0x8E4,
            RightHand1 = 0x880,
            RightHand2 = 0x8A8,
            RightHand3 = 0x8D0,
            LeftHand1 = 0x86C,
            LeftHand2 = 0x894,
            LeftHand3 = 0x8BC
        }

        public const int NetSvrBloodstainManagerOffset1 = 0x90; 
        public const int NetSvrBloodstainManagerOffset2 = 0x28; 
        public const int NetSvrBloodstainManagerOffset3 = 0x88;
        public enum NetSvrBloodstainManager
        {
            BloodstainY = 0x38,
            BloodstainZ = 0x3C,
            BloodstainX = 0x40
        }

        public const int PlayerParamOffset = 0x378;
        public enum PlayerParam
        {
            SoulMemory = 0xE8,
            SoulMemory2 = 0xF0,
            SoulMemory3 = 0xF8,
            MaxEquipLoad = 0x38,
            Souls = 0xE8,
            TotalDeaths = 0x1A0,
            HollowLevel = 0x1A8,
            SinnerLevel = 0x1D2,
            SinnerPoints = 0x1D3
        }
        public enum Attributes
        {
            SoulLevel = 0xCC,
            VGR = 0x4,
            END = 0x6,
            VIT = 0x8,
            ATN = 0xA,
            STR = 0xC,
            DEX = 0xE,
            ADP = 0x14,
            INT = 0x10,
            FTH = 0x12
        }
        public enum Covenants
        {
            CurrentCovenant = 0x1A9,
            HeirsOfTheSunDiscovered = 0x1AB,
            HeirsOfTheSunOfTheSunRank = 0x1B5,
            HeirsOfTheSunProgress = 0x1C0,
            BlueSentinelsDiscovered = 0x1AC,
            BlueSentinelsRank = 0x1B6,
            BlueSentinelsProgress = 0x1C2,
            BrotherhoodOfBloodDiscovered = 0x1AD, // probably wrong
            BrotherhoodOfBloodRank = 0x1B7, // also
            BrotherhoodOfBloodProgress = 0x1C7, // wrong
            WayOfTheBlueDiscovered = 0x1AE,
            WayOfTheBlueRank = 0x1B8,
            WayOfTheBlueProgress = 0x1C6,
            RatKingDiscovered = 0x1AF,
            RatKingRank = 0x1B9,
            RatKingProgress = 0x1C8,
            BellKeepersDiscovered = 0x1B0,
            BellKeepersRank = 0x1BA,
            BellKeepersProgress = 0x1CA,
            DragonRemnantsDiscovered = 0x1B1,
            DragonRemnantsRank = 0x1BB,
            DragonRemnantsProgress = 0x1CC,
            CompanyOfChampionsDiscovered = 0x1B2,
            CompanyOfChampionsRank = 0x1BC,
            CompanyOfChampionsProgress = 0x1CE,
            PilgrimsOfDarknessDiscovered = 0x1B3,
            PilgrimsOfDarknessRank = 0x1BD,
            PilgrimsOfDarknessProgress = 0x1D0
        }

        public const int PlayerPositionOffset1 = 0xB4;
        public const int PlayerPositionOffset2 = 0xA8;

        public enum PlayerPosition
        {
            PosY = 0x20,
            PosZ = 0x24,
            PosX = 0x28,
            AngY = 0x34,
            AngZ = 0x38,
            AngX = 0x3C
        }

        public const int GravityOffset1 = 0xB8;
        public const int GravityOffset2 = 0x8;
        public enum Gravity
        {
            Gravity = 0xFC
        }
        public const int PlayerMapDataOffset1 = 0x14;
        public const int PlayerMapDataOffset2 = 0x1B0;
        public const int PlayerMapDataOffset3 = 0x10;
        public enum PlayerMapData
        {
            WarpBase = 0x120,
            WarpY1 = 0x120,
            WarpZ1 = 0x124,
            WarpX1 = 0x128,
            WarpY2 = 0x130,
            WarpZ2 = 0x134,
            WarpX2 = 0x138,
            WarpY3 = 0x140,
            WarpZ3 = 0x144,
            WarpX3 = 0x148
        }

        public const int SpEffectCtrlOffset = 0x308;
        public const string ApplySpEffectAoB = "55 8B EC 53 56 8B D9 8B 73 1C 57";

        public const int CharacterFlagsOffset = 0x490;

        public const string GiveSoulsFuncAoB = "55 8B EC 8B 01 83 EC 08 85 C0 74 20 8B 80 94 00 00 00";

        public const string SetWarpTargetFuncAoB = "55 8B EC 83 EC 44 53 56 8B 75 0C 57 56 8D 4D 0C";
        public const string WarpFuncAoB = "55 8B EC 83 EC 40 53 56 8B 75 08 8B D9 57 B9 10 00 00 00";

        public const int EventManagerOffset = 0x44;
        public const int WarpManagerOffset = 0x2C;
        public enum Bonfire
        {
            LastSetBonfireAreaID = 0xB4,
            LastSetBonfire = 0xBC
        }
        public const int BonfireLevelsOffset1 = 0x58;
        public const int BonfireLevelsOffset2 = 0x20;
        public enum BonfireLevels
        {
            FireKeepersDwelling = 0x2,
            TheFarFire = 0x1A,
            CrestfallensRetreat = 0x62,
            CardinalTower = 0x32,
            SoldiersRest = 0x4A,
            ThePlaceUnbeknownst = 0x7A,
            HeidesRuin = 0x4B2,
            TowerofFlame = 0x49A,
            TheBlueCathedral = 0x4CA,
            UnseenPathtoHeide = 0x28A,
            ExileHoldingCells = 0x182,
            McDuffsWorkshop = 0x1CA,
            ServantsQuarters = 0x1E2,
            StraidsCell = 0x16A,
            TheTowerApart = 0x19A,
            TheSaltfort = 0x1FA,
            UpperRamparts = 0x1B2,
            UndeadRefuge = 0x362,
            BridgeApproach = 0x37A,
            UndeadLockaway = 0x392,
            UndeadPurgatory = 0x3AA,
            PoisonPool = 0x242,
            TheMines = 0x212,
            LowerEarthenPeak = 0x22A,
            CentralEarthenPeak = 0x25A,
            UpperEarthenPeak = 0x272,
            ThresholdBridge = 0x2BA,
            IronhearthHall = 0x2A2,
            EygilsIdol = 0x2D2,
            BelfrySolApproach = 0x2EA,
            OldAkelarre = 0x482,
            RuinedForkRoad = 0x4E2,
            ShadedRuins = 0x4FA,
            GyrmsRespite = 0x512,
            OrdealsEnd = 0x52A,
            RoyalArmyCampsite = 0x10A,
            ChapelThreshold = 0x122,
            LowerBrightstoneCove = 0xF2,
            HarvalsRestingPlace = 0x55A,
            GraveEntrance = 0x542,
            UpperGutter = 0x43A,
            CentralGutter = 0x40A,
            HiddenChamber = 0x422,
            BlackGulchMouth = 0x3F2,
            KingsGate = 0x302,
            UnderCastleDrangleic = 0x34A,
            ForgottenChamber = 0x332,
            CentralCastleDrangleic = 0x31A,
            TowerofPrayer = 0x92,
            CrumbledRuins = 0xAA,
            RhoysRestingPlace = 0xC2,
            RiseoftheDead = 0xDA,
            UndeadCryptEntrance = 0x3DA,
            UndeadDitch = 0x3C2,
            Foregarden = 0x13A,
            RitualSite = 0x152,
            DragonAerie = 0x452,
            ShrineEntrance = 0x46A,
            SanctumWalk = 0x572,
            PriestessChamber = 0x58A,
            HiddenSanctumChamber = 0x5BA,
            LairoftheImperfect = 0x5D2,
            SanctumInterior = 0x5EA,
            TowerofPrayerDLC = 0x602,
            SanctumNadir = 0x5A2,
            ThroneFloor = 0x61A,
            UpperFloor = 0x64A,
            Foyer = 0x632,
            LowermostFloor = 0x67A,
            TheSmelterThrone = 0x692,
            IronHallwayEntrance = 0x662,
            OuterWall = 0x6AA,
            AbandonedDwelling = 0x6C2,
            ExpulsionChamber = 0x70A,
            InnerWall = 0x722,
            LowerGarrison = 0x6DA,
            GrandCathedral = 0x6F2
        }
        #endregion

        #region BaseB
        public const string BaseBAoB = "89 45 98 A1 ? ? ? ? 89 7D 9C 89 BD ? ? ? ? 85 C0";
        public enum Connection
        {
            ConnectionType = 0x54
        }

        #endregion

        #region FCData
        public const string CameraAoB = "60 02 2c f0 f3 7f 00 00";
        public const int CameraOffset1 = 0x0;
        public const int CameraOffset2 = 0x20;
        public const int CameraOffset3 = 0x28;
        public enum Camera
        {
            CamStart = 0x170,
            CamStart2 = 0x19C,
            CamStart3 = 0x1C,
            CamX = 0x1A0,
            CamZ = 0x1A4,
            CamY = 0x1A8
        }
        #endregion

        #region Param

        public enum Param
        {
            TotalParamLength = 0x0,
            ParamName = 0xC,
            TableLength = 0x30
        }

        public const int ParamDataOffset1 = 0x18;
        public const int ParamDataOffset2 = 0x154;
        public const int ParamDataOffset3 = 0x60;
        public const int ParamDataOffset4 = 0x94;

        public const int LevelUpSoulsParamOffset = 0x2B8;
        public const int WeaponParamOffset = 0x208;
        public enum WeaponParam
        {
            ReinforceID = 0x8
        }

        public const int WeaponReinforceParamOffset = 0x238;
        public enum WeaponReinforceParam
        {
            MaxUpgrade = 0x48,
            CustomAttrID = 0xE8
        }
        public const int CustomAttrSpecParamOffset = 0x270;

        public const int ArmorParamOffset = 0x4A0;
        public enum ArmorParam
        {
            ReinforceID = 0x8
        }
        public const int ArmorReinforceParamOffset = 0x258;
        public enum ArmorReinforceParam
        {
            MaxUpgrade = 0x60,
        }

        public const int ItemParamOffset = 0x10;
        public enum ItemParam
        {
            ItemUsageID = 0x44,
            MaxHeld = 0x4A
        }

        public const int ItemUsageParamOffset = 0x20;
        public enum ItemUasgeParam
        {
            Bitfield = 0x6
        }

        #endregion

        #region Internals
        public const string SpeedFactorAccelOffset = "F3 0F 59 9F A8 02 00 00 F3 0F 10 16";
        public const string SpeedFactorAnimOffset = "F3 0F 59 99 A8 02 00 00";
        public const string SpeedFactorJumpOffset = "F3 0F 59 99 A8 02 00 00 F3 0F 10 12 F3 0F 10 42 04 48 8B 89 E0 00 00 00";
        public const string SpeedFactorBuildupOffset = "F3 0F 59 99 A8 02 00 00 F3 0F 10 12 F3 0F 10 42 04 48 8B 89 E8 03 00 00";

        #endregion
    }
}
