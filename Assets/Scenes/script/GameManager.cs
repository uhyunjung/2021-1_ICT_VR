using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    float PlayTime;               // 시간 측정
    public Button NavStartBtn;    // 길 안내 시작 버튼
    public Button GameStartBtn;   // 본게임 시작 버튼
    public Button HintBtn;        // 힌트 버튼
    public Text PlayTimeText;     // UI에 올릴 점수 unity에서 할당해줘야함 
    public Text TotalTimeText;    // 최종 시간
    public Text ArrowText;        // 화살표
    public bool FirstCheck, SecondCheck;  // 길 안내 시작, 본게임 시작
    public Vector3 startPoint;
    public Vector3 goalPoint;
    public Quaternion startRotation;
    public GameObject[] Obstacles;

    public int numHint; //hint 사용한 횟수

    void Start()
    {
        PlayTime = 0;
        PlayTimeText.enabled = false;
        TotalTimeText.enabled = false;
        ArrowText.enabled = false;
        NavStartBtn.transform.GetChild(0).GetComponent<Text>().text = "길안내 시작";
        GameStartBtn.transform.GetChild(0).GetComponent<Text>().text = "게임 시작";
        GameStartBtn.gameObject.SetActive(false);

        for (int i = 0; i < 5; i++)
        {
            int value = Random.Range(0, 2);
            if (value == 1)
            {
                Obstacles[i].GetComponent<NavMeshObstacle>().enabled = true;
            }
            else
            {
                Obstacles[i].GetComponent<NavMeshObstacle>().enabled = false;
            }
        }
    }

    void Update()
    {
        if (SecondCheck)
        {
            PlayTime += Time.deltaTime;
            PlayTimeUpdate((int)PlayTime);
        }
    }

    public void PlayTimeUpdate(int currentTime)
    {
        int hour = 0, minute = 0, second = 0;

        if (currentTime / 3600 != 0)
        {
            hour = (int)currentTime / 3600;
            currentTime %= 3600;
        }

        if (currentTime / 60 != 0)
        {
            minute = (int)currentTime / 60;
            currentTime %= 60;
        }

        second = (int)currentTime;

        if (hour == 0)
        {
            PlayTimeText.text = string.Format("{0:00} : {1:00}", minute, second);
        }
        else
        {
            PlayTimeText.text = string.Format("{0:00} : {1:00} : {2:00}", hour, minute, second);
        }
        Debug.Log(string.Format("{0:00} : {1:00} : {2:00}", hour, minute, second));
    }

    public void checkHint()
    {
        numHint++;
        //show hint
    }

    public void showHint()
    {
        StartCoroutine(startHint());
    }

    IEnumerator startHint()
    {
        GameObject.Find("HintBtn").GetComponent<Button>().enabled = false;
        GameObject.Find("player(Clone)").transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(5);

        GameObject.Find("HintBtn").GetComponent<Button>().enabled = true;
        GameObject.Find("player(Clone)").transform.GetChild(1).gameObject.SetActive(false);
    }

    // 길 안내 시작 버튼 클릭
    public void OnNavClick()
    {
        NavStartBtn.gameObject.SetActive(false);
        ArrowText.enabled = true;

        FirstCheck = true;
        Debug.Log("길 안내 시작");

        startRotation = GameObject.FindGameObjectWithTag("Player").transform.rotation;
        GameObject.FindGameObjectWithTag("Player").GetComponent<NavPlayer>().ShowRoad(goalPoint);
    }

    // 본게임 시작 버튼 클릭
    public void OnGameClick()
    {
        numHint = 0;
        GameStartBtn.gameObject.SetActive(false);
        GameObject.Find("HintBtnParent").transform.GetChild(0).gameObject.SetActive(true);
        PlayTimeText.enabled = true;
        ArrowText.enabled = false;

        Debug.Log("게임 시작");
        SecondCheck = true;

        GameObject.FindGameObjectWithTag("Player").GetComponent<NavPlayer>().agent.isStopped = true;  // Navigation 종료
        GameObject.FindGameObjectWithTag("Player").transform.rotation = startRotation;                // 방향 같게
        GameObject.FindGameObjectWithTag("Player").transform.position = startPoint;                   // 시작 위치 이동

        GameObject.FindGameObjectWithTag("Player").GetComponent<MovePlayer>().enabled = true;
    }
}