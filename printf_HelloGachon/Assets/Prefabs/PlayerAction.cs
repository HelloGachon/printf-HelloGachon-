using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    float h; //수평(Horizontal), 플레이어의 x 좌표
    float v; //수직(Vertical), 플레이어의 y 좌표
    public float playerSpeed; //플레이어의 이동속도
    bool isHorizonMove;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //수평, 수직 이동 변수
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        //check horizontal move (수평이동인지 체크)
        if (hDown || vUp) {
            isHorizonMove = true;
        }
        else if (vDown || hUp) {
            isHorizonMove = false;
        }
    }

    void FixedUpdate() {
        //Move
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * playerSpeed;
    }
}