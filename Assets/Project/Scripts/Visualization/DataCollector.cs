using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Linq;

public class DataCollector : MonoBehaviour {
    [SerializeField]
    private AssetLabelReference _labelReference;
    [SerializeField]
    private CharacterScrollView _scrollView;

    private void Start () {
        var operation = Addressables.LoadAssetsAsync<CharacterProfile>( _labelReference, null );
        operation.Completed += op => {
            var stats = from c in op.Result select c.Stats;

            var maxStats = new Character();
            maxStats.JumpSquad = ( from s in stats select s.JumpSquad ).Max();
            maxStats.SoftLanding = ( from s in stats select s.SoftLanding ).Max();
            maxStats.HardLanding = ( from s in stats select s.HardLanding ).Max();
            maxStats.InitialDash = ( from s in stats select s.InitialDash ).Max();
            maxStats.SingleDash = ( from s in stats select s.SingleDash ).Max();
            maxStats.Weight = ( from s in stats select s.Weight ).Max();
            maxStats.WalkSpeed = ( from s in stats select s.WalkSpeed ).Max();
            maxStats.RunSpeed = ( from s in stats select s.RunSpeed ).Max();
            maxStats.AirSpeed = ( from s in stats select s.AirSpeed ).Max();
            maxStats.FallSpeed = ( from s in stats select s.FallSpeed ).Max();
            maxStats.FastFallSpeed = ( from s in stats select s.FastFallSpeed ).Max();
            maxStats.FullHopTime = ( from s in stats select s.FullHopTime).Max();
            maxStats.ShortHopTime = ( from s in stats select s.ShortHopTime ).Max();
            maxStats.FullHopFastFallTime = ( from s in stats select s.FullHopFastFallTime ).Max();
            maxStats.ShortHopFastFallTime = ( from s in stats select s.ShortHopFastFallTime ).Max();
            maxStats.FullHopFastFallTime = ( from s in stats select s.FullHopFastFallTime ).Max();
            DataNormalizer.MaxStats = maxStats;


            _scrollView.UpdateData( ( from c in op.Result select c.Stats ).ToList() );
        };
    }
}
