using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public Transform followTransform;
    public float offsetFollow = 1f;
    private Component[] childRenderers;

    private Vector3 newTransform;

    // Use this for initialization
    private void Awake()
    {
        childRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
    }

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private bool IsVisible()
    {
        foreach (SpriteRenderer rend in childRenderers)
            if (rend.isVisible)
                return true;
        return false;
    }
}