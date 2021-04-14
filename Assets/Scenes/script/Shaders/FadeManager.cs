using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance { set; get; }
    public GameObject gameManagerObj;
    GameManager gameManager;

    public Image fadeImage;
    private bool isInTransition;
    private float transition;
    private bool isShowing;
    private float duration;
    public static bool mapFinished = false;
    private bool gameStarted;

    private void Awake()
    {
        Instance = this;
        gameStarted = true;
        gameManager = gameManagerObj.GetComponent<GameManager>();
    }
    public void Fade(bool showing, float duration)
    {
        isShowing = showing;
        isInTransition = true;
        this.duration = duration;
        transition = (isShowing) ? 0 : 1;
    }

    private void Update() {

        if (!mapFinished && gameStarted) // fade in
        {
            Fade(false, 3.0f);
            gameStarted = false;
        }

        /*if (mapFinished) // fade out
        {
            Debug.Log("map finished");
            Fade(true, 1.25f);
        }
        */
        if (!isInTransition)
            return;

        transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
        fadeImage.color = Color.Lerp(new Color(1, 1, 1, 0), Color.white, transition);

        if (transition > 1 || transition < 0)
            isInTransition = false;
    }
}
