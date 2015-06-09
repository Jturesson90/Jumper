using UnityEngine;
using System.Collections;

public class SpawnPlatforms : MonoBehaviour
{

		public GameObject[] differentPlatforms;
		private float y = 0;
		ObjectPoolerScript objectPooler;
		bool spawnedAllFirstPlatforms = false;
		// Use this for initialization
		void Awake ()
		{
				objectPooler = GameObject.Find ("PlatformPooler").GetComponent<ObjectPoolerScript> ();
				y = (transform.position.y + (PlatformScript.PLATFORM_HEIGHT * 3));
				
				for (int i = 0; i < 0; i++) {
						SpawnPlatform ();
						
				}
				
				spawnedAllFirstPlatforms = true;
				

		}
		void Start ()
		{
				InvokeRepeating ("SpawnPlatform", 0f, 0.01f);
		}

		private void SpawnPlatform ()
		{
				if (!spawnedAllFirstPlatforms)
						return;
				
				float x = Camera.main.pixelWidth / 2;
				Vector3 spawnPlatformPosition = Camera.main.ScreenToWorldPoint (new Vector3 (x, y, 10));
			
				spawnPlatformPosition.y = y;
			
				GameObject newPlatform = objectPooler.GetPooledObject ();

				if (newPlatform == null)
						return;
				
				newPlatform.transform.position = spawnPlatformPosition;
				newPlatform.transform.rotation = Quaternion.identity;
				newPlatform.SetActive (true);
				//	GameObject newPlatform = Instantiate (differentPlatforms [0], spawnPlatformPosition, Quaternion.identity) as GameObject;
				newPlatform.transform.parent = gameObject.transform;

				if (ScoreManager.score < 300) {
						y += Random.Range (PlatformScript.PLATFORM_HEIGHT, (PlayerScript.JUMP_VELOCITY * PlayerScript.JUMP_VELOCITY / (2 * -Physics2D.gravity.y) * 0.1f));
				} else if (ScoreManager.score < 1000) {
						y += Random.Range (PlatformScript.PLATFORM_HEIGHT, (PlayerScript.JUMP_VELOCITY * PlayerScript.JUMP_VELOCITY / (2 * -Physics2D.gravity.y) * 0.5f));
				} else if (ScoreManager.score < 2000) {
						y += Random.Range (PlatformScript.PLATFORM_HEIGHT * 2, PlayerScript.JUMP_VELOCITY * PlayerScript.JUMP_VELOCITY / (2 * -Physics2D.gravity.y));
				} else if (ScoreManager.score < 4000) {
						y += Random.Range (PlatformScript.PLATFORM_HEIGHT * 4, PlayerScript.JUMP_VELOCITY * PlayerScript.JUMP_VELOCITY / (2 * -Physics2D.gravity.y));
				} else {
						y += PlayerScript.JUMP_VELOCITY * PlayerScript.JUMP_VELOCITY / (2 * -Physics2D.gravity.y) - 2f;
				}
		}
}
