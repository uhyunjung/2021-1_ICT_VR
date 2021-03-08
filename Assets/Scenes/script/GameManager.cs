using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int playTime;  
    public Text playTimeText;  //UI에 올릴 점수 unity에서 할당해줘야함

    public int numHint; //hint 사용한 횟수

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void playTimeUpdate()
    {
        playTimeText.text = playTime.ToString();

    }

    public void checkHint()
    {
        numHint++;
        //show hint
    }
}
