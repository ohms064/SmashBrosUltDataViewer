using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;
public class CharacterCell : FancyCell<Character> {
    [SerializeField]
    private PolygonStats _stats;
    public override void UpdateContent ( Character itemData ) {
        _stats.UpdateStat( Stats.JumpSquad, itemData.JumpSquad );
        _stats.UpdateStat( Stats.SoftLanding, itemData.SoftLanding );
        _stats.UpdateStat( Stats.HardLanding, itemData.HardLanding );
        _stats.UpdateStat( Stats.InitialDash, itemData.InitialDash );
        _stats.UpdateStat( Stats.SingleDash, itemData.SingleDash );
        _stats.UpdateStat( Stats.Weight, itemData.Weight );
        _stats.UpdateStat( Stats.WalkSpeed, itemData.WalkSpeed );
        _stats.UpdateStat( Stats.RunSpeed, itemData.RunSpeed );
        _stats.UpdateStat( Stats.AirSpeed, itemData.AirSpeed );
        _stats.UpdateStat( Stats.FallSpeed, itemData.FallSpeed );
        _stats.UpdateStat( Stats.FastFallSpeed, itemData.FastFallSpeed );
        _stats.UpdateStat( Stats.ShortHopTime, itemData.ShortHopTime );
        _stats.UpdateStat( Stats.FullHopTime, itemData.FullHopTime );
        _stats.UpdateStat( Stats.ShortHopFastFallTime, itemData.ShortHopFastFallTime );
    }

    public override void UpdatePosition ( float position ) {

    }
}
