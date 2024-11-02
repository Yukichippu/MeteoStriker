using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w : MonoBehaviour
{
    public float CameraSpeed = 5f; // ˆÚ“®‘¬“x

    void Update()
    {
        // YŽ²‚Ìƒvƒ‰ƒX•ûŒü‚ÉˆÚ“®
        Vector3 movement = new Vector3(0, CameraSpeed * Time.deltaTime, 0);
        transform.position += movement;
    }
}
