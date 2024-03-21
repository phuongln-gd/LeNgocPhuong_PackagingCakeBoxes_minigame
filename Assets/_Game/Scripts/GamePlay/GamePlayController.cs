using UnityEngine;
using System.Collections.Generic;
using System;

public class GamePlayController : MonoBehaviour
{
    private Vector2 touchStartPos;
    private Vector2 touchEndPos;

    public static Action<String> slide;

    private void Update()
    {
        if (GameManager.IsState(GameState.GamePlay))
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    touchStartPos = touch.position;
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    touchEndPos = touch.position;

                    Vector2 swipeDirection = touchEndPos - touchStartPos;

                    if (swipeDirection.magnitude > 50)
                    {
                        if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
                        {
                            if (swipeDirection.x > 0)
                            {
                                slide("right");
                            }
                            else
                            {
                                slide("left");
                            }
                        }
                        else
                        {
                            if (swipeDirection.y > 0)
                            {
                                slide("up");
                            }
                            else
                            {
                                slide("down");
                            }
                        }
                    }
                }
            }
        }
    }
}
