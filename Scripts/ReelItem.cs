using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ReelItem : MonoBehaviour
{
    [HideInInspector] public VideoPlayer videoPlayer;
    [HideInInspector] public RawImage rawImage;
    [HideInInspector] public RenderTexture renderTexture;

    void Start()
    {
        // Apply render texture to UI
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.targetTexture = renderTexture;
        rawImage.texture = renderTexture;

        videoPlayer.isLooping = true;
        videoPlayer.Play();
    }
}
