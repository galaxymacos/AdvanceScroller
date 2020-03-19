using UnityEngine;

public enum AudioType
{
    None,

    #region Sound Track

    ST_Grassland,
    ST_IceMap,

    #endregion

    #region Menu

    Pointer_Move,
    Pointer_Confirm,

    #endregion

    #region Axe Hero

    AxeHero_Jump,
    AxeHero_DoubleJump,
    AxeHero_Dash,
    AxeHero_Attack,
    AxeHero_ThrowAxe,
    AxeHero_HugeSlash,
    AxeHero_UltimateStart,
    AxeHero_UltimateCatchSuccess,
    AxeHero_UltimateThrow,

    #endregion

    #region Bat Hero

    BatHero_Jump,
    BatHero_DoubleJump,
    BatHero_Dash,
    BatHero_Punch01,
    BatHero_Punch02,
    BatHero_ThrowShuriki,
    BatHero_BatEnergy,
    BatHero_Fly,
    BatHero_InstantKillStart,
    BatHero_InstantKillHit,
    BatHero_InstantKillExplode,

    #endregion

    #region Cat Hero

    CatHero_Jump,
    CatHero_DoubleJump,
    CatHero_Dash,
    CatHero_Claw01,
    CatHero_Claw02,
    CatHero_Claw01Hit,
    CatHero_Claw02Hit,
    CatHero_LightingShield,
    CatHero_SendCat,
    CatHero_CatJump,
    CatHero_CatExplode,
    CatHero_BleedingClaw,

    #endregion

    #region Psychic Hero
    
    PsychicHero_Jump,
    PsychicHero_DoubleJump,
    PsychicHero_Dash,
    PsychicHero_ChargeSound,
    PsychicHero_ShootSmallDagger,
    PsychicHero_SmallDaggerHit,
    PsychicHero_ShootChargedDagger,
    PsychicHero_ChargedDaggerHit,
    PsychicHero_ThrowAxe,
    PsychicHero_AxeHit,
    PsychicHero_ThrowChargedAxe,
    PsychicHero_ChargedAxeHit,
    PsychicHero_Tornado,
    PsychicHero_TornadoHit,

    #endregion
    
    #region Sword Princess

    SwordPrincess_Dash,
    SwordPrincess_Jump,
    SwordPrincess_DoubleJump,
    SwordPrincess_NormalAttack,
    SwordPrincess_NormalAttackHit,
    SwordPrincess_ShootCross,
    SwordPrincess_CrossHit,
    SwordPrincess_ShootWolf,
    SwordPrincess_WolfHit,
    SwordPrincess_SwordDrill,

    #endregion

    #region Battle
    
    BloodExplosion,
    
    #endregion
    
    #region SceneSound
    
    Thunder,
    Lightning,

    #endregion
}