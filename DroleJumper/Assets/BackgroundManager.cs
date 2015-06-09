using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour
{
		public Transform followTransform;
		public float offsetFollow = 1f;
		private Vector3 newTransform;
		private Component[] childRenderers;
		// Use this for initialization
		void Awake ()
		{
				childRenderers = gameObject.GetComponentsInChildren<SpriteRenderer> ();
		}
		void Start ()
		{
			
		}
	
		// Update is called once per frame
		void Update ()
		{
			
		}
		bool IsVisible ()
		{
				foreach (SpriteRenderer rend in childRenderers) {
						if (rend.isVisible) {
								return true;
						}
				}
				return false;
		}
}
