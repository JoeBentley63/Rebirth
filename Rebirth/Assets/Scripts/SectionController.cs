using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SectionController : MonoBehaviour {
	public Vector3[] cameraPositions;
	// Use this for initialization
	void Start () {
		MoveCameraToZone (0);
	}

	public void MoveCameraToZone(int zone){
		if(cameraPositions.Length >= zone){
			iTween.MoveTo(this.gameObject,cameraPositions[zone],1);
		}
	}
}
