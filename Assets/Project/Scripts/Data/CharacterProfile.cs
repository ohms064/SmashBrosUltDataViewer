using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CharacterProfile : ScriptableObject {

    [SerializeField, PreviewField]
    private Sprite _portrait;

    [SerializeField]
    private Character _character;

    public Character Stats { get => _character; set => _character = value; }
}
