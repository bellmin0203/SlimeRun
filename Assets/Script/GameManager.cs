using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 게임 오버 상태를 표현하고, 게임 점수와 UI를 관리하는 게임 매니저
// 씬에는 단 하나의 게임 매니저만 존재할 수 있다.
public class GameManager : MonoBehaviour {
    public static GameManager instance; // 싱글톤을 할당할 전역 변수
    private GameObject DistancePlayingText;
    // private GameObject DistanceScoreText;

    public bool isGameover = false; // 게임 오버 상태
    public GameObject gameoverUI; // 게임 오버시 활성화 할 UI 게임 오브젝트
   
    public float speed = 1.0f; // 게임의 난이도를 위한 Speed 역할을 하는 변수
    public float meter; // 게임의 진행거리를 보여줄 변수
    public float level = 1.0f; //레벨업
    public float Gentime = 20.0f; //난이도용

    // 게임 시작과 동시에 싱글톤을 구성
    void Awake() {


        //화면 고정 설정.
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(1100  , 420, false);

        // 싱글톤 변수 instance가 비어있는가?
        if (instance == null)
        {
            // instance가 비어있다면(null) 그곳에 자기 자신을 할당
            instance = this;
        }
        else
        {
            // instance에 이미 다른 GameManager 오브젝트가 할당되어 있는 경우

            // 씬에 두개 이상의 GameManager 오브젝트가 존재한다는 의미.
            // 싱글톤 오브젝트는 하나만 존재해야 하므로 자신의 게임 오브젝트를 파괴
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    void Start(){
        this.DistancePlayingText = GameObject.Find("Distance Text");
        // this.DistanceScoreText = GameObject.Find("DistanceScore Text");

        //20미터 마다 레벨업
        StartCoroutine(levelUpSpeed());
        StartCoroutine(levelUpGen());
    }

    void Update() {
        // 게임 오버 상태에서 게임을 재시작할 수 있게 하는 처리
        if(isGameover && Input.GetMouseButtonDown(0)){
            // 게임오버 상태에서 마우스 왼쪽 버튼을 클릭하면 현재 씬 재시작
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        AddTime();

    }

    public void AddTime(){
        if(!isGameover){
            // 거리를 증가
            meter += Time.deltaTime * speed;
            this.DistancePlayingText.GetComponent<Text>().text = meter.ToString("F1")+"m";
        }
    }

    //난이도 증가
    IEnumerator levelUpSpeed()
    {
        if (!isGameover)
        {
            //5씩 증가
            level += 0.5f;
            Debug.Log("lvup! 1");
        }
        //20미터 마다
        yield return new WaitForSeconds(20);
        StartCoroutine(levelUpSpeed());
    }

    //난이도 증가
    IEnumerator levelUpGen()
    {
        if (!isGameover)
        {
            //5씩 증가
            Gentime -= 2 ;
            Debug.Log("lvup! 2");
        }
        //20미터 마다
        yield return new WaitForSeconds(40);
        StartCoroutine(levelUpGen());
    }

    // 점수를 증가시키는 메서드
    public void AddScore() {
        
    }

    // 플레이어 캐릭터가 사망시 게임 오버를 실행하는 메서드
    public void OnPlayerDead() {
        //this.DistanceScoreText.GetComponent<Text>().text = "You've reached " + meter.ToString("F1") + "m";
        isGameover = true;
        Time.timeScale = 0;
        gameoverUI.SetActive(true);
    }

    
}