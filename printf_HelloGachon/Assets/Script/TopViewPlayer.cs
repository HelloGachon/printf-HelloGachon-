using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopViewPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    float h;
    float v;
    Rigidbody2D rigid;
    void Awake(){
        rigid=GetComponent<Rigidbody2D>();
    }
    void Update(){
        h=Input.GetAxis("Horizontal");
        v=Input.GetAxis("Vertical");
    }
    void FixedUpdate() {
        rigid.velocity=new Vector2(h,v);
        
    }
}
