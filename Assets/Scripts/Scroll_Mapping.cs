using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll_Mapping : MonoBehaviour
{
    // Update is called once per frame
    public float speed = 5f;
    void Update()
    {
        // Tính toán vị trí mới của đối tượng theo trục x
        float newPosition = Mathf.Repeat(Time.time * speed, 20); // 20 là chiều dài của nền

        // Di chuyển đối tượng đến vị trí mới
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
    }
}
