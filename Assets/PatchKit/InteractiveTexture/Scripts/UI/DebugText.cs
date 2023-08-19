using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PatchKit.InteractiveTexture.UI
{
    public class DebugText : MonoBehaviour
    {
        public Text text;
        public Core.InteractiveTexture interactiveTexture;
        private string _click;
        private Vector2 _position;

        private void OnEnable()
        {
            interactiveTexture.OnClickDown += OnClickDown;
            interactiveTexture.OnClickUp += OnClickUp;
            interactiveTexture.OnMove += OnMove;
            interactiveTexture.OnExit += OnExit;
        }

        private void OnDisable()
        {
            interactiveTexture.OnClickDown -= OnClickDown;
            interactiveTexture.OnClickUp -= OnClickUp;
            interactiveTexture.OnMove -= OnMove;
            interactiveTexture.OnExit -= OnExit;
        }

        private void OnClickDown(PointerEventData eventData)
        {
            _click = "Click";
        }

        private void OnClickUp(PointerEventData eventData)
        {
            _click = "";
        }

        private void OnMove(Vector2 position)
        {
            _position = position;
        }

        private void OnExit()
        {
            _position = Vector2.zero;
        }

        private void Update()
        {
            text.text = $"{_position.x} x {_position.y}\n{_click}";
        }
    }
}