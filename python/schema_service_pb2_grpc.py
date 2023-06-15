# Generated by the gRPC Python protocol compiler plugin. DO NOT EDIT!
"""Client and server classes corresponding to protobuf-defined services."""
import grpc

import schema_pb2 as schema__pb2


class MessageServiceStub(object):
    """*

    """

    def __init__(self, channel):
        """Constructor.

        Args:
            channel: A grpc.Channel.
        """
        self.MessageOverlayReceivedKeyboardInputMessage = channel.unary_unary(
                '/MessageService/MessageOverlayReceivedKeyboardInputMessage',
                request_serializer=schema__pb2.OverlayReceivedKeyboardInputMessage.SerializeToString,
                response_deserializer=schema__pb2.BoolValue.FromString,
                )
        self.MessageOverlayReceivedMouseMoveMessage = channel.unary_unary(
                '/MessageService/MessageOverlayReceivedMouseMoveMessage',
                request_serializer=schema__pb2.OverlayReceivedMouseMoveMessage.SerializeToString,
                response_deserializer=schema__pb2.BoolValue.FromString,
                )
        self.MessageOverlayReceivedMouseInputMessage = channel.unary_unary(
                '/MessageService/MessageOverlayReceivedMouseInputMessage',
                request_serializer=schema__pb2.OverlayReceivedMouseInputMessage.SerializeToString,
                response_deserializer=schema__pb2.BoolValue.FromString,
                )
        self.MessageOverlayReceivedMouseWheelMoveMessage = channel.unary_unary(
                '/MessageService/MessageOverlayReceivedMouseWheelMoveMessage',
                request_serializer=schema__pb2.OverlayReceivedMouseWheelMoveMessage.SerializeToString,
                response_deserializer=schema__pb2.BoolValue.FromString,
                )


class MessageServiceServicer(object):
    """*

    """

    def MessageOverlayReceivedKeyboardInputMessage(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def MessageOverlayReceivedMouseMoveMessage(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def MessageOverlayReceivedMouseInputMessage(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def MessageOverlayReceivedMouseWheelMoveMessage(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')


def add_MessageServiceServicer_to_server(servicer, server):
    rpc_method_handlers = {
            'MessageOverlayReceivedKeyboardInputMessage': grpc.unary_unary_rpc_method_handler(
                    servicer.MessageOverlayReceivedKeyboardInputMessage,
                    request_deserializer=schema__pb2.OverlayReceivedKeyboardInputMessage.FromString,
                    response_serializer=schema__pb2.BoolValue.SerializeToString,
            ),
            'MessageOverlayReceivedMouseMoveMessage': grpc.unary_unary_rpc_method_handler(
                    servicer.MessageOverlayReceivedMouseMoveMessage,
                    request_deserializer=schema__pb2.OverlayReceivedMouseMoveMessage.FromString,
                    response_serializer=schema__pb2.BoolValue.SerializeToString,
            ),
            'MessageOverlayReceivedMouseInputMessage': grpc.unary_unary_rpc_method_handler(
                    servicer.MessageOverlayReceivedMouseInputMessage,
                    request_deserializer=schema__pb2.OverlayReceivedMouseInputMessage.FromString,
                    response_serializer=schema__pb2.BoolValue.SerializeToString,
            ),
            'MessageOverlayReceivedMouseWheelMoveMessage': grpc.unary_unary_rpc_method_handler(
                    servicer.MessageOverlayReceivedMouseWheelMoveMessage,
                    request_deserializer=schema__pb2.OverlayReceivedMouseWheelMoveMessage.FromString,
                    response_serializer=schema__pb2.BoolValue.SerializeToString,
            ),
    }
    generic_handler = grpc.method_handlers_generic_handler(
            'MessageService', rpc_method_handlers)
    server.add_generic_rpc_handlers((generic_handler,))


 # This class is part of an EXPERIMENTAL API.
class MessageService(object):
    """*

    """

    @staticmethod
    def MessageOverlayReceivedKeyboardInputMessage(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/MessageService/MessageOverlayReceivedKeyboardInputMessage',
            schema__pb2.OverlayReceivedKeyboardInputMessage.SerializeToString,
            schema__pb2.BoolValue.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def MessageOverlayReceivedMouseMoveMessage(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/MessageService/MessageOverlayReceivedMouseMoveMessage',
            schema__pb2.OverlayReceivedMouseMoveMessage.SerializeToString,
            schema__pb2.BoolValue.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def MessageOverlayReceivedMouseInputMessage(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/MessageService/MessageOverlayReceivedMouseInputMessage',
            schema__pb2.OverlayReceivedMouseInputMessage.SerializeToString,
            schema__pb2.BoolValue.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def MessageOverlayReceivedMouseWheelMoveMessage(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/MessageService/MessageOverlayReceivedMouseWheelMoveMessage',
            schema__pb2.OverlayReceivedMouseWheelMoveMessage.SerializeToString,
            schema__pb2.BoolValue.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)
