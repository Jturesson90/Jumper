using UnityEngine;

public class SpawnPlatforms : MonoBehaviour
{
    public GameObject[] differentPlatforms;
    private ObjectPoolerScript objectPooler;
    private bool spawnedAllFirstPlatforms;

    private float y;

    // Use this for initialization
    private void Awake()
    {
        objectPooler = FindObjectOfType<ObjectPoolerScript>();
        y = transform.position.y + PlatformScript.platformHeight * 3;

        for (int i = 0; i < 50; i++) SpawnPlatform();

        spawnedAllFirstPlatforms = true;
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPlatform), 0f, 0.01f);
    }

    private void SpawnPlatform()
    {
        if (!spawnedAllFirstPlatforms)
            return;
        
        float x = Camera.main.pixelWidth / 2;
        var spawnPlatformPosition = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 10));

        spawnPlatformPosition.y = y;

        var newPlatform = objectPooler.GetPooledObject();

        if (newPlatform == null)
            return;

        newPlatform.transform.position = spawnPlatformPosition;
        newPlatform.transform.rotation = Quaternion.identity;
        newPlatform.SetActive(true);
        //	GameObject newPlatform = Instantiate (differentPlatforms [0], spawnPlatformPosition, Quaternion.identity) as GameObject;
        newPlatform.transform.parent = gameObject.transform;

        if (ScoreManager.score < 300)
            y += Random.Range(PlatformScript.platformHeight,
                PlayerScript.JumpVelocity * PlayerScript.JumpVelocity / (2 * -Physics2D.gravity.y) * 0.1f);
        else if (ScoreManager.score < 1000)
            y += Random.Range(PlatformScript.platformHeight,
                PlayerScript.JumpVelocity * PlayerScript.JumpVelocity / (2 * -Physics2D.gravity.y) * 0.5f);
        else if (ScoreManager.score < 2000)
            y += Random.Range(PlatformScript.platformHeight * 2,
                PlayerScript.JumpVelocity * PlayerScript.JumpVelocity / (2 * -Physics2D.gravity.y));
        else if (ScoreManager.score < 4000)
            y += Random.Range(PlatformScript.platformHeight * 4,
                PlayerScript.JumpVelocity * PlayerScript.JumpVelocity / (2 * -Physics2D.gravity.y));
        else
            y += PlayerScript.JumpVelocity * PlayerScript.JumpVelocity / (2 * -Physics2D.gravity.y) - 2f;
    }
}