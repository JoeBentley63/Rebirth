using UnityEngine;
using System.Collections;

public class ExplorerCameraMonitor : MonoBehaviour {
	
	public SectionController sectionController;
	void OnTriggerEnter(Collider collider){
		string tag = collider.tag;
		if (tag.Contains ("Section")) {
			string numberAsString = tag.Split (':') [1];
			int number = int.Parse (numberAsString);
			sectionController.MoveCameraToZone(number);
		}
	}
}
