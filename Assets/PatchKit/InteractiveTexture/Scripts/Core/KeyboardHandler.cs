using System;
using UnityEngine;

namespace PatchKit.InteractiveTexture.Core
{
    public class KeyboardHandler : MonoBehaviour
    {
        public event Action<KeyCode> OnKeyDown;
        public event Action<KeyCode> OnKeyUp;

        void OnGUI()
        {
            Event e = Event.current;
            if (e == null || e.keyCode == KeyCode.None)
            {
                return;
            }

            if (e.type == EventType.KeyDown)
            {
                OnKeyDown?.Invoke(e.keyCode);
            }
            else if (e.type == EventType.KeyUp)
            {
                OnKeyUp?.Invoke(e.keyCode);
            }
        }
    }
}