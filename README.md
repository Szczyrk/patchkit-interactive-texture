# PatchKit interactive texture

Transform your Unity projects with the cutting-edge "Interactive Texture" plugin. Unleash your creativity by crafting dynamic textures that respond to cursor movement and touch input. Seamlessly integrated with the Electro Launcher, this powerful tool empowers you to revolutionize the look and feel of your textures, infusing your interactive experiences with unparalleled engagement. Elevate your projects to new heights with this essential plugin, where your imagination is the only limit.


## Example

### Compiling Protocol Buffer Messages

Both the Unity and Python projects include pre-compiled versions of the proto files found in the [proto](./proto) folder. However, if you want to customize and experiment with the proto files, follow these steps:

For Unity, use `dotnet` to build the mock project `csharp`. The `dotnet` command will automatically install all the required dependencies.

```shell
cd <repository_root>
dotnet build csharp
```

For Python, install `grpcio-tools` (preferably using `pip`) and run the `protoc` compiler. The compiled output will be written to the `python` folder.

```shell
cd <repository_root>
pip install -r requirements.txt
python -m grpc_tools.protoc -I ./proto --python_out=./python --grpc_python_out=./python ./proto/*.proto
```

### Running the Example

The example scene `/Assets/PatchKit/InteractiveTexture/Main.unity` includes a texture. When the scene starts, it creates a gRPC server. Moving the cursor over the texture creates a gRPC client and sends a message about the current position.

You can adjust the following empty GameObjects in the scene:

- `ServerPort`: The port for the Unity gRPC server (default is `9090`).
- `RemoteURL`: The URL (typically IP and port) of the *remote* gRPC server to send the message to (default is `localhost:9091`).

For testing purposes, you can run both the Unity project and the Python server/client on the same machine. When the scene is running in the Unity Editor, you can receive a message sent from Unity, start the Python server first using the following command:

```shell
# python python/receive.py <grpc_server_port>
python python/receive.py 9091
```

The server will listen on port `9091`, print messages when received from Unity.

Sample receive messages:
Received MouseInput message: 0 1
Received MouseInput message: 1 1
Received MouseMove message: 309 37
Received MouseWheelMove message: 1
Received MouseWheelMove message: 0
Received KeyboardInput message: a 1
Received KeyboardInput message: s 1