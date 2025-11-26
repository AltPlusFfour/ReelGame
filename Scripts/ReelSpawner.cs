using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ReelSpawner : MonoBehaviour
{
    public GameObject reelPrefab;
    public Transform parent;               // ScrollView Content
    public RenderTexture renderTexture;    // Drag once in Inspector
    public string folderName = "Reels";    // StreamingAssets/Reels

    void Start()
    {
        string folderPath = Path.Combine(Application.streamingAssetsPath, folderName);
        string[] videos = Directory.GetFiles(folderPath, "*.mp4");

        foreach (string path in videos)
        {
            GameObject reelObj = Instantiate(reelPrefab, parent);
            ReelItem reelItem = reelObj.GetComponent<ReelItem>();

            // Assign components
            reelItem.videoPlayer = reelObj.GetComponent<VideoPlayer>();
            reelItem.rawImage = reelObj.GetComponent<RawImage>();
            reelItem.renderTexture = renderTexture;

            // Assign StreamingAssets video
            reelItem.videoPlayer.url = path;
        }
    }
}
