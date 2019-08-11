using System.Collections.Generic;

namespace EZAsWeapon
{
    public class CDataBaseBuffer
    {
        private CDataBase g_DataBase = new CDataBase();
        private static CDataBaseBuffer m_DataBase = new CDataBaseBuffer();
        public static CDataBaseBuffer Action()
        {
            return m_DataBase;
        }

        public Dictionary<string, string> d_DataBase
        {
            get { return g_DataBase.d_DataBase; }
            set { g_DataBase.d_DataBase = value; }
        }
    }

    class CDataBase
    {
        public Dictionary<string, string> d_DataBase =
            new Dictionary<string, string>
            { {"m_DataEnum",""},

            {"m_IDLE","0"},
            {"m_FIDGET","0"},
            {"m_RELOAD","0"},
            {"m_DRAW","0"},
            {"m_SHOOT","0"},
            {"m_SHOOT2","0"},
            {"m_START_RELOAD","0"},
            {"m_INSERT","0"},
            {"m_AFTER_RELOAD","0"},

            {"m_VModel",""},
            {"m_PModel",""},
            {"m_WModel",""},
            {"m_SModel",""},
            {"m_strDryFireSound",""},
            {"m_FireSounds",""},

            {"m_strTextName",""},

            {"m_strAnimeName",""},

            {"m_iDefaultGive",""},
            {"m_iDefaultGive2",""},
            {"m_iMaxAmmoAmount",""},
            {"m_iMaxAmmoAmount2",""},
            {"m_iClipMax",""},
            {"m_iClipDrop",""},
            {"m_iClipDrop2",""},

            {"IsSecFire",""},

            {"IsSecAmmo",""},

            {"IsZoomMode",""},
            {"m_iZoomSpeed",""},
            {"m_iZoomFOV",""},
            {"m_ZoomSound",""},

            {"IsProj",""},
            {"pProjname",""},
            {"ProjOrgX",""},
            {"ProjOrgY",""},
            {"ProjOrgZ",""},
            {"ProjOrgV",""},

            {"IsSubProj",""},
            {"strSubProjName",""},
            {"SubProjOrgX",""},
            {"SubProjOrgY",""},
            {"SubProjOrgZ",""},
            {"SubProjOrgV",""},

            {"m_iSlotAmount",""},
            {"m_iPositionAmount",""},
            {"m_iWeightAmount",""},
            {"m_iDamegeAmount",""},
            {"FireAmount",""},
            {"FireAmount2",""},
            {"m_DeployTime",""},
            {"m_FireTime",""},
            {"m_ReloadTime",""},

            {"m_XPunchMax",""},
            {"m_XPunchMin",""},
            {"m_YPunchMax",""},
            {"m_YPunchMin",""},

            {"m_iAcc",""},
            {"m_iAcc2",""},

            {"m_iDamegeAmount2",""},
            {"m_FireTime2",""},
            {"m_FireSubSounds",""},

            {"m_ShellOrgX",""},
            {"m_ShellOrgY",""},
            {"m_ShellOrgZ",""},

            {"m_ShellDirXMax",""},
            {"m_ShellDirXMin",""},
            {"m_ShellDirYMax",""},
            {"m_ShellDirYMin",""},
            {"m_ShellDirZMax",""},
            {"m_ShellDirZMin",""},

            {"IsShotGun",""},
            {"m_PumpTime",""},
            {"m_InsertTime",""},
            {"m_FinishInsertTime",""},
            {"ShotGunPelletCount",""},
            {"vecShotgunDM",""},
            {"PumpSounds",""},
            {"ShotgunFinishSound",""},
            {"ShotgunInsertSound",""},

            {"m_PumpTime2",""},
            {"ShotGunSubPelletCount",""},
            {"vecShotgunDM2",""},

            {"m_TXTDir",""},
            {"m_AmmoType",""},
            {"m_AmmoType2",""},
            {"m_AmmoEntity",""},
            {"m_AmmoEntity2",""},

            {"g_WeaponModel",""},
            {"g_WeaponSound",""},
            {"g_WeaponSprites",""},

            {"g_WeaponName",""},
            {"g_WeaponRegisterName",""}};
    }
}