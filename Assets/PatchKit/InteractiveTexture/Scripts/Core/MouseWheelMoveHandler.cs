using System;
using UnityEngine;

namespace PatchKit.InteractiveTexture.Core
{
    public class MouseWheelMoveHandler : MonoBehaviour
    {
        public event Action<uint> OnWheelMove;

        void OnGUI()
        {
            Event e = Event.current;
            if (e == null)
            {
                return;
            }

            if (e.isScrollWheel)
            {
                Debug.Log(e.delta);
                uint delta = (uint)(e.delta.y > 0 ? 1 : 0);
                OnWheelMove?.Invoke(delta);
            }
        }
    }
}