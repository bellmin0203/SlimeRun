using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEvent : MonoBehaviour
{
    private bool pauseOn = false;
    public GameObject pauseUI; // 일시 정지시 활성화 할 UI

    void Awake(){
        pauseUI = GameObject.Find("Canvas").transform.Find("PausePanel").gameObject;
    }
    public void ActivePauseBtn(){
        // 일시정지 버튼을 눌렀을 때 처리
        if(!pauseOn){
            Time.timeScale = 0; // 시간 흐름 비율 0으로, 1이면 (1배속), 1.5이면 (1.5배속)
            pauseUI.SetActive(true);
        }
        else{
            // 일시정지 중이면 해제.
            Time.timeScale = 1.0f;
            pauseUI.SetActive(false);
        }
        pauseOn = !pauseOn;
    }

    public void RetryBtn(){
        Debug.Log("게임 재시작");
        Time.timeScale = 1.0f; // 시간 초기상태로 변경
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재 씬 다시 로드
    }

    public void ExitBtn(){
        Debug.Log("게임 종료");
        Application.Quit(); //게임 종료 
    }
}
