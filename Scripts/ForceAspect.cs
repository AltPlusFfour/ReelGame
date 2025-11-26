using UnityEngine;

public class ForceAspect : MonoBehaviour
{
    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Camera.main.aspect = 9f / 16f;
    }
}
