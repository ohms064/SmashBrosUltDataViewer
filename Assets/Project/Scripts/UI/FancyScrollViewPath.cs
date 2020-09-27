using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using Dreamteck.Splines;
using Sirenix.OdinInspector;

public class FancyScrollViewPath : MonoBehaviour {
    public static FancyScrollViewPath Instance { get; private set; }

    [SerializeField]
    private SplineComputer _spline;
    [SerializeField, MinMaxSlider( 0.1f, 10f, true )]
    private Vector2 _scale = new Vector2( 1f, 5f );

    public Vector3 Goto ( float t ) {
        return _spline.EvaluatePosition( t );
    }

    public float GetScale ( float t ) {
        //var lerp = -Mathf.Abs( t - 0.5f ) + 0.5f; //linear
        var lerp = ( t - ( t > 0.5 ? 1 : 0 ) ); //Parabola
        lerp = 4 * lerp * lerp;
        return Mathf.Lerp( _scale.x, _scale.y, lerp );
    }

    private void Awake () {
        Instance = this;
    }

    private void OnDestroy () {
        if ( Instance != this ) Instance = null;
    }

#if UNITY_EDITOR
    [Button]
    private void SquiggleTest ( float step = 0.1f ) {
        for ( float t = 0; t <= 1f; t += step ) {
            var lerp = ( t - ( t > 0.5 ? 1 : 0 ) ); //Parabola
            lerp = 4 * lerp * lerp;
            DebugGraph.Log( "Scale Function", lerp, Color.red, t );
            DebugGraph.Log( "Scale Complete", GetScale( t ), Color.blue );
        }
    }
#endif
}
