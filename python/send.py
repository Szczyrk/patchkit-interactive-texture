import sys

import grpc

from schema_pb2 import BoolValue
from schema_service_pb2_grpc import MessageServiceStub

print(f"Sending message '{sys.argv[2]}' to {sys.argv[1]} ...")
channel = grpc.insecure_channel(sys.argv[1])
client = MessageServiceStub(channel)
answer = client.MessageOverlayReceivedMouseMoveMessage(OverlayReceivedMouseMoveMessage(message=sys.argv[2]))
print(f"Received answer: {answer.message}")
