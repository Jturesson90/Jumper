using UnityEngine;

public class BottomDestroyItems : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player") Time.timeScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        print(coll.gameObject.name);
    }
}