using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Recording : MonoBehaviour
{
    void SaveCameraView(Camera cam)
    {
        RenderTexture screenTexture = new RenderTexture(Screen.width, Screen.height, 16);
        cam.targetTexture = screenTexture;
        RenderTexture.active = screenTexture;
        cam.Render();
        Texture2D renderedTexture = new Texture2D(Screen.width, Screen.height);
        renderedTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        RenderTexture.active = null;
        byte[] byteArray = renderedTexture.EncodeToPNG();
        System.IO.File.WriteAllBytes(Application.dataPath + "/cameracapture.png", byteArray);
    }

    public int frameRate = 30;
    public string outputFileName = "gameplay.mp4";
    public RawImage previewImage;

    private bool isRecording = false;
    private RenderTexture renderTexture;
    private VideoWriter videoWriter;

    void Start()
    {
        // Utwórz RenderTexture o rozmiarze ekranu gry
        renderTexture = new RenderTexture(Screen.width, Screen.height, 24);

        // Przypisz RenderTexture do kamery
        Camera.main.targetTexture = renderTexture;
    }

    void Update()
    {
        // Rozpocznij nagrywanie, jeśli nie jest już uruchomione i naciśnięto przycisk nagrywania
        if (!isRecording && Input.GetKeyDown(KeyCode.R))
        {
            StartRecording();
        }

        // Zatrzymaj nagrywanie, jeśli nagrywanie jest w trakcie i naciśnięto ponownie przycisk nagrywania
        else if (isRecording && Input.GetKeyDown(KeyCode.R))
        {
            StopRecording();
        }
    }

    void StartRecording()
    {
        // Inicjalizuj VideoWriter
        videoWriter = new VideoWriter(outputFileName, frameRate, Screen.width, Screen.height);

        // Uruchom nagrywanie
        isRecording = true;
    }

    void StopRecording()
    {
        // Zatrzymaj nagrywanie
        isRecording = false;

        // Zakończ i zamknij VideoWriter
        videoWriter.Dispose();
        videoWriter = null;

        // Wyświetl podgląd zakończonego nagrania
        previewImage.texture = LoadVideoAsTexture(outputFileName);
    }

    void LateUpdate()
    {
        // Zapisuj ramki tylko podczas nagrywania
        if (isRecording)
        {
            RenderTexture.active = renderTexture;
            Texture2D frameTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            frameTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            frameTexture.Apply();

            // Zapisz ramkę do VideoWriter
            //videoWriter.WriteFrame(frameTexture);

            Destroy(frameTexture);
        }
    }

    Texture2D LoadVideoAsTexture(string videoPath)
    {
        VideoPlayer videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.url = videoPath;
        videoPlayer.renderMode = VideoRenderMode.APIOnly;
        videoPlayer.playOnAwake = false;
        videoPlayer.frame = 0;

        videoPlayer.Prepare();

        while (!videoPlayer.isPrepared)
        {
            // Oczekiwanie na przygotowanie wideo
        }

        Texture2D videoTexture = new Texture2D((int)videoPlayer.texture.width, (int)videoPlayer.texture.height, TextureFormat.RGB24, false);
        //videoTexture.SetPixels32(videoPlayer.texture.GetPixels32());
        videoTexture.Apply();

        Destroy(videoPlayer);

        return videoTexture;
    }
}
