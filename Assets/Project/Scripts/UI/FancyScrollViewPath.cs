using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using Dreamteck.Splines;
public class FancyScrollViewPath : MonoBehaviour
{
    [SerializeField]
    private Vector3 _fromPosition, _endPosition;
    [SerializeField]
    private SplineComputer _spline;

    private Tweener _movementTween;

    private void Awake () {
        DOTween.Init();
    }
    
    public Vector3 Goto (float t) {
        return _spline.EvaluatePosition( t );
    }

    private void Start () {
        _movementTween = transform.DOMove( _endPosition, 1f );
        _movementTween.ChangeStartValue( _fromPosition );
    }
}
