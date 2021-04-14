using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SelectScene : MonoBehaviour
{
    // 게임 버튼, 타이머, 힌트 버튼 활성화
    public void Start()
    {
        if(GameObject.Find("NavBtn")!=null)
        {
            GameObject.Find("NavBtn").SetActive(false);
            GameObject.Find("HintBtn").SetActive(false);
            GameObject.Find("HintCount").SetActive(false);
        }
    }

    public void NavOnClick()
    {
        if (GameObject.Find("HintCount") != null)
        {
            GameObject.Find("HintBtn").SetActive(false);
        }
        if (GameObject.Find("HintCount") != null)
        {
            GameObject.Find("HintCount").SetActive(false);
        }

        GameObject.Find("MedBtn").SetActive(false);
        GameObject.Find("RoadBtn").SetActive(false);
    }

    public void MedOnClick()  // 명상 게임 이동
    {
        SceneManager.LoadScene("DemoScene");
    }
}
