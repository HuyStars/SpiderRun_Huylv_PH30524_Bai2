using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Loop : MonoBehaviour
{
    public GameObject[] Box;
    public GameObject A_Zone;
    public GameObject B_Zone;

    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        MOVE();
    }

    public void MAKE()
    {
        B_Zone = A_Zone;
        int a = Random.Range(0,5);
        A_Zone = Instantiate(Box[a], new Vector3(10, -4, 0), transform.rotation) as GameObject;
    }

    public void MOVE()
    {
        A_Zone.transform.Translate(Vector3.left*speed*Time.deltaTime, Space.World);
        B_Zone.transform.Translate(Vector3.left*speed*Time.deltaTime, Space.World);
        if (A_Zone.transform.position.x <= -7)
        {
            DEATH();
        }
    }

    public void DEATH()
    {
        Destroy(B_Zone);
        MAKE();
    }
}
