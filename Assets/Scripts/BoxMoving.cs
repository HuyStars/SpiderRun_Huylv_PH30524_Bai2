using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMoving : MonoBehaviour
{
    public float moveDistance = 1.0f; // Khoảng cách di chuyển
    public float moveSpeed = 1.0f; // Tốc độ di chuyển

    private Vector3 startPos;
    private Vector3 endPos;

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + new Vector3(0, moveDistance, 0);

        StartCoroutine(MoveUpDown());
    }

    IEnumerator MoveUpDown()
    {
        while (true)
        {
            yield return StartCoroutine(MoveToPosition(startPos, endPos, moveSpeed));
            yield return StartCoroutine(MoveToPosition(endPos, startPos, moveSpeed));
        }
    }

    IEnumerator MoveToPosition(Vector3 startPos, Vector3 endPos, float moveSpeed)
    {
        float t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime * moveSpeed;
            transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }
    }
}
