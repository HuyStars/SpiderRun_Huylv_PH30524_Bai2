using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public float ScrollSpeed = 0.5f;
    private float Offset;
    private Material mat;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Offset += Time.deltaTime * ScrollSpeed;
        mat.mainTextureOffset = new Vector2(Offset, 0.01f);
    }
}
