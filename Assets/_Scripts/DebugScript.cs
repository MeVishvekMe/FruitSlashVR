using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DebugScript : MonoBehaviour {
    public void OnHoverEntered(HoverEnterEventArgs args) {
        Debug.Log($"Hovered over: {args.interactableObject.transform.name}");
    }
    public void OnHoverExited(HoverExitEventArgs args) {
        Debug.Log($"Stopped hovering: {args.interactableObject.transform.name}");
    }
}
