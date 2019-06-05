using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleArrange : MonoBehaviour
{
    public GameObject obstaclePrefab; // 생성할 장애물의 원본 프로팹
    public int count = 10; // 생성할 발판 수

    public float timeBetArrangeMin = 1.25f; // 다음 배치까지의 시간 간격 최솟값
    public float timeBetArrangeMax = 4.25f; // 다음 배치까지의 시간 간격 최댓값
    private float timeBetArrange; // 다음 배치까지의 시간 간격

    public float yPos = 2.33f; // 배치할 위치의 y 값
    private float xPos = 25f; // 배치할 위치의 x 값

    private GameObject[] obstacles; // 미리 생성한 장애물들
    private int currentIndex = 0; // 사용할 현재 순번의 장애물

    // 초반에 생성한 장애물을 화면 밖에 숨겨둘 위치
    private Vector2 poolPosition = new Vector2(-10, -10);
    private float lastArrangeTime; // 마지막 배치 시점

    void Start(){
        // 변수를 초기화하고 사용할 장애물을 미리 생성
        obstacles = new GameObject[count]; // count만큼의 공간을 가지는 새로운 장애물 배열 생성
        // count만큼 루프하면서 장애물 생성
        for(int i = 0; i< count; i++){
            // obstaclePrefab을 원본으로 새 장애물을 poolPosition 위치에 복제 생성
            // 생성된 장애물을 obstacle 배열에 할당
            obstacles[i] = Instantiate(obstaclePrefab, poolPosition, Quaternion.identity);
        }

        // 마지막 배치 시점 초기화
        lastArrangeTime = 0f;
        // 다음번 배치까지의 시간 간격을 0으로 초기화
        timeBetArrange = 0f;
    }

    void Update(){
        // 순서를 돌아가며 주기적으로 장애물 배치
        // 게임오버 상태에서는 동작하지 않음
        if(GameManager.instance.isGameover){
            return;
        }

        // 마지막 배치 시점에서 timeBetArrange 이상 시간이 흘렀다면
        if(Time.time >= lastArrangeTime + timeBetArrange){
            // 기록된 마지막 배치 시점을 현재 시점으로 갱신
            lastArrangeTime = Time.time;

            // 다음 배치까지의 시간 간격을 timeBetArrangeMin, timeBetArrangeMax 사이에서 랜덤 설정
            timeBetArrange = Random.Range(timeBetArrangeMin, timeBetArrangeMax);
            
            // 사용할 현재 순번의 장애물 게임 오브젝트를 비활성화하고 즉시 다시 활성화
            // 이때 장애물의 Obstacle 컴포넌트의 OnEnable 메서드가 실행됨
            obstacles[currentIndex].SetActive(false);
            obstacles[currentIndex].SetActive(true);

            // 현재 순번의 장애물을 화면 오른쪽에 재배치
            obstacles[currentIndex].transform.position = new Vector2(xPos, yPos);
            // 순번 넘기기
            currentIndex++;

            // 마지막 순번에 도달했다면 순번 리셋
            if(currentIndex >= count){
                currentIndex = 0;
            }
        }
    }
}
