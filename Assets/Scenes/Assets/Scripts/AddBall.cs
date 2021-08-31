using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBall : MonoBehaviour
{
    [SerializeField] private GameObject ball;

    public void AddBallToGame()
    {
        Instantiate(ball);
    }
}
