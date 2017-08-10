using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour {

    public float speed;
    public Vector3 resetPosition;
    public float zAxisReset;
    bool shouldUpdate;

	void LateUpdate () {
        if (!shouldUpdate)
        {
            return;
        }
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        if (transform.position.z <= zAxisReset)
        {
            transform.position = resetPosition;
        }
	}

    public void Init()
    {
        shouldUpdate = true;
    }

    public void Stop()
    {
        shouldUpdate = false;
    }
}
