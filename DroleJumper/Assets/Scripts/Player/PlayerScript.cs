using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public const float JumpVelocity = 45;
    public const float MoveVelocity = 60;

    private AudioSource audioSource;

    private new Camera camera;

    private Collider2D collider2d;
    private Rigidbody2D rigidbody2d;

    // Use this for initialization
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();
        camera = Camera.main;
    }

    private void Start()
    {
        CheckTrigger();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckTrigger();
        HandleInput();
        HandlePlayerToBeOnScreen();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Bounce")) Jump();
    }

    private void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Bounce")) Jump();
    }


    private void HandlePlayerToBeOnScreen()
    {
        var positionInScreen = camera.WorldToScreenPoint(transform.position);
        if (positionInScreen.x < 0)
            transform.position =
                camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, positionInScreen.y,
                    positionInScreen.z));
        else if (positionInScreen.x > camera.pixelWidth)
            transform.position = camera.ScreenToWorldPoint(new Vector3(0, positionInScreen.y, positionInScreen.z));
        //transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
    }

    private void CheckTrigger()
    {
        collider2d.isTrigger = rigidbody2d.velocity.y > 0;
    }

    private void HandleInput()
    {
        float dirX = Input.acceleration.x * MoveVelocity * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow)) dirX = -MoveVelocity * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow)) dirX = MoveVelocity * Time.deltaTime;
        transform.Translate(dirX, 0, 0);
    }

    private void Jump()
    {
        rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, 0f);
        rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, JumpVelocity);
        audioSource.Play();
    }
}