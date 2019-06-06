namespace EZAsWeapon
{
    public static class OpenDefaultData
    {
        public static string[] baseweapon = {
            "/**===========================================================================\n",
            "  							本脚本由EzAsWeapon程序自动生成\n" ,
            "  							程序由Dr.Abc设计制作\n" ,
            "  							联系方式Dr.Abc@cykaskin.com\n" ,
            "=============================================================================**/\n" ,
            "namespace CustomWeapons{\n",
            "class CBaseWeapon : ScriptBasePlayerWeaponEntity{\n",
            "  protected string m_WModel = 'models/error.mdl';\n",
            "  protected string m_VModel = 'models/error.mdl';\n",
            "  protected string m_PModel = 'models/error.mdl';\n",
            "  protected string m_SModel = 'models/error.mdl';\n",
            "  protected string m_strDryFireSound = 'hl/weapons/357_cock1.wav';\n",
            "  protected string m_strAnimeName,m_FireSounds,m_strTextName;\n",
            "  protected int m_iShell,m_iDefaultGive,m_iMaxAmmoAmount,m_iClipMax,m_iClipDrop,m_iSlotAmount,m_iPositionAmount,m_iWeightAmount,m_iDamegeAmount,m_iDamegeAmount2,m_iMaxAmmoAmount2,m_iClipDrop2,m_iDefaultGive2;\n",
            "  protected float m_DeployTime,m_FireTime,m_ReloadTime;\n",
            "  protected float m_XPunchMax,m_XPunchMin,m_YPunchMax,m_YPunchMin;\n",
            "  protected float m_ShellOrgX,m_ShellOrgY,m_ShellOrgZ;\n",
            "  protected int8  m_ShellDirXMax,m_ShellDirXMin,m_ShellDirYMax,m_ShellDirYMin,m_ShellDirZMax,m_ShellDirZMin;\n",
            "  protected bool IsShotGun,m_fPlayPumpSound,m_fShotgunReload,m_flShotGunNextReload,IsSecFire,IsSecAmmo;\n",
            "  protected float m_flPumpTime,m_flNextReload;\n",
            "  protected float m_PumpTime,m_InsertTime,m_FinishInsertTime;\n",
            "  protected uint ShotGunPelletCount,ShotGunSubPelletCount;\n",
            "  protected string PumpSounds,ShotgunFinishSound,ShotgunInsertSound,m_FireSubSounds;\n",
            "  protected Vector vecShotgunDM = Vector (0,0,0);\n",
            "  protected int8 m_IDLE,m_FIDGET,m_RELOAD,m_DRAW,m_SHOOT,m_SHOOT2,m_AFTER_RELOAD,m_START_RELOAD,m_INSERT,FireAmount,FireAmount2;\n",
            "  protected Vector m_iAcc,m_iAcc2;\n",
            "  protected float m_PumpTime2,m_FireTime2;\n",
            "  protected Vector vecShotgunDM2 = Vector (0,0,0);\n",
            "  protected bool bInZoom = false;\n",
            "  protected bool IsProj,IsSubProj,IsZoomMode;\n",
            "  protected int m_iZoomSpeed,m_iZoomFOV;\n",
            "  protected int	m_iSecondaryAmmo;\n",
            "  protected string pProjname,strSubProjName;\n",
            "  protected string m_ZoomSound = 'hl/weapons/357_cock1.wav';\n",
            "  protected float ProjOrgX,ProjOrgY,ProjOrgZ,ProjOrgV,SubProjOrgX,SubProjOrgY,SubProjOrgZ,SubProjOrgV;\n",
            "  protected CBasePlayer@ m_pPlayer = null;\n",
            "  protected array<string> g_WeaponModel,g_WeaponSound,g_WeaponSprites;\n",
            " void Spawn(){Precache();\n",
            "  g_EntityFuncs.SetModel( self, m_WModel );\n",
            "  self.m_iDefaultAmmo = m_iDefaultGive;\n",
            "  self.m_iDefaultSecAmmo = m_iDefaultGive2;\n",
            "  self.m_iSecondaryAmmoType = 0;\n",
            "  self.FallInit();}\n",
            " void Precache(){\n",
            "  self.PrecacheCustomModels();\n",
            "  for (uint i = 0; i < g_WeaponModel.length(); ++i) {\n",
            "   g_Game.PrecacheModel(g_WeaponModel[i]);}\n",
            "  for (uint i = 0; i < g_WeaponSound.length(); ++i) {\n",
            "   g_Game.PrecacheGeneric('sound/' + g_WeaponSound[i]);\n",
            "   g_SoundSystem.PrecacheSound(g_WeaponSound[i]);}\n",
            "  for (uint i = 0; i < g_WeaponSprites.length(); ++i) {\n",
            "   g_Game.PrecacheModel('sprites/' + g_WeaponSprites[i]);\n",
            "   g_Game.PrecacheGeneric('sprites/' + g_WeaponSprites[i]);}\n",
            "  g_Game.PrecacheModel( m_WModel );\n",
            "  g_Game.PrecacheModel( m_VModel );\n",
            "  g_Game.PrecacheModel( m_PModel );\n",
            "  m_iShell = g_Game.PrecacheModel( m_SModel );\n",
            "  g_Game.PrecacheGeneric('sound/' + m_FireSounds);g_SoundSystem.PrecacheSound(m_FireSounds);\n",
            "  g_Game.PrecacheGeneric('sound/' + m_FireSubSounds);g_SoundSystem.PrecacheSound(m_FireSubSounds);\n",
            "  g_Game.PrecacheGeneric('sound/' + PumpSounds);g_SoundSystem.PrecacheSound(PumpSounds);\n",
            "  g_Game.PrecacheGeneric('sound/' + m_strDryFireSound);g_SoundSystem.PrecacheSound(m_strDryFireSound);\n",
            "  g_Game.PrecacheGeneric('sound/' + ShotgunFinishSound);g_SoundSystem.PrecacheSound(ShotgunFinishSound);\n",
            "  g_Game.PrecacheGeneric('sound/' + ShotgunInsertSound);g_SoundSystem.PrecacheSound(ShotgunInsertSound);\n",
            "  g_Game.PrecacheGeneric('sprites/' + m_strTextName);}\n",
            " bool GetItemInfo( ItemInfo& out info ){\n",
            " info.iMaxAmmo1  = m_iMaxAmmoAmount;\n",
            " info.iMaxAmmo2  = m_iMaxAmmoAmount2;\n",
            " info.iAmmo1Drop = m_iClipDrop;\n",
            " info.iAmmo2Drop = m_iClipDrop2;\n",
            " info.iMaxClip 	 = m_iClipMax;\n",
            " info.iSlot      = m_iSlotAmount;\n",
            " info.iPosition  = m_iPositionAmount;\n",
            " info.iFlags 	 = 0;\n",
            " info.iWeight 	 = m_iWeightAmount;\n",
            " return true;}\n",
            " bool AddToPlayer( CBasePlayer@ pPlayer ){\n",
            "  if( BaseClass.AddToPlayer( pPlayer ) == true ){\n",
            "  NetworkMessage message( MSG_ONE, NetworkMessages::WeapPickup, pPlayer.edict() );\n",
            "  message.WriteLong( self.m_iId );\n",
            "  message.End();\n",
            "  @m_pPlayer = pPlayer;\n",
            "  return true;\n",
            " }return false;}\n",
            " bool PlayEmptySound(){\n",
            "  if( self.m_bPlayEmptySound ){\n",
            "    self.m_bPlayEmptySound = false;			\n",
            "    g_SoundSystem.EmitSoundDyn( m_pPlayer.edict(), CHAN_WEAPON, m_strDryFireSound, 0.8, ATTN_NORM, 0, PITCH_NORM );}	\n",
            "   return false;}\n",
            " bool Deploy(){\n",
            "   bool bResult;{\n",
            "   bResult = self.DefaultDeploy( self.GetV_Model( m_VModel ), self.GetP_Model( m_PModel ), m_DRAW, m_strAnimeName );\n",
            "   float deployTime = m_DeployTime;\n",
            "   self.m_flTimeWeaponIdle = self.m_flNextPrimaryAttack = self.m_flNextSecondaryAttack = g_Engine.time + deployTime;\n",
            "   return bResult;}}\n",
            " float WeaponTimeBase()\n",
            " {return g_Engine.time;}\n",
            " void ItemPostFrame(){\n",
            "  if(IsShotGun){\n",
            "  if( m_flPumpTime != 0 && m_flPumpTime < g_Engine.time && m_fPlayPumpSound )\n",
            "  {g_SoundSystem.EmitSoundDyn( m_pPlayer.edict(), CHAN_ITEM, PumpSounds, 1, ATTN_NORM, 0, 95 + Math.RandomLong( 0,0x1f ) );m_fPlayPumpSound = false;\n",
            "  g_EntityFuncs.EjectBrass( m_pPlayer.GetGunPosition() + g_Engine.v_forward * m_ShellOrgX + g_Engine.v_right * m_ShellOrgY + g_Engine.v_up * m_ShellOrgZ, g_Engine.v_forward * Math.RandomLong(m_ShellDirXMin,m_ShellDirXMax) + g_Engine.v_right * Math.RandomLong(m_ShellDirYMin,m_ShellDirYMax)+ g_Engine.v_up * Math.RandomLong(m_ShellDirZMin,m_ShellDirZMax), m_pPlayer.pev.angles[ 1 ], m_iShell, TE_BOUNCE_SHOTSHELL );}}\n",
            "  BaseClass.ItemPostFrame();}\n",
            " void CreatePelletDecals( const Vector& in vecSrc, const Vector& in vecAiming, const Vector& in vecSpread, const uint uiPelletCount ){\n",
            "TraceResult tr;float x, y;\n",
            " for( uint uiPellet = 0; uiPellet < uiPelletCount; ++uiPellet ){\n",
            "  g_Utility.GetCircularGaussianSpread( x, y );\n",
            "  Vector vecDir = vecAiming + x * vecSpread.x * g_Engine.v_right + y * vecSpread.y * g_Engine.v_up;\n",
            "  Vector vecEnd	= vecSrc + vecDir * 2048;\n",
            "  g_Utility.TraceLine( vecSrc, vecEnd, dont_ignore_monsters, m_pPlayer.edict(), tr );\n",
            "  if( tr.flFraction < 1.0 ){\n",
            "   if( tr.pHit !is null ){\n",
            "    CBaseEntity@ pHit = g_EntityFuncs.Instance( tr.pHit );\n",
            "    if( pHit is null || pHit.IsBSPModel() )\n",
            "     g_WeaponFuncs.DecalGunshot( tr, BULLET_PLAYER_BUCKSHOT );}}}}\n",
            " void PrimaryAttack(){\n",
            "  if( m_pPlayer.pev.waterlevel == WATERLEVEL_HEAD ){\n",
            "   self.PlayEmptySound( );\n",
            "   self.m_flNextPrimaryAttack = WeaponTimeBase() + m_FireTime + 0.3;self.m_flNextSecondaryAttack = WeaponTimeBase() + m_FireTime2 + 0.3;\n",
            "   return;}\n",
            "  if( self.m_iClip <= 0 ){\n",
            "   self.PlayEmptySound();\n",
            "   self.m_flNextPrimaryAttack = WeaponTimeBase() + m_FireTime + 0.3;self.m_flNextSecondaryAttack = WeaponTimeBase() + m_FireTime2 + 0.3;\n",
            "   return;}\n",
            "   if( self.m_iClip < FireAmount ){\n",
            "   self.Reload();return;}\n",
            " m_pPlayer.m_iWeaponVolume = NORMAL_GUN_VOLUME;\n",
            " m_pPlayer.m_iWeaponFlash = NORMAL_GUN_FLASH;\n",
            " self.m_iClip -= FireAmount;\n",
            " self.SendWeaponAnim( m_SHOOT );\n",
            " g_SoundSystem.EmitSoundDyn( m_pPlayer.edict(), CHAN_WEAPON, m_FireSounds, 1.0, ATTN_NORM, 0, 95 + Math.RandomLong( 0, 10 ) );\n",
            " m_pPlayer.SetAnimation( PLAYER_ATTACK1 );\n",
            " if(IsProj){\n",
            "   if(pProjname == 'grenade'){\n",
            "   CBaseEntity@ pProj = g_EntityFuncs.ShootContact(m_pPlayer.pev,  m_pPlayer.GetGunPosition() + g_Engine.v_forward * ProjOrgX + g_Engine.v_up * ProjOrgZ + g_Engine.v_right * ProjOrgY ,g_Engine.v_forward * ProjOrgV);}\n",
            "   else{\n",
            "   CBaseEntity@ pProj = g_EntityFuncs.Create( pProjname, m_pPlayer.GetGunPosition() + g_Engine.v_forward * ProjOrgX + g_Engine.v_up * ProjOrgZ + g_Engine.v_right * ProjOrgY,  m_pPlayer.pev.v_angle + m_pPlayer.pev.punchangle, false);\n",
            "   pProj.pev.velocity = g_Engine.v_forward * ProjOrgV ;\n",
            "   @pProj.pev.owner = m_pPlayer.pev.pContainingEntity;\n",
            "   pProj.pev.angles = Math.VecToAngles( pProj.pev.velocity );\n",
            "   pProj.pev.nextthink = g_Engine.time + 0.1f;}self.m_flNextPrimaryAttack = WeaponTimeBase() + m_FireTime;self.m_flNextSecondaryAttack = WeaponTimeBase() + m_FireTime2 + m_FireTime;return;}\n",
            " Vector vecSrc	 = m_pPlayer.GetGunPosition();\n",
            " Vector vecAiming = m_pPlayer.GetAutoaimVector( AUTOAIM_5DEGREES );\n",
            " int m_iBulletDamage = m_iDamegeAmount + Math.RandomLong( -1, 1 );\n",
            " m_pPlayer.FireBullets( IsShotGun?int(ShotGunPelletCount):1, vecSrc, vecAiming, m_iAcc, 8192, BULLET_PLAYER_CUSTOMDAMAGE, 2, m_iBulletDamage );\n",
            " if( self.m_iClip == 0 && m_pPlayer.m_rgAmmo( self.m_iPrimaryAmmoType ) <= 0 )\n",
            "  m_pPlayer.SetSuitUpdate( '!HEV_AMO0', false, 0 );\n",
            " if(IsShotGun){\n",
            "  if( self.m_iClip != 0 ){\n",
            "   m_flPumpTime = g_Engine.time + m_PumpTime;self.m_flTimeWeaponIdle = g_Engine.time + m_PumpTime;}\n",
            "  else {self.m_flNextPrimaryAttack = self.m_flTimeWeaponIdle = g_Engine.time + m_FireTime;self.m_flNextSecondaryAttack = WeaponTimeBase() + m_FireTime2 + m_FireTime + + m_PumpTime;}}\n",
            " if(IsShotGun)\n",
            "   m_fShotgunReload = false;m_fPlayPumpSound = true;\n",
            " m_pPlayer.pev.punchangle.x = Math.RandomFloat( m_XPunchMax, m_XPunchMin );\n",
            " m_pPlayer.pev.punchangle.y = Math.RandomFloat( m_YPunchMax, m_YPunchMin );		\n",
            " if( self.m_flNextPrimaryAttack < WeaponTimeBase() )\n",
            "  self.m_flNextPrimaryAttack = WeaponTimeBase() + m_FireTime;\n",
            " self.m_flTimeWeaponIdle = WeaponTimeBase() + Math.RandomFloat( 10, 15 );	\n",
            " if(!IsShotGun){\n",
            " TraceResult tr;	\n",
            " float x, y;	\n",
            " g_Utility.GetCircularGaussianSpread( x, y );\n",
            " Vector vecDir = vecAiming + x * VECTOR_CONE_6DEGREES.x * g_Engine.v_right + y * VECTOR_CONE_6DEGREES.y * g_Engine.v_up;\n",
            " Vector vecEnd	= vecSrc + vecDir * 4096;\n",
            "   g_Utility.TraceLine( vecSrc, vecEnd, dont_ignore_monsters, m_pPlayer.edict(), tr );\n",
            "   if( tr.flFraction < 1.0 ){\n",
            "    if( tr.pHit !is null ){\n",
            "  CBaseEntity@ pHit = g_EntityFuncs.Instance( tr.pHit );\n",
            "   if( pHit is null || pHit.IsBSPModel() == true )\n",
            "    g_WeaponFuncs.DecalGunshot( tr, BULLET_PLAYER_MP5 );}}\n",
            "  g_EntityFuncs.EjectBrass( m_pPlayer.GetGunPosition() + g_Engine.v_forward * m_ShellOrgX + g_Engine.v_right * m_ShellOrgY + g_Engine.v_up * m_ShellOrgZ, g_Engine.v_forward * Math.RandomLong(m_ShellDirXMin,m_ShellDirXMax) + g_Engine.v_right * Math.RandomLong(m_ShellDirYMin,m_ShellDirYMax)+ g_Engine.v_up * Math.RandomLong(m_ShellDirZMin,m_ShellDirZMax), m_pPlayer.pev.angles[ 1 ], m_iShell, TE_BOUNCE_SHELL );}else{CreatePelletDecals( vecSrc, vecAiming, vecShotgunDM, ShotGunPelletCount );}}\n",
            "   void SecondaryAttack(){\n",
            "   if(IsZoomMode){\n",
            "   if(!bInZoom){bInZoom = true;m_pPlayer.pev.maxspeed = m_iZoomSpeed;ToggleZoom( m_iZoomFOV );m_pPlayer.m_szAnimExtension = 'sniperscope';}\n",
            "   else{bInZoom = false;m_pPlayer.pev.maxspeed = 0;ToggleZoom( 0 );m_pPlayer.m_szAnimExtension = m_strAnimeName;}\n",
            "   g_SoundSystem.EmitSoundDyn( m_pPlayer.edict(), CHAN_ITEM, m_ZoomSound, 1.0, ATTN_NORM, 0, 95 + Math.RandomLong( 0, 10 ) );\n",
            "   self.m_flNextSecondaryAttack = WeaponTimeBase() + m_FireTime2;self.m_flNextPrimaryAttack = WeaponTimeBase() + m_FireTime + m_FireTime2;}\n",
            "   if(IsSecFire && !IsZoomMode){\n",
            "  if( m_pPlayer.pev.waterlevel == WATERLEVEL_HEAD ){\n",
            "   self.PlayEmptySound( );\n",
            "   self.m_flNextSecondaryAttack = WeaponTimeBase() + m_FireTime2 + 0.3;self.m_flNextPrimaryAttack = WeaponTimeBase() + m_FireTime + 0.3;\n",
            "   return;}\n",
            "   if(IsSecAmmo){if( m_pPlayer.m_rgAmmo(self.m_iSecondaryAmmoType) <= 0 ){self.PlayEmptySound();return;}\n",
            "	}else{\n",
            "  if( self.m_iClip <= 0 ){\n",
            "   self.PlayEmptySound();\n",
            "   self.m_flNextSecondaryAttack = WeaponTimeBase() + m_FireTime2 + 0.3;self.m_flNextPrimaryAttack = WeaponTimeBase() + m_FireTime + 0.3;\n",
            "   return;}\n",
            "   if( self.m_iClip < FireAmount2 ){\n",
            "   self.Reload();return;}}\n",
            " m_pPlayer.m_iWeaponVolume = NORMAL_GUN_VOLUME;\n",
            " m_pPlayer.m_iWeaponFlash = NORMAL_GUN_FLASH;\n",
            " if(IsSecAmmo){m_pPlayer.m_rgAmmo( self.m_iSecondaryAmmoType, m_pPlayer.m_rgAmmo( self.m_iSecondaryAmmoType ) - 1 );}\n",
            " else{self.m_iClip -= FireAmount2;}\n",
            " self.SendWeaponAnim( m_SHOOT2 );\n",
            " g_SoundSystem.EmitSoundDyn( m_pPlayer.edict(), CHAN_WEAPON, m_FireSubSounds, 1.0, ATTN_NORM, 0, 95 + Math.RandomLong( 0, 10 ) );\n",
            " m_pPlayer.SetAnimation( PLAYER_ATTACK1 );\n",
            " if(IsSubProj){\n",
            "   if(strSubProjName == 'grenade'){\n",
            "    CBaseEntity@ pProj = g_EntityFuncs.ShootContact(m_pPlayer.pev, m_pPlayer.GetGunPosition() + g_Engine.v_forward * SubProjOrgX + g_Engine.v_up * SubProjOrgZ + g_Engine.v_right * SubProjOrgY,g_Engine.v_forward * SubProjOrgV);}\n",
            "   else{\n",
            "    CBaseEntity@ pProj = g_EntityFuncs.Create( strSubProjName, m_pPlayer.GetGunPosition() + g_Engine.v_forward * SubProjOrgX + g_Engine.v_up * SubProjOrgZ + g_Engine.v_right * SubProjOrgY,  m_pPlayer.pev.v_angle + m_pPlayer.pev.punchangle, false);\n",
            "    pProj.pev.velocity = g_Engine.v_forward * SubProjOrgV ;\n",
            "    @pProj.pev.owner = m_pPlayer.pev.pContainingEntity;\n",
            "    pProj.pev.angles = Math.VecToAngles( pProj.pev.velocity );\n",
            "    pProj.pev.nextthink = g_Engine.time + 0.1f;}\n",
            "	self.m_flNextSecondaryAttack = WeaponTimeBase() + m_FireTime2;self.m_flNextPrimaryAttack = WeaponTimeBase() + m_FireTime + m_FireTime2;return;}\n",
            " Vector vecSrc	 = m_pPlayer.GetGunPosition();\n",
            " Vector vecAiming = m_pPlayer.GetAutoaimVector( AUTOAIM_5DEGREES );\n",
            " int m_iBulletDamage = m_iDamegeAmount2 + Math.RandomLong( -1, 1 );\n",
            " m_pPlayer.FireBullets( IsShotGun?int(ShotGunSubPelletCount):1, vecSrc, vecAiming, m_iAcc2, 8192, BULLET_PLAYER_CUSTOMDAMAGE, 2, m_iBulletDamage );\n",
            " if( self.m_iClip == 0 && m_pPlayer.m_rgAmmo( self.m_iPrimaryAmmoType ) <= 0 )\n",
            "  m_pPlayer.SetSuitUpdate( '!HEV_AMO0', false, 0 );\n",
            " if(IsShotGun){\n",
            "  if( self.m_iClip != 0 ){\n",
            "   m_flPumpTime = g_Engine.time + m_PumpTime2;self.m_flTimeWeaponIdle = g_Engine.time + m_PumpTime2;}\n",
            "  else {self.m_flNextSecondaryAttack = self.m_flTimeWeaponIdle = g_Engine.time + m_FireTime2;self.m_flNextPrimaryAttack = WeaponTimeBase() + m_FireTime + m_FireTime2 + m_PumpTime2;}}\n",
            " if(IsShotGun)\n",
            "   m_fShotgunReload = false;m_fPlayPumpSound = true;\n",
            " m_pPlayer.pev.punchangle.x = Math.RandomFloat( m_XPunchMax, m_XPunchMin );\n",
            " m_pPlayer.pev.punchangle.y = Math.RandomFloat( m_YPunchMax, m_YPunchMin );		\n",
            " if( self.m_flNextSecondaryAttack < WeaponTimeBase() )\n",
            "  self.m_flNextSecondaryAttack = WeaponTimeBase() + m_FireTime2;\n",
            " self.m_flTimeWeaponIdle = WeaponTimeBase() + Math.RandomFloat( 10, 15 );	\n",
            " if(!IsShotGun){\n",
            " TraceResult tr;	\n",
            " float x, y;	\n",
            " g_Utility.GetCircularGaussianSpread( x, y );\n",
            " Vector vecDir = vecAiming + x * VECTOR_CONE_6DEGREES.x * g_Engine.v_right + y * VECTOR_CONE_6DEGREES.y * g_Engine.v_up;\n",
            " Vector vecEnd	= vecSrc + vecDir * 4096;\n",
            "   g_Utility.TraceLine( vecSrc, vecEnd, dont_ignore_monsters, m_pPlayer.edict(), tr );\n",
            "   if( tr.flFraction < 1.0 ){\n",
            "    if( tr.pHit !is null ){\n",
            "  CBaseEntity@ pHit = g_EntityFuncs.Instance( tr.pHit );\n",
            "   if( pHit is null || pHit.IsBSPModel() == true )\n",
            "    g_WeaponFuncs.DecalGunshot( tr, BULLET_PLAYER_MP5 );}}\n",
            "  g_EntityFuncs.EjectBrass( m_pPlayer.GetGunPosition() + g_Engine.v_forward * m_ShellOrgX + g_Engine.v_right * m_ShellOrgY + g_Engine.v_up * m_ShellOrgZ, g_Engine.v_forward * Math.RandomLong(m_ShellDirXMin,m_ShellDirXMax) + g_Engine.v_right * Math.RandomLong(m_ShellDirYMin,m_ShellDirYMax)+ g_Engine.v_up * Math.RandomLong(m_ShellDirZMin,m_ShellDirZMax), m_pPlayer.pev.angles[ 1 ], m_iShell, TE_BOUNCE_SHELL );}else{CreatePelletDecals( vecSrc, vecAiming, vecShotgunDM2, ShotGunSubPelletCount );}}}\n",
            " void WeaponIdle()\n",
            " {self.ResetEmptySound();\n",
            "  m_pPlayer.GetAutoaimVector( AUTOAIM_5DEGREES );\n",
            " if( self.m_flTimeWeaponIdle > WeaponTimeBase() )\n",
            "  return;\n",
            "  if( self.m_flTimeWeaponIdle < g_Engine.time && IsShotGun){\n",
            "   if( self.m_iClip == 0 && !m_fShotgunReload && m_pPlayer.m_rgAmmo( self.m_iPrimaryAmmoType ) != 0 ){self.Reload();}\n",
            "   else if( m_fShotgunReload ){\n",
            "    if( self.m_iClip != m_iClipMax && m_pPlayer.m_rgAmmo( self.m_iPrimaryAmmoType ) > 0 ){self.Reload();}\n",
            "    else{\n",
            "     self.SendWeaponAnim( m_AFTER_RELOAD, 0, 0 );\n",
            "     g_SoundSystem.EmitSoundDyn( m_pPlayer.edict(), CHAN_ITEM, ShotgunFinishSound, 1, ATTN_NORM, 0, 95 + Math.RandomLong( 0,0x1f ) );\n",
            "     m_fShotgunReload = false;\n",
            "     self.m_flTimeWeaponIdle = g_Engine.time + 1.5;}}}else{\n",
            "   switch (Math.RandomLong(0,1))\n",
            "   {case 0: self.SendWeaponAnim( m_IDLE );break;\n",
            "    case 1: self.SendWeaponAnim( m_FIDGET );break;}\n",
            "    self.m_flTimeWeaponIdle = g_Engine.time + Math.RandomFloat( 10, 15 );}}\n",
            " void Reload()\n",
            "  {if( m_pPlayer.m_rgAmmo( self.m_iPrimaryAmmoType ) <= 0 || self.m_iClip >= m_iClipMax ){ return;}\n",
            "   if(bInZoom && IsZoomMode){SecondaryAttack();}\n",
            "   m_pPlayer.SetAnimation( PLAYER_RELOAD );\n",
            "   if (IsShotGun) {\n",
            "   if( !m_fShotgunReload ){\n",
            "    self.SendWeaponAnim( m_START_RELOAD, 0, 0 );\n",
            "    m_pPlayer.m_flNextAttack 	=  m_FinishInsertTime;\n",
            "    self.m_flTimeWeaponIdle			= g_Engine.time  + m_FinishInsertTime;\n",
            "    self.m_flNextPrimaryAttack 		= g_Engine.time  + m_FinishInsertTime + 0.1;\n",
            "	self.m_flNextSecondaryAttack	= g_Engine.time	 + m_FinishInsertTime + 0.1;\n",
            "    m_fShotgunReload = true;return;}\n",
            "   else if( m_fShotgunReload ){\n",
            "    if( self.m_flTimeWeaponIdle > g_Engine.time )return;\n",
            "     if( self.m_iClip == m_iClipMax ){\n",
            "    m_fShotgunReload = false;return;}\n",
            "    self.SendWeaponAnim( m_INSERT, 0 );\n",
            "    m_flNextReload 					= g_Engine.time + m_InsertTime;\n",
            "    self.m_flNextPrimaryAttack 		= g_Engine.time + m_FinishInsertTime + 0.1;\n",
            "	self.m_flNextSecondaryAttack	= g_Engine.time + m_FinishInsertTime + 0.1;\n",
            "    self.m_flTimeWeaponIdle 		= g_Engine.time + m_FinishInsertTime;\n",
            "    self.m_iClip += 1;\n",
            "    m_pPlayer.m_rgAmmo( self.m_iPrimaryAmmoType, m_pPlayer.m_rgAmmo( self.m_iPrimaryAmmoType ) - 1 );\n",
            "    g_SoundSystem.EmitSoundDyn( m_pPlayer.edict(), CHAN_ITEM, ShotgunInsertSound, 1, ATTN_NORM, 0, 85 + Math.RandomLong( 0, 0x1f ) );}}\n",
            "   else{\n",
            "   self.DefaultReload( m_iClipMax, m_RELOAD, m_ReloadTime, 0 );}}\n",
            "  void SetFOV( int fov ){m_pPlayer.pev.fov = m_pPlayer.m_iFOV = fov;}\n",
            "  void ToggleZoom( int zoomedFOV ){	SetFOV( zoomedFOV );}\n",
            "  void Holster( int skipLocal = 0 ){if(IsShotGun){m_fShotgunReload = false;}BaseClass.Holster( skipLocal );\n",
            "	if(bInZoom){bInZoom = false;m_pPlayer.pev.maxspeed = 0;ToggleZoom( 0 );m_pPlayer.m_szAnimExtension = m_strAnimeName;g_SoundSystem.EmitSoundDyn( m_pPlayer.edict(), CHAN_ITEM, 'hl/weapons/357_cock1.wav', 1.0, ATTN_NORM, 0, 95 + Math.RandomLong( 0, 10 ) );\n",
            "}}}}	\n",
            "//全文输出完毕"};

        public static string Exm9mm =
            "enum ExamplePistolAnimation\n" +
            "{\n" +
            "	ExamplePistol_IDLE1 = 0,\n" +
            "	ExamplePistol_IDLE2,\n" +
            "	ExamplePistol_GRENADE,\n" +
            "	ExamplePistol_RELOAD1,\n" +
            "	ExamplePistol_DRAW,\n" +
            "	ExamplePistol_SHOOT,\n" +
            "	ExamplePistol_SHOOT2,\n" +
            "	ExamplePistol_SHOOT3\n" +
            "};\n" +
            "class weapon_hlmp5 : CustomWeapons::CBaseWeapon\n" +
            "{\n" +
            "	weapon_hlmp5()\n" +
            "	{\n" +
            "		m_IDLE 				= ExamplePistol_IDLE1;														\n" +
            "		m_FIDGET 			= ExamplePistol_IDLE2;														\n" +
            "		m_RELOAD 			= ExamplePistol_RELOAD1;													\n" +
            "		m_DRAW 				= ExamplePistol_DRAW;														\n" +
            "		m_SHOOT 			= ExamplePistol_SHOOT;														\n" +
            "		m_SHOOT2			= ExamplePistol_SHOOT3;														\n" +
            "		m_START_RELOAD		= 0;																		\n" +
            "		m_INSERT			= 0;																		\n" +
            "		m_AFTER_RELOAD		= 0;																		\n" +
            "		\n" +
            "		m_VModel 			= 'models/hlclassic/v_9mmAR.mdl';											\n" +
            "		m_PModel 			= 'models/hlclassic/p_9mmAR.mdl';											\n" +
            "		m_WModel 			= 'models/hlclassic/w_9mmAR.mdl';											\n" +
            "		m_SModel 			= 'models/hlclassic/shell.mdl';												\n" +
            "		\n" +
            "		m_strDryFireSound 	= 'hl/weapons/357_cock1.wav';												\n" +
            "		m_FireSounds 		= 'weapons/hks_hl1.wav';													\n" +
            "		\n" +
            "		m_strTextName 		= 'hl_weapons/weapon_hlmp5.txt';											\n" +
            "		\n" +
            "		m_strAnimeName 		= 'mp5';																	\n" +
            "		\n" +
            "		m_iDefaultGive 		= 60;																		\n" +
            "		m_iDefaultGive2		= 5;																		\n" +
            "		m_iMaxAmmoAmount 	= 800;																		\n" +
            "		m_iMaxAmmoAmount2	= 15;																		\n" +
            "		m_iClipMax 			= 30;																		\n" +
            "		m_iClipDrop			= 30;																		\n" +
            "		m_iClipDrop2		= 1;																		\n" +
            "		\n" +
            "		IsSecFire			= true;																		\n" +
            "		\n" +
            "		IsSecAmmo			= true;																		\n" +
            "		\n" +
            "		IsZoomMode			= false;																	\n" +
            "		m_iZoomSpeed		= 150;																		\n" +
            "		m_iZoomFOV			= 40;																		\n" +
            "		m_ZoomSound			= 'hl/weapons/357_cock1.wav';											\n" +
            "		\n" +
            "		IsProj				= false;																\n" +
            "		pProjname			= '';																	\n" +
            "		ProjOrgX			= 0;																	\n" +
            "		ProjOrgY			= 0;																	\n" +
            "		ProjOrgZ			= 0;																	\n" +
            "		ProjOrgV			= 0;																	\n" +
            "		\n" +
            "		IsSubProj			= true;																	\n" +
            "		strSubProjName		= 'grenade';															\n" +
            "		SubProjOrgX			= 5;																	\n" +
            "		SubProjOrgY			= 3;																	\n" +
            "		SubProjOrgZ			= 2;																	\n" +
            "		SubProjOrgV			= 1000;																	\n" +
            "		\n" +
            "		m_iSlotAmount 		= 2;																	\n" +
            "		m_iPositionAmount 	= 15;																	\n" +
            "		m_iWeightAmount 	= 7;																		\n" +
            "		m_iDamegeAmount 	= 14;																		\n" +
            "		FireAmount			= 1;																		\n" +
            "		FireAmount2			= 1;																		\n" +
            "		m_DeployTime 		= 0.24;																		\n" +
            "		m_FireTime 			= 0.1;																		\n" +
            "		m_ReloadTime 		= 2.6;																		\n" +
            "		\n" +
            "		m_XPunchMax 		= -10;																		\n" +
            "		m_XPunchMin 		= -5;																		\n" +
            "		m_YPunchMax 		= 0;																		\n" +
            "		m_YPunchMin 		= 0;																		\n" +
            "		\n" +
            "		m_iAcc 				= VECTOR_CONE_1DEGREES;														\n" +
            "		m_iAcc2				= VECTOR_CONE_4DEGREES;														\n" +
            "		\n" +
            "		m_iDamegeAmount2	= 11;																		\n" +
            "		m_FireTime2			= 0.95;																		\n" +
            "		m_FireSubSounds		= 'weapons/hks_hl2.wav';													\n" +
            "		\n" +
            "		m_ShellOrgX 		= 17;																	\n" +
            "		m_ShellOrgY 		= 7;																	\n" +
            "		m_ShellOrgZ 		= -8;																	\n" +
            "		\n" +
            "		m_ShellDirXMax 		= -25;																	\n" +
            "		m_ShellDirXMin 		= 25;																	\n" +
            "		m_ShellDirYMax 		= 60;																	\n" +
            "		m_ShellDirYMin		= 80;																	\n" +
            "		m_ShellDirZMax		= 15;																	\n" +
            "		m_ShellDirZMin		= 25;																	\n" +
            "		\n" +
            "		IsShotGun			= false;																\n" +
            "		m_PumpTime			= 0 ;																	\n" +
            "		m_InsertTime		= 0 ;																		\n" +
            "		m_FinishInsertTime	= 0 ;																		\n" +
            "		ShotGunPelletCount  = 0 ;																		\n" +
            "		vecShotgunDM		= Vector (0,0,0);															\n" +
            "		\n" +
            "		PumpSounds			= '';																	\n" +
            "		ShotgunFinishSound	= '';																		\n" +
            "		ShotgunInsertSound	= '';																			\n" +
            "		\n" +
            "		m_PumpTime2			= 0 ;																		\n" +
            "		ShotGunSubPelletCount= 0 ;																		\n" +
            "		vecShotgunDM2 		= Vector (0,0,0);															\n" +
            "\n" +
            "		g_WeaponModel 		= \n" +
            "		{\n" +
            "		};																		\n" +
            "		\n" +
            "		g_WeaponSound 		= \n" +
            "		{	\n" +
            "								'hl/items/clipinsert1.wav',\n" +
            "								'hl/items/cliprelease1.wav',\n" +
            "								'hl/items/guncock1.wav'\n" +
            "								};												\n" +
            "		g_WeaponSprites 	= \n" +
            "		{	\n" +
            "								'640hud1.spr',\n" +
            "								'640hud4.spr',\n" +
            "								'640hud7.spr',\n" +
            "								'crosshairs.spr'\n" +
            "								};														\n" +
            "	}\n" +
            "}\n" +
            "void RegisterExm9mm()\n" +
            "{\n" +
            "	g_CustomEntityFuncs.RegisterCustomEntity( 'weapon_hlmp5', 'weapon_hlmp5' );\n" +
            "	g_ItemRegistry.RegisterWeapon( 'weapon_hlmp5', 'hl_weapons', '9mm', 'ARgrenades' ,'ammo_9mmclip' , 'ammo_ARgrenades');\n" +
            "}\n";

        public static string ExmShotGun =
            "enum ShotgunAnimation\n" +
            "{\n" +
            "SHOTGUN_IDLE = 0,\n" +
            "SHOTGUN_FIRE,\n" +
            "SHOTGUN_FIRE2,\n" +
            "SHOTGUN_RELOAD,\n" +
            "SHOTGUN_PUMP,\n" +
            "SHOTGUN_START_RELOAD,\n" +
            "SHOTGUN_DRAW,\n" +
            "SHOTGUN_HOLSTER,\n" +
            "SHOTGUN_IDLE4,\n" +
            "SHOTGUN_IDLE_DEEP\n" +
            "};\n" +
            "class weapon_hlshotgun : CustomWeapons::CBaseWeapon\n" +
            "{\n" +
            "weapon_hlshotgun()\n" +
            "{\n" +
            "m_IDLE = SHOTGUN_IDLE;\n" +
            "m_FIDGET = SHOTGUN_IDLE_DEEP;\n" +
            "m_RELOAD = 0;\n" +
            "m_DRAW = SHOTGUN_DRAW;\n" +
            "m_SHOOT = SHOTGUN_FIRE;\n" +
            "m_SHOOT2= SHOTGUN_FIRE2;\n" +
            "m_START_RELOAD= SHOTGUN_START_RELOAD;\n" +
            "m_INSERT= SHOTGUN_RELOAD;\n" +
            "m_AFTER_RELOAD= SHOTGUN_PUMP;\n" +
            "\n" +
            "m_VModel = 'models/hlclassic/v_shotgun.mdl';\n" +
            "m_PModel = 'models/hlclassic/p_shotgun.mdl';\n" +
            "m_WModel = 'models/hlclassic/w_shotgun.mdl';\n" +
            "m_SModel = 'models/hlclassic/shotgunshell.mdl';\n" +
            "\n" +
            "m_strDryFireSound = 'hl/weapons/357_cock1.wav';\n" +
            "m_FireSounds = 'hlclassic/weapons/sbarrel1.wav';\n" +
            "\n" +
            "m_strTextName = 'hl_weapons/weapon_hlshotgun.txt';\n" +
            "\n" +
            "m_strAnimeName = 'shotgun';\n" +
            "\n" +
            "m_iDefaultGive = 60;\n" +
            "m_iMaxAmmoAmount = 125;\n" +
            "m_iClipMax = 8;\n" +
            "m_iClipDrop= 8;\n" +
            "\n" +
            "IsZoomMode= false;\n" +
            "m_iZoomSpeed= 0;\n" +
            "m_iZoomFOV= 0;\n" +
            "m_ZoomSound= '';\n" +
            "\n" +
            "IsProj= false;\n" +
            "pProjname= '';\n" +
            "ProjOrgX= 0;\n" +
            "ProjOrgY= 0;\n" +
            "ProjOrgZ= 0;\n" +
            "ProjOrgV= 0;\n" +
            "\n" +
            "IsSubProj= false;\n" +
            "strSubProjName= '';\n" +
            "SubProjOrgX= 0;\n" +
            "SubProjOrgY= 0;\n" +
            "SubProjOrgZ= 0;\n" +
            "SubProjOrgV= 0;\n" +
            "\n" +
            "m_iSlotAmount = 2;\n" +
            "m_iPositionAmount = 16;\n" +
            "m_iWeightAmount = 7;\n" +
            "m_iDamegeAmount = 14;\n" +
            "FireAmount= 1;\n" +
            "FireAmount2= 2;\n" +
            "m_DeployTime = 0.24;\n" +
            "m_FireTime = 0.85;\n" +
            "m_ReloadTime = 0;\n" +
            "\n" +
            "m_XPunchMax = -8;\n" +
            "m_XPunchMin = -5;\n" +
            "m_YPunchMax = 0;\n" +
            "m_YPunchMin = 0;\n" +
            "\n" +
            "m_iAcc = VECTOR_CONE_1DEGREES;\n" +
            "m_iAcc2= VECTOR_CONE_4DEGREES;\n" +
            "\n" +
            "IsSecFire= true;\n" +
            "m_iDamegeAmount2= 11;\n" +
            "\n" +
            "m_FireTime2= 1.5;\n" +
            "m_FireSubSounds= 'hlclassic/weapons/dbarrel1.wav';\n" +
            "\n" +
            "m_ShellOrgX = 17;\n" +
            "m_ShellOrgY = 7;\n" +
            "m_ShellOrgZ = -8;\n" +
            "\n" +
            "m_ShellDirXMax = -25;\n" +
            "m_ShellDirXMin = 25;\n" +
            "m_ShellDirYMax = 60;\n" +
            "m_ShellDirYMin= 80;\n" +
            "m_ShellDirZMax= 15;\n" +
            "m_ShellDirZMin= 25;\n" +
            "\n" +
            "IsShotGun= true;\n" +
            "m_PumpTime= 0.6 ;\n" +
            "m_InsertTime= 0.1 ;\n" +
            "m_FinishInsertTime= 0.5 ;\n" +
            "ShotGunPelletCount  = 4 ;\n" +
            "vecShotgunDM= Vector ( 0.08716, 0.04362, 0.00  );\n" +
            "\n" +
            "PumpSounds= 'hlclassic/weapons/scock1.wav';\n" +
            "ShotgunFinishSound= 'hlclassic/weapons/scock1.wav';\n" +
            "ShotgunInsertSound= 'hlclassic/weapons/reload3.wav';\n" +
            "\n" +
            "m_PumpTime2= 1 ;\n" +
            "ShotGunSubPelletCount= 8 ;\n" +
            "vecShotgunDM2 = Vector ( 0.17365, 0.04362, 0.00 );\n" +
            "\n" +
            "g_WeaponModel = \n" +
            "{\n" +
            "};\n" +
            "\n" +
            "g_WeaponSound = " +
            "{\n" +
            "'items/9mmclip1.wav'\n" +
            "};\n" +
            "g_WeaponSprites = {\n" +
            "'640hud1.spr',\n" +
            "'640hud4.spr',\n" +
            "'640hud7.spr',\n" +
            "'crosshairs.spr'\n" +
            "};\n" +
            "}\n" +
            "}\n" +
            "void RegisterExmShotgun()\n" +
            "{\n" +
            "g_CustomEntityFuncs.RegisterCustomEntity( 'weapon_hlshotgun', 'weapon_hlshotgun' );\n" +
            "g_ItemRegistry.RegisterWeapon( 'weapon_hlshotgun', 'hl_weapons', 'buckshot', '' ,'ammo_buckshot' , '');\n" +
            "}";
    }
}

