using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum TriggerNumber
{
    TriggerWall,
    TriggerPaddle,
    TriggerGoal,
    TriggerAddBall
}

public enum SenceNumber
{
    Sence1,
    Sence2,
    Sence3

}



public class Ball : MonoBehaviour
{
    [SerializeField] 
    private float startSpeed = 13f;
    [SerializeField] 
    private float limitSpeed = 30f;
    [SerializeField] 
    private float speedIncrease = 0.25f;
    [SerializeField] 
    private float startScale = 4f;
    private float currentScale;

    [SerializeField]
    private SenceNumber mySence;

    private TriggerNumber myTrigger;

    private float currentSpeed;
    private Vector2 currentDir;

    [SerializeField]
    private Vector3 startPos;

    private bool isReset = false;

    [SerializeField]
    private AudioSource AudioSource;
    [SerializeField]
    private AudioClip[] AudioClip;
    //[SerializeField]
    //private GameObject particalFire;

    [SerializeField]
    private ParticleSystem Particle;

    //[SerializeField]
    //private Animator Anim;
    


    private void Start()
    {
        currentSpeed = startSpeed;
        transform.position = startPos;
        currentDir = Random.insideUnitCircle.normalized;
        AudioSource = GetComponent<AudioSource>();
        Particle = GetComponent<ParticleSystem>();
        //Anim = GetComponent<Animator>();


    }

    private void Update()
    {
        if (isReset)
        {
            return;
        }

        Vector2 moveDir = currentDir * currentSpeed * Time.deltaTime;
        transform.Translate(new Vector3(moveDir.x, moveDir.y, 0f));
    }

    private void OnTriggerEnter(Collider other)
    {

        //switch (myTrigger)
        //{
        //    case TriggerNumber.TriggerWall:
        //        currentDir.y *= -1;
        //        break;
        //    case TriggerNumber.TriggerPaddle:
        //        currentDir.x *= -1;
        //        break;
        //    case TriggerNumber.TriggerGoal:
        //        StartCoroutine(ResetGame());
        //        other.gameObject.GetComponent<Goal>().AddPoint();
        //        break;
        //    case TriggerNumber.TriggerAddBall:
        //        other.gameObject.GetComponent<AddBall>().AddBallToGame();
        //        Destroy(other.gameObject);
        //        break;

        //}
        if (other.gameObject.CompareTag("Wall"))
        {
            currentDir.y *= -1;
            AudioSource.clip = AudioClip[0];
            //particalFire.gameObject.SetActive(false);
            AudioSource.Play();
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            currentDir.x *= -1;
            AudioSource.clip = AudioClip[0];
            AudioSource.Play();
            if (mySence == SenceNumber.Sence2)
            {
                currentScale++;
                other.GetComponent<Transform>().localScale = new Vector3(1, currentScale, 1);
            }
            
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
            StartCoroutine(ResetGame());
            //particalFire.gameObject.SetActive(true);
            other.GetComponent<Goal>().AddPoint();
            AudioSource.clip = AudioClip[1];
            AudioSource.Play();
            Particle.Play();
            //Anim.SetBool("myBool", true);
            //gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("AddBall"))
        {
            other.GetComponent<AddBall>().AddBallToGame();
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("ballTran"))
        {
            transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            Destroy(other.gameObject);

        }
        
        else if (other.gameObject.CompareTag("BallGrow"))
        {
            transform.localScale = new Vector3(2, 2, 2);
            Destroy(other.gameObject);

        }
        
        else if (other.gameObject.CompareTag("ballSpeed"))
        {
            startSpeed = 25;
            Destroy(other.gameObject);
        }



        currentSpeed += speedIncrease;
        currentSpeed = Mathf.Clamp(currentSpeed, startSpeed, limitSpeed);

    }
    
    private IEnumerator ResetGame()
    {
        isReset = true;
        currentSpeed = 0;
        yield return new WaitForSeconds(3);
        Start();
        isReset = false;
    }
}
