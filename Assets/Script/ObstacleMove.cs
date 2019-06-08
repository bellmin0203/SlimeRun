using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float speed = 3f; // 이동 속도
    //난이도용
    float lvspeed = 1.0f;
    GameManager gm;
    //GameObject player;
    void Start()
    {
        //this.player = GameObject.Find("Player");
        //난이도용
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        // 초당 speed의 속도로 왼쪽으로 평행이동
        transform.Translate(Vector3.left * speed * Time.deltaTime * lvspeed);
        // 레벨링 디자인
        lvspeed = gm.level;



            // speed *= 1.5f;

        /*
         if (transform.position.x < -9.0f)
        {
             Destroy(gameObject);
        }
        */
        //충돌판정
        // Vector2 p1 = transform.position;
        // Vector2 p2 = this.player.transform.position;
        // Vector2 dir = p1 - p2;
        // float d = dir.magnitude;
        // float r1 = 0.4f; //가시반경
        // float r2 = 0.5f; //플레이어 반경

        // if (d < r1 + r2)
        // {
        //     Destroy(gameObject);

        //     Debug.Log("충돌");
        //     //다른 스크립트에서 불러오는 방법
        //     GameObject director = GameObject.Find("GameDirector");
        //     //이 부분 다른 곳에서 불러와서 삭제
        //     //중요하다 합니다!!
        // }
    }
}
