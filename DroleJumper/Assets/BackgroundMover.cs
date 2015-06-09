using UnityEngine;
using System.Collections;

public class BackgroundMover : MonoBehaviour
{

		public Transform otherTransform;
		private Vector3 newTransform;
		private SpriteRenderer spriteRenderer;
		private float spriteHeight;
		bool hasBeenShown = false;
		// Use this for initialization
		void Start ()
		{	
				spriteRenderer = GetComponent<SpriteRenderer> ();
				spriteHeight = spriteRenderer.bounds.size.y;
				print ("TJAAAAA: " + spriteHeight);
				hasBeenShown = spriteRenderer.isVisible;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (spriteRenderer.isVisible) {
						hasBeenShown = true;
				}
			
		}
		void OnBecameVisible ()
		{
				hasBeenShown = true;
		}
		void OnBecameInvisible ()
		{
				if (hasBeenShown) {
						Move ();
						hasBeenShown = false;
				}
		}
	
		void Move ()
		{
				newTransform = otherTransform.position;
				newTransform.y = spriteHeight * 2 - (1f);
				print (newTransform.y);
				transform.position = newTransform;
				print ("MOVE " + transform.name + "OTHER POSY: " + otherTransform.position.y + "MY Y: " + transform.position.y);
		}
}
