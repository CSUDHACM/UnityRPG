using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Vector3 offset;
    public Transform lookAt;

	void LateUpdate() {
        transform.position = lookAt.position + offset;
	}
}
