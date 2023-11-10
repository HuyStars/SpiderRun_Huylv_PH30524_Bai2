using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public GameObject player;
    public static float speed = 3.0f;

    // Update is called once per frame
    void Update()
    {
        // Di chuyển camera theo trục x
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        // Di chuyển nhân vật theo trục x
        player.transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
