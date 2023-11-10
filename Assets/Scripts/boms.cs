using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class boms : MonoBehaviour
{
    
    
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetMouseButtonDown(1))
    //     {
    //         anim.SetBool("checkno", true);
    //         // Xóa object bom và hiệu ứng nổ sau một khoảng thời gian ngắn
    //     }
    // }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("checkno", true);
        }
    }
}