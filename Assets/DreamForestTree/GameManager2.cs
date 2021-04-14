using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class GameManager2 : MonoBehaviour
{
    public Button GameStartBtn;  // 게임시작버튼


    void start()
    {
        GameStartBtn.transform.GetChild(0).GetComponent<Text>().text = "명상시작";
    }

    public void OnGameClick()
    {
        GameStartBtn.gameObject.SetActive(false);
        Debug.Log("button");
    }
}


