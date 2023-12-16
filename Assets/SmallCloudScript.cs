using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCloudScript : MonoBehaviour
{
    public float moveSpeed=5;
    public float deadZone=-70;
    public int multiplier;
    // Start is called before the first frame update
    void Start()
    {
     multiplier=Random.Range(1,3);   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+=Vector3.left*moveSpeed*multiplier*Time.deltaTime;
        if(transform.position.x<deadZone)Destroy(gameObject);
    }
}
