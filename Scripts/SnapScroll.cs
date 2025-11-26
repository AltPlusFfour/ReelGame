using UnityEngine;
using UnityEngine.Video;

public class SnapScroll : MonoBehaviour
{
    public Transform parent; // Parent that holds reel objects
    private int currentIndex = 0;

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            ScrollNext();
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            ScrollPrevious();
    }

    void Start()
    {
        MoveToCurrent(); // Force it to stop other videos at launch
    }
    void ScrollNext()
    {
        currentIndex = Mathf.Clamp(currentIndex + 1, 0, parent.childCount - 1);
        MoveToCurrent();
    }

    void ScrollPrevious()
    {
        currentIndex = Mathf.Clamp(currentIndex - 1, 0, parent.childCount - 1);
        MoveToCurrent();
    }

    void MoveToCurrent()
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            GameObject child = parent.GetChild(i).gameObject;
            bool isActive = (i == currentIndex);

            child.SetActive(isActive);  // Only show this one

            // Stop videos on inactive ones
            var player = child.GetComponent<VideoPlayer>();
            if (player != null)
            {
                if (isActive) player.Play();
                else player.Stop();
            }
        }
    }
}
