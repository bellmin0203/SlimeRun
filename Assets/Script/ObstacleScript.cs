using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    //프리팹을 넣어줄 공개변수들
    public Transform obstacle;
    
    private bool crash = false; // 플레이어 캐릭터가 닿았는가

    float timer = 0; //누적시간을 저장할 변수
    float speed = 0.3f; //시간
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //시간을 누적시킴
        timer += Time.deltaTime;
        float randTime = Random.Range(5, 20);
        //랜덤 시간이 지나면 나옴
        if (timer > randTime)
        {
            //적 생성
            CreateEnemy();
            
            //누적시간 초기화
            timer = 0;
        }

    }
    
    void CreateEnemy()
    {
        float temp = Random.Range(1.0f, 5.0f);
        float obstaclepos = transform.position.x * temp;
        Vector3 temp2 = new Vector3(obstaclepos, transform.position.y, transform.position.z);
        Instantiate(obstacle, temp2, Quaternion.identity);
    }
    
}
