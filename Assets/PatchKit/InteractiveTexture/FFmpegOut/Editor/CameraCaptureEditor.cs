// FFmpegOut - FFmpeg video encoding plugin for Unity
// https://github.com/keijiro/KlakNDI

using UnityEngine;
using UnityEditor;
using System.Linq;

namespace FFmpegOut
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(CameraCapture))]
    public class CameraCaptureEditor : Editor
    {
        SerializedProperty _preset;
        SerializedProperty _frameRate;

        GUIContent[] _presetLabels;
        int[] _presetOptions;

        void OnEnable()
        {
            _preset = serializedObject.FindProperty("_preset");
            _frameRate = serializedObject.FindProperty("_frameRate");

            var presets = FFmpegPreset.GetValues(typeof(FFmpegPreset));
            _presetLabels = presets.Cast<FFmpegPreset>().
                Select(p => new GUIContent(p.GetDisplayName())).ToArray();
            _presetOptions = presets.Cast<int>().ToArray();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.IntPopup(_preset, _presetLabels, _presetOptions);
            EditorGUILayout.PropertyField(_frameRate);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
