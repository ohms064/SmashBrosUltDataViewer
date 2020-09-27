using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class CharacterScrollView : FancyScrollView<Character> {

    [SerializeField]
    private CharacterCell _cellPrefab;

    [SerializeField]
    ScrollPositionController scrollPositionController;
    protected override GameObject CellPrefab => _cellPrefab.gameObject;

#if UNITY_EDITOR
    [ShowInInspector]
    private IList<Character> EditorData => ItemsSource;
#endif

    private void Awake () {
        scrollPositionController.OnUpdatePosition( UpdatePosition );
    }

    public void UpdateData ( IList<Character> data ) {
        ItemsSource = data;
        scrollPositionController.SetDataCount( ItemsSource.Count );
        UpdateContents(data);
    }

#if UNITY_EDITOR

#endif
}
