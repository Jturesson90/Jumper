using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public static float platformHeight = 25;
    public float platformSpeed = 5f;

    public bool firstPlatform;
    //SpriteRenderer spriteRendererInChild;

    private float halfWidth;
    private bool isAMovingPlatform;
    private float leftEdge, rightEdge;

    private bool seen;

    // Use this for initialization
    private void Awake()
    {
        platformHeight = transform.GetChild(0).GetComponent<Renderer>().bounds.size.y;

        leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        seen = false;
        halfWidth = transform.GetChild(0).GetComponent<Renderer>().bounds.size.x * 0.5f;
//				spriteRendererInChild = gameObject.GetComponentInChildren<SpriteRenderer> ();
    }

    private void Start()
    {
        if (!firstPlatform)
        {
            if (ScoreManager.score > 1500) isAMovingPlatform = Random.Range(0f, 1f) > 0.5f ? true : false;
            transform.position = new Vector3(Random.Range(leftEdge + halfWidth, rightEdge - halfWidth),
                transform.position.y, transform.position.z);
        }
    }

    private void Update()
    {
        if (gameObject.GetComponentInChildren<Renderer>().isVisible) seen = true;
        if (seen && !gameObject.GetComponentInChildren<Renderer>().isVisible) KillPlatform();

        if (isAMovingPlatform)
        {
            if (transform.position.x - halfWidth < leftEdge && platformSpeed < 0)
                platformSpeed = -platformSpeed;
            else if (transform.position.x + halfWidth > rightEdge && platformSpeed > 0) platformSpeed = -platformSpeed;
            transform.Translate(new Vector3(platformSpeed * Time.deltaTime, 0, 0));
        }
    }

    private void OnEnable()
    {
        seen = false;
        if (!firstPlatform)
        {
            if (ScoreManager.score > 1500) isAMovingPlatform = Random.Range(0f, 1f) > 0.5f ? true : false;
            transform.position = new Vector3(Random.Range(leftEdge + halfWidth, rightEdge - halfWidth),
                transform.position.y, transform.position.z);
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void KillPlatform()
    {
        Invoke("Destroy", 0f);
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
}