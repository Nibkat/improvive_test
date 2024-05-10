using UnityEngine;

public class DebugInteract : Interactable {
	protected override void OnInteract() {
		Debug.Log("Interacted with object");
	}
}