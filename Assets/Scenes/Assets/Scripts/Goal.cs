using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

   [SerializeField] 
   private PlayerNumber goalPlayerNumber;
   [SerializeField] 
   private ScoreManager scoreManager;
   [SerializeField]
   private TriggerNumber myTrigger;

    public void AddPoint()
   {
      scoreManager.AddScore(goalPlayerNumber);
   }
}
