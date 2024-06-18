using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    public Transform otherTransform;
    private bool hasBeenShown;
    private Vector3 newTransform;
    private float spriteHeight;

    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteHeight = spriteRenderer.bounds.size.y;
        print("TJAAAAA: " + spriteHeight);
        hasBeenShown = spriteRenderer.isVisible;
    }

    // Update is called once per frame
    private void Update()
    {
        if (spriteRenderer.isVisible) hasBeenShown = true;
    }

    private void OnBecameInvisible()
    {
        if (hasBeenShown)
        {
            Move();
            hasBeenShown = false;
        }
    }

    private void OnBecameVisible()
    {
        hasBeenShown = true;
    }

    private void Move()
    {
        newTransform = otherTransform.position;
        newTransform.y = spriteHeight * 2 - 1f;
        print(newTransform.y);
        transform.position = newTransform;
        print("MOVE " + transform.name + "OTHER POSY: " + otherTransform.position.y + "MY Y: " + transform.position.y);
    }
}