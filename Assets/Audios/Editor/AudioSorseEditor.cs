using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Text.RegularExpressions;
using System;

[CustomEditor(typeof(Audio))]

public class AudioSorseEditor : Editor
{
    [SerializeField] private TextureMap _textureMap;
    private SerializedProperty _serializedProperty;
    private Audio _audioSorse;
    private AudioClip _clip;
    private string _pathToEnume;
    private string _trecMame;
    private EnumerationsOfAudioSettings _audioType;

    private const string _enumeFiel = "EnumerationsOfAudioSettings";

    private void OnEnable()
    {
        _audioSorse = (Audio)target;
        _serializedProperty = serializedObject.FindProperty("Clips");
        _pathToEnume = AssetDatabase.GUIDToAssetPath(AssetDatabase.FindAssets(_enumeFiel)[0]);
        if (_audioSorse.Clips == null)
        {
            _audioSorse.InitializeAudio();
        }
    }

    public override void OnInspectorGUI()
    {
        if (_serializedProperty.arraySize > 0)
        {
            DrawAudioSetting();
        }

        DrawAddingNewClip();
        serializedObject.ApplyModifiedProperties();
    }

    private void DrawAddingNewClip()
    {
        _trecMame = EditorGUILayout.TextField("Name to save settings", _trecMame);
        _clip = (AudioClip)EditorGUILayout.ObjectField(_clip, typeof(AudioClip), true);
        DrawAddButton();
    }

    private void DrawAddButton()
    {
        if (GUILayout.Button("Saving Settings"))
        {
            if (_clip)
            {
                AudioSourceClips AudioSourceClips = new AudioSourceClips(_clip);
                _audioSorse.AddTrec(AudioSourceClips);
                AddSettingName();
                _clip = null;
            }
            else
            {
                Debug.LogError("No track specified");
            }
        }
    }

    private void AddSettingName()
    {
        if (_trecMame == string.Empty)
        {
            return;
        }
        if (!Regex.IsMatch(_trecMame, @"^[a-zA-Z][a-zA-Z0-9_]*$"))
        {
            return;
        }

        Array array = Enum.GetValues(typeof(EnumerationsOfAudioSettings));
        if (array.Length != 0)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (_trecMame == array.GetValue(i).ToString())
                {
                    _trecMame = string.Empty;
                    Debug.LogError("This name already exists");
                }
            }
        }

        EmumEditor.WriteTofail(_trecMame, _pathToEnume);
        Refresh();
        _trecMame = string.Empty;
    }

    private void Refresh()
    {
        Debug.Log("WAIH");
        var path = _pathToEnume.Substring(_pathToEnume.IndexOf("Assets"));
        AssetDatabase.ImportAsset(path);
    }

    private void DrawAudioSetting()
    {
        const float minValue = 0f;
        const float maxValue = 1f;
        const float minPitch = -3f;
        const float MaxPitch = 3f;
        var style = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter };
        EditorGUILayout.BeginVertical(GUI.skin.window);
        EditorGUILayout.BeginVertical(GUI.skin.window);
        EditorGUILayout.LabelField("Track Name", style, GUILayout.ExpandWidth(true));
        EditorGUILayout.LabelField(_audioSorse.Clips[(int)_audioType].Clip.name, style, GUILayout.ExpandWidth(true));
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginHorizontal(GUI.skin.box);
        _audioType = (EnumerationsOfAudioSettings)EditorGUILayout.EnumPopup(_audioType);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.LabelField(name);
        _audioSorse.Clips[(int)_audioType].Volue = EditorGUILayout.Slider("Volue", _audioSorse.Clips[(int)_audioType].Volue, minValue, maxValue);
        _audioSorse.Clips[(int)_audioType].Pitch = EditorGUILayout.Slider("Pitch", _audioSorse.Clips[(int)_audioType].Pitch, minPitch, MaxPitch);
        EditorGUILayout.BeginHorizontal();
        Play(_audioType);
        Pause(_audioType);
        Stop(_audioType);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
        if (GUI.changed)
        {
            EditorUtility.SetDirty(_audioSorse);
            EditorSceneManager.MarkSceneDirty(_audioSorse.gameObject.scene);
        }
    }

    private void Play(EnumerationsOfAudioSettings name)
    {
        if (GUILayout.Button(_textureMap.Play))
        {
            _audioSorse.Play(name);
        }
    }

    private void Pause(EnumerationsOfAudioSettings name)
    {
        if (GUILayout.Button(_textureMap.Pause))
        {
            _audioSorse.Pause(name);
        }
    }

    private void Stop(EnumerationsOfAudioSettings name)
    {
        if (GUILayout.Button(_textureMap.Stop))
        {
            _audioSorse.Stop(name);
        }
    }
}
