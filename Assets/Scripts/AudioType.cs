using UnityEngine;

public enum AudioType
{
    None,

    #region Sound Track

    ST_Grassland1,
    ST_Grassland2,
    ST_Grassland3,
    ST_Grassland4,
    ST_IceMap1,
    ST_IceMap2,
    ST_IceMap3,
    ST_IceMap4,
    ST_Dungeon1,
    ST_Dungeon2,
    ST_Dungeon3,
    ST_Dungeon4,

    #endregion

    #region Menu

    Pointer_Move,
    Pointer_Confirm,

    #endregion

    #region Axe Hero

    AxeHero_Jump,
    AxeHero_DoubleJump,
    AxeHero_Run,
    AxeHero_Dash,
    AxeHero_Attack,
    AxeHero_AttackStrengthen,
    AxeHero_ThrowAxe,
    AxeHero_HugeSlash,
    AxeHero_UltimateStart,
    AxeHero_UltimateCatchSuccess,
    AxeHero_UltimateThrow,
    AxeHero_AxeHit,

    #endregion

    #region Bat Hero

    BatHero_Jump,
    BatHero_DoubleJump,
    BatHero_Run,
    BatHero_Dash,
    BatHero_Punch,
    BatHero_ThrowShuriki,
    BatHero_BatEnergy,
    BatHero_BatTransform,
    BatHero_HumanTransform,
    BatHero_InstantKillStart,
    BatHero_InstantKillHit,
    BatHero_InstantKillExplode,
    BatHero_PunchHit,
    BatHero_ShurikiHit,
    BatHero_BatEnergyHit,


    #endregion

    #region Cat Hero

    CatHero_Jump,
    CatHero_DoubleJump,
    CatHero_Run,
    CatHero_Dash,
    CatHero_Claw,
    CatHero_Claw2,
    CatHero_ClawHit,
    CatHero_Claw2Hit,
    CatHero_LightingShield,
    CatHero_SendCat,
    CatHero_CatJump,
    CatHero_CatExplode,
    CatHero_BleedingClaw,

    #endregion

    #region Psychic Hero
    
    PsychicHero_Jump,
    PsychicHero_DoubleJump,
    PsychicHero_Run,
    PsychicHero_Dash,
    PsychicHero_ShootSmallDagger,
    PsychicHero_ChargeSound,
    PsychicHero_ShootChargedDagger,
    PsychicHero_ThrowAxe,
    PsychicHero_ThrowChargedAxe,
    PsychicHero_Tornado,
    PsychicHero_Beam,
    PsychicHero_InstantKillStart,

    PsychicHero_SmallDaggerHit,
    PsychicHero_ChargedDaggerHit,
    PsychicHero_AxeHit,
    PsychicHero_ChargedAxeHit,
    PsychicHero_TornadoHit,

    #endregion

    #region Sword Princess

    SwordPrincess_Dash,
    SwordPrincess_Jump,
    SwordPrincess_DoubleJump,
    SwordPrincess_Run,
    SwordPrincess_NormalAttack,
    SwordPrincess_NormalAttackHit,
    SwordPrincess_ShootCross,
    SwordPrincess_CrossHit,
    SwordPrincess_ShootWolf,
    SwordPrincess_WolfHit,
    SwordPrincess_SwordDrill,
    SwordPrincess_InstantKillStart,
    SwordPrincess_WolfBite,


    #endregion

    #region Battle

    HitSoundGeneral,
    
    #endregion
    
    #region SceneSound
    
    Thunder,
    Lightning,

    #endregion
}