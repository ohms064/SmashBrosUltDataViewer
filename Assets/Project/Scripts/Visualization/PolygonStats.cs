using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
using OhmsLibraries.Utilities.Extensions;
using Sirenix.OdinInspector;

public class PolygonStats : MonoBehaviour {

    private const int StatsCount = 15;

    [SerializeField]
    private Polygon _polygon;

    [SerializeField, ListDrawerSettings( HideAddButton = true, HideRemoveButton = true )]
    private CircleCoordinate[] _coordinates = new CircleCoordinate[StatsCount];

    [Button]
    public void ApplyCoordinates () {
        for ( int i = 0; i < StatsCount; i++ ) {
            Vector3 position = _coordinates[i].Vector;
            _polygon.SetPointPosition( i, position );
            position.z = -0.1f;
            transform.GetChild( i ).localPosition = position;
        }
    }

#if UNITY_EDITOR
    private void Reset () {
        _polygon = GetComponent<Polygon>();
        _polygon.points = new List<Vector2>( StatsCount );
        for ( int i = 0; i< StatsCount; i++ ) {
            var rads = Mathf.Deg2Rad * 360 * i / StatsCount;
            var position = new Vector3( Mathf.Cos( rads ), Mathf.Sin( rads ) );
            _polygon.AddPoint( position );
            position.z = -0.1f;
            transform.GetChild( i ).localPosition = position;
        }

        for ( int i = 0; i < StatsCount; i++ ) {
            _coordinates[i] = new CircleCoordinate( 1, 360 * i / StatsCount );
        }
    }
#endif
}

public enum Stats {
    JumpSquad, SoftLanding, HardLanding, InitialDash, SingleDash, Weight, WalkSpeed, RunSpeed, AirSpeed, FallSpeed, FastFallSpeed, ShortHopTime, FullHopTime, ShortHopFastFallTime, FullHopFastFallTime
}

[System.Serializable]
public class CircleCoordinate {

    [HorizontalGroup]
    public float magnitude;
    [HorizontalGroup]
    public float angle;

    [ShowInInspector, DisableInEditorMode]
    public Vector2 Vector => new Vector2( Mathf.Cos( Rads ), Mathf.Sin( Rads ) ) * magnitude;

    public float Rads => Mathf.Deg2Rad * angle;
    public CircleCoordinate ( Vector2 vector ) {
        magnitude = vector.magnitude;
        angle = Mathf.Asin( vector.y / magnitude );
    }

    public CircleCoordinate ( float magnitude, float angle ) {
        this.magnitude = magnitude;
        this.angle = angle;
    }
}
