using UnityEngine;
using Grpc.Core;
using Proto.Services;
using Proto.Messages;
using System.Threading.Tasks;

namespace PatchKit.InteractiveTexture.Core.gRPC
{
    public class TextureMessageHandler : MonoBehaviour
    {
        public int ServerPort;
        public TMPro.TMP_Text TargetText;
        private string _receivedMessage = null;

        private Server _grpcServer;

        void OnEnable()
        {
            _grpcServer = new Server
            {
                Ports = { new ServerPort("0.0.0.0", ServerPort, ServerCredentials.Insecure) }
            };
            _grpcServer.Services.Add(MessageService.BindService(new MessageServiceImpl(this)));
            _grpcServer.Start();
            Debug.Log($"GRPC Server running on port {ServerPort}");
        }

        void OnDisable()
        {
            _grpcServer.ShutdownAsync().Wait();
        }

        void Update()
        {
            if (_receivedMessage != null)
            {
                TargetText.text = _receivedMessage;
                _receivedMessage = null;
            }
        }

        class MessageServiceImpl : MessageService.MessageServiceBase
        {
            private TextureMessageHandler _parent;
            public MessageServiceImpl(TextureMessageHandler parent)
            {
                _parent = parent;
            }
            public override Task<BoolValue> MessageOverlayReceivedKeyboardInputMessage(OverlayReceivedKeyboardInputMessage request, ServerCallContext context)
            {
                _parent._receivedMessage = request.Key;
                return Task.FromResult(new BoolValue { Value = true }); ;
            }
        }
    }
}