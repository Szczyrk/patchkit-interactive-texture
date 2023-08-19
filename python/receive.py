import sys
from concurrent.futures import ThreadPoolExecutor

import grpc

from schema_pb2 import BoolValue
from schema_service_pb2_grpc import MessageServiceServicer, add_MessageServiceServicer_to_server


class MessageServiceHandler(MessageServiceServicer):
    def MessageOverlayReceivedMouseMoveMessage(self, request, context):
        print(f"Received MouseMove message: {request.x_position} {request.y_position} from {context.peer()}")
        return BoolValue(value = 1)

    def MessageOverlayReceivedKeyboardInputMessage(self, request, context):
        print(f"Received KeyboardInput message: {request.key} {request.event_type} from {context.peer()}")
        return BoolValue(value = 1)

    def MessageOverlayReceivedMouseInputMessage(self, request, context):
        print(f"Received MouseInput message: {request.event_type} {request.button_type} from {context.peer()}")
        return BoolValue(value = 1)

    def MessageOverlayReceivedMouseWheelMoveMessage(self, request, context):
        print(f"Received MouseWheelMove message: {request.delta} from {context.peer()}")
        return BoolValue(value = 1)


server = grpc.server(ThreadPoolExecutor(max_workers=10))
add_MessageServiceServicer_to_server(MessageServiceHandler(), server)
server.add_insecure_port(f"0.0.0.0:{sys.argv[1]}")
server.start()
print(f"Server listening on port {sys.argv[1]} ...")
server.wait_for_termination()
