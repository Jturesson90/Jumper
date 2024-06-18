using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ChangeBackgroundColor : MonoBehaviour
{
    public Color[] lerpedColors;
    public Color lerpedColor = Color.white;
    public float colorChangeSpeed = 1f;
    private int currentColor;

    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        print("COLOR: " + lerpedColor);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            currentColor++;
            if (currentColor >= lerpedColors.Length) currentColor = 0;
        }

        spriteRenderer.color = Color.Lerp(spriteRenderer.color, lerpedColors[currentColor],
            colorChangeSpeed * Time.deltaTime);

        //spriteRenderer.material.color = Color.Lerp (spriteRenderer.material.color, lerpedColors [currentColor], colorChangeSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
    }
}