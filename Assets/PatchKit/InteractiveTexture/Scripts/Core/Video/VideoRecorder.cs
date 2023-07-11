using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class VideoRecorder : MonoBehaviour
{
    public string OutputFolder = "Screenshots";
    public string OutputPrefix = "screenshot";
    public int FrameRate = 30;
    [Tooltip("Duration in ms")]
    public int Duration = 100;

    private bool isCaptureFramerate;

    void Start()
    {
        Directory.CreateDirectory(OutputFolder);
        Time.captureFramerate = FrameRate;
    }

    void OnGUI()
    {
        Event ec = Event.current;
        if (!isCaptureFramerate && ec.type == EventType.KeyDown && ec.keyCode == KeyCode.S && ec.control && ec.shift)
        {
            Debug.Log("Start CaptureScreenshot");
            isCaptureFramerate = true;
            StartCoroutine(CaptureScreenshot());
        }
    }

    private IEnumerator CaptureScreenshot()
    {
        int duration = 0;
        while (duration++ < Duration)
        {
            string outputName = string.Format("{0}/{1}_{2}.png", OutputFolder, OutputPrefix, DateTime.Now.ToString(" yyyy MMdd HHmmss")).Replace(" ", "_");
            ScreenCapture.CaptureScreenshot(outputName);
            yield return new WaitForSeconds(0.01f);
        }

        Debug.Log("Stop CaptureScreenshot");
        isCaptureFramerate = false;
    }
}