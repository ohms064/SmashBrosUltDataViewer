using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector;
using UnityEditor;
using LitJson;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.AddressableAssets;
public class CharacterImporter : OdinEditorWindow {

    [Required]
    public TextAsset _json;
    [FolderPath]
    public string _path = "";

    public AddressableAssetSettings _settings;

    [MenuItem( "Tools/Character Importer" )]
    public static void CreateWindow () {
        GetWindow<CharacterImporter>().Show();
    }

    [Button, EnableIf( "@_json && _path != \"\"" )]
    public void ImportCharacters () {

        //Get json data
        var json = _json.text;
        Character[] characters;
        try {
            characters = JsonMapper.ToObject<Character[]>( json );
        }
        catch {
            Debug.LogError( $"{_json.name} has an invalid json format" );
            return;
        }

        //Get addressable group
        var group =_settings ? _settings.DefaultGroup : null;

        foreach ( var character in characters ) {

            var profile = ScriptableObject.CreateInstance<CharacterProfile>();
            profile.name = character.Name;
            profile.Stats = character;
            var path = $"{_path}/{profile.name}.asset";
            
            AssetDatabase.CreateAsset( profile, path );

            if ( group ) {
                var guid = AssetDatabase.AssetPathToGUID( path );
                var entry = _settings.CreateOrMoveEntry( guid, group );

                entry.address = $"data/{profile.name}.asset";
                entry.labels.Add( "character_profile" );
            }
        }
        AssetDatabase.SaveAssets();
    }

}
