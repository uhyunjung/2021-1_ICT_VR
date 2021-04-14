using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishingZone : MonoBehaviour
{
    GameManager gameManager;
    
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")  //player와 FinishingZone이 충돌하면 게임 끝
        {
            Debug.Log("collision");

            FadeManager.mapFinished = true;         //맵 종료
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

            if (gameManager.FirstCheck)         // 길 안내 종료
            {
                gameManager.FirstCheck = false;
                GameObject.Find("player(Clone)").transform.GetChild(1).gameObject.SetActive(false);
                
                gameManager.GameStartBtn.gameObject.SetActive(true);
                gameManager.PlayTimeText.gameObject.SetActive(true);
                
            }
            else if(gameManager.SecondCheck)   // 게임 종료
            {
                gameManager.SecondCheck = false;
                
                gameManager.TotalTimeText.text = "총 "+gameManager.PlayTimeText.text;
                gameManager.TotalTimeText.enabled = true;
                GameObject.Find("ParentBtn").transform.GetChild(2).GetComponent<Text>().text = "총 힌트 사용 횟수는 "+gameManager.numHint+"회입니다.";

                GameObject.Find("ParentBtn").transform.GetChild(1).gameObject.SetActive(true);  // 메인ui 활성화
                GameObject.Find("ParentBtn").transform.GetChild(2).gameObject.SetActive(true);
            }
        }
    }

    /*IEnumerator FadeInOut()
    {
        float a = 1;
        .color = new Vector4(1, 1, 1, a);
        yield return new WaitForSeconds(0.3f);

        while (a >= 0)
        {
            FadeInOutImg.color = new Vector4(1, 1, 1, a);
            a -= 0.0f;
            yield return null;
        }
    }*/
}
