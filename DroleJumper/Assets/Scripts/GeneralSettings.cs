using UnityEngine;

public class GeneralSettings : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    private void Update()
    {
#if UNITY_ANDROID
				if (Input.GetKeyDown (KeyCode.Escape)) {
						Application.Quit ();
				}
#endif
    }
}