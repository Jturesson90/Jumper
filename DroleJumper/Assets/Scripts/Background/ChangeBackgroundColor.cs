using UnityEngine;
using System.Collections;


[RequireComponent (typeof(SpriteRenderer))]
public class ChangeBackgroundColor : MonoBehaviour
{		
		public Color[] lerpedColors;
		public Color lerpedColor = Color.white;
		public float colorChangeSpeed = 1f;
		private SpriteRenderer spriteRenderer;
		private int currentColor = 0;
		// Use this for initialization
		void Awake ()
		{
				
				spriteRenderer = GetComponent<SpriteRenderer> ();
		}
		void Start ()
		{	
				print ("COLOR: " + lerpedColor);
		}
	
		// Update is called once per frame
		void Update ()
		{	
				if (Input.GetKeyDown (KeyCode.A)) {
						currentColor++;
						if (currentColor >= lerpedColors.Length) {
								currentColor = 0;
						}
				}
				spriteRenderer.color = Color.Lerp (spriteRenderer.color, lerpedColors [currentColor], colorChangeSpeed * Time.deltaTime);

				//spriteRenderer.material.color = Color.Lerp (spriteRenderer.material.color, lerpedColors [currentColor], colorChangeSpeed * Time.deltaTime);
		}
		void FixedUpdate ()
		{
				
		}
}
