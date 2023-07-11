using UnityEngine;
using System.IO;
using System.Diagnostics;
using System;

public class VideoWriter : IDisposable
{
    private string outputFilePath;
    private Process ffmpegProcess;

    public VideoWriter(string filePath, int width, int height, int frameRate)
    {
        outputFilePath = filePath;

        Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

        // Uruchom proces FFMpeg
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = Application.dataPath + "\\PatchKit\\InteractiveTexture\\Plugins\\FFMpeg_bin";
        startInfo.Arguments = $"-y -f rawvideo -vcodec rawvideo -s {width}x{height} -pix_fmt rgb24 -r {frameRate} -i - -c:v mpeg4 \"{outputFilePath}\"";
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardInput = true;
        ffmpegProcess = new Process();
        ffmpegProcess.StartInfo = startInfo;
        ffmpegProcess.Start();
    }

    public void WriteFrame(Texture2D frameTexture)
    {
        byte[] frameBytes = frameTexture.GetRawTextureData();
        ffmpegProcess.StandardInput.BaseStream.Write(frameBytes, 0, frameBytes.Length);
    }

    public void Dispose()
    {
        // Zakończ zapisywanie pliku wideo
        ffmpegProcess.StandardInput.Close();
        ffmpegProcess.WaitForExit();
        ffmpegProcess.Dispose();
    }
}
