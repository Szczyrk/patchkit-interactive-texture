using Grpc.Core;
using UnityEngine;
using Proto.Messages;
using Proto.Services;
using System;
using UnityEngine.EventSystems;

namespace PatchKit.InteractiveTexture.Core.gRPC
{
    public partial class TextureMessageSender : MonoBehaviour
    {
        public string RemoteURL;
        public InteractiveTexture interactiveTexture;
        public KeyboardHandler keyboardHandler;
        public MouseWheelMoveHandler mouseWheelMoveHandler;

        private void OnEnable()
        {
            interactiveTexture.OnClickDown += OnClickDown;
            interactiveTexture.OnClickUp += OnClickUp;
            interactiveTexture.OnMove += OnMove;
            keyboardHandler.OnKeyDown += OnKeyDown;
            keyboardHandler.OnKeyUp += OnKeyUp;
            mouseWheelMoveHandler.OnWheelMove += OnWheelMove;
        }

        private void OnDisable()
        {
            interactiveTexture.OnClickDown -= OnClickDown;
            interactiveTexture.OnClickUp -= OnClickUp;
            interactiveTexture.OnMove -= OnMove;
            keyboardHandler.OnKeyDown -= OnKeyDown;
            keyboardHandler.OnKeyUp -= OnKeyUp;
            mouseWheelMoveHandler.OnWheelMove -= OnWheelMove;
        }

        private void OnMove(Vector2 position)
        {
            SendMouseCursorPositionMessage((uint)position.x, (uint)position.y);
        }

        private void OnClickUp(PointerEventData eventData)
        {
            SendMouseInputMessage(OverlayReceivedMouseInputMessage.Types.EVENT_TYPE.ButtonUp, GetMauseButtonCode(eventData));
        }

        private void OnClickDown(PointerEventData eventData)
        {
            SendMouseInputMessage(OverlayReceivedMouseInputMessage.Types.EVENT_TYPE.ButtonDown, GetMauseButtonCode(eventData)); ;
        }

        private void OnKeyDown(KeyCode key)
        {
            SendKeyboardInputMessage(OverlayReceivedKeyboardInputMessage.Types.EVENT_TYPE.KeyDown, key);
        }

        private void OnKeyUp(KeyCode key)
        {
            SendKeyboardInputMessage(OverlayReceivedKeyboardInputMessage.Types.EVENT_TYPE.KeyUp, key);
        }

        private void OnWheelMove(uint delta)
        {
            SendMouseWheelMoveMessage(delta);
        }

        public void SendKeyboardInputMessage(OverlayReceivedKeyboardInputMessage.Types.EVENT_TYPE eventKey, KeyCode keyCode)
        {
            var channel = new Channel(RemoteURL, ChannelCredentials.Insecure);
            var client = new MessageService.MessageServiceClient(channel);
            var message = new OverlayReceivedKeyboardInputMessage { EventType = eventKey, Key = KeyboardParser.GetKeyCode(keyCode) };
            Debug.Log($"Sending KeyboardInput message '{eventKey}' and '{keyCode}' to {RemoteURL}");
            var answer = client.MessageOverlayReceivedKeyboardInputMessage(message);
        }

        public void SendMouseInputMessage(OverlayReceivedMouseInputMessage.Types.EVENT_TYPE eventButton, OverlayReceivedMouseInputMessage.Types.BUTTON_TYPE buttonType)
        {
            var channel = new Channel(RemoteURL, ChannelCredentials.Insecure);
            var client = new MessageService.MessageServiceClient(channel);
            var message = new OverlayReceivedMouseInputMessage { EventType = eventButton, ButtonType = buttonType };
            Debug.Log($"Sending MouseInput message '{eventButton}' and '{buttonType}' to {RemoteURL}");
            var answer = client.MessageOverlayReceivedMouseInputMessage(message);
        }

        public void SendMouseCursorPositionMessage(uint x, uint y)
        {
            var channel = new Channel(RemoteURL, ChannelCredentials.Insecure);
            var client = new MessageService.MessageServiceClient(channel);
            var message = new OverlayReceivedMouseMoveMessage { XPosition = x, YPosition = y };
            Debug.Log($"Sending MouseCursorPosition message '{x}':'{y}' to {RemoteURL}");
            var answer = client.MessageOverlayReceivedMouseMoveMessage(message);
        }

        public void SendMouseWheelMoveMessage(uint delta)
        {
            var channel = new Channel(RemoteURL, ChannelCredentials.Insecure);
            var client = new MessageService.MessageServiceClient(channel);
            var message = new OverlayReceivedMouseWheelMoveMessage { Delta = delta };
            Debug.Log($"Sending MouseWheelMove message '{delta}' to {RemoteURL}");
            var answer = client.MessageOverlayReceivedMouseWheelMoveMessage(message);
        }

        public OverlayReceivedMouseInputMessage.Types.BUTTON_TYPE GetMauseButtonCode(PointerEventData eventData)
        {
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Left:
                    return OverlayReceivedMouseInputMessage.Types.BUTTON_TYPE.Left;
                case PointerEventData.InputButton.Right:
                    return OverlayReceivedMouseInputMessage.Types.BUTTON_TYPE.Right;
                case PointerEventData.InputButton.Middle:
                    return OverlayReceivedMouseInputMessage.Types.BUTTON_TYPE.Middle;
                default:
                    throw new NotImplementedException($"Key {Enum.GetName(typeof(PointerEventData.InputButton), eventData.button)} not implemented.");
            }
        }
    }
}