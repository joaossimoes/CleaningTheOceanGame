using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Paddle : MonoBehaviour
{
    //configuration paramaters

    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] public float ScreenWidthInUnits;
    [SerializeField] float boatSpeed;
    [SerializeField] Canvas resartCanvas;

    //cached references
    GameStatus gameStatus;
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
        //Canvas resartCanvas = gameObject.GetComponent(typeof(Canvas)) as Canvas;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseSystem.isPaused)
        {
            var targetPos = new Vector2 (GetXPos(), transform.position.y);
            getDirection(transform.position, targetPos);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, boatSpeed);
        }
        
    }

    private void getDirection(Vector2 initialPos , Vector2 targetPos)
    {
        if (Mathf.Abs(initialPos.x - targetPos.x) < Mathf.Epsilon){
            return;
        }
        else{
            transform.localScale = new Vector2 (Mathf.Sign(initialPos.x - targetPos.x) * 2.4f, 1.6f);
//            transform.GetChild(0).localScale = new Vector2 (Mathf.Sign(initialPos.x - targetPos.x) * 0.4216092f, 0.5991819f);
        }
        
    }
    private float GetXPos()
    {
        if (gameStatus.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
        }
    }

    public void DisableCanvas()
    {
        resartCanvas.enabled = false;
    }

    public void EnableCanvas()
    {
        resartCanvas.enabled = true;
    }
}
