using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
using OhmsLibraries.Utilities.Extensions;
using Sirenix.OdinInspector;
#if UNITY_EDITOR
using UnityEditor;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
#endif

public class PolygonStats : MonoBehaviour {

    private const int StatsCount = 15;

    [SerializeField]
    private Polygon _polygon;

    [SerializeField, ListDrawerSettings( HideAddButton = true, HideRemoveButton = true, OnBeginListElementGUI = "OnStartList", OnEndListElementGUI = "OnEndList" )]
    private CircleCoordinate[] _coordinates = new CircleCoordinate[StatsCount];

    public void UpdateStat ( Stats stat, float value ) {
        _coordinates[(int) stat].magnitude = DataNormalizer.Normalize( stat, value );
        _polygon.SetPointPosition( (int) stat, _coordinates[(int) stat].Vector );
    }

    public void ResetPoints () {
        for ( int i = 0; i < StatsCount; i++ ) {
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

#if UNITY_EDITOR
    private void Reset () {
        _polygon = GetComponent<Polygon>();
        _polygon.points = new List<Vector2>( StatsCount );
        ResetPoints();
    }


    [Button]
    private void ApplyCoordinates () {
        for ( int i = 0; i < StatsCount; i++ ) {
            Vector3 position = _coordinates[i].Vector;
            _polygon.SetPointPosition( i, position );
            position.z = -0.1f;
            transform.GetChild( i ).localPosition = position;
        }
    }

    private void OnStartList ( int index ) {
        SirenixEditorGUI.BeginBox();
        SirenixEditorGUI.BeginBoxHeader();
        EditorGUILayout.LabelField( ( (Stats) index ).ToString() );
        SirenixEditorGUI.EndBoxHeader();
    }

    private void OnEndList ( int index ) {
        SirenixEditorGUI.EndBox();
    }
#endif
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
