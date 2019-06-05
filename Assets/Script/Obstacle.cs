using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject[] obstacles = new GameObject[3]; // 장애물 오브젝트들
    //public List<GameObject> ObstacleList = new List<GameObject>();

    private void OnEnable(){
        obstacles[0].SetActive(false);
        obstacles[1].SetActive(false);
        obstacles[2].SetActive(false);
        
        // 장애물의 수만큼 루프
        for(int i = 0; i < obstacles.Length; i++){
            // 현재 순번의 장애물을 1/3의 확률로 활성화
            if(Random.Range(0,3) == 0){
                obstacles[i].SetActive(true);
                break;
            }
            // else{
            //     obstacles[i].SetActive(false);
            // }
        }
    }
}
