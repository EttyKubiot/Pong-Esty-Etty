using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PaddleFor : MonoBehaviour
{
    

   
        [SerializeField]
        private float moveSpeed = 10;
        [SerializeField]
        private float movePositiveRange = 22.5f;
        [SerializeField]
        private float moveNegativeRange = -5f;

        [SerializeField]
        private float xNegativeRange = 10f;
        [SerializeField]
        private float xPositiveRange = 24f;

        [SerializeField]
        private PlayerNumber myPaddle;
        [SerializeField]
        private TriggerNumber myTrigger;
        [SerializeField]
        private Counter myCounter;

        private SenceNumber mySence;

        private bool acceptsInput = true;

        float horizontalInput = 0;
        float verticalInput = 0;

        public enum Counter
        {
            isCounter,
            noCounter
        }



        // Update is called once per frame
        void Update()
        {
            if (!acceptsInput)
            {
                return;
            }

            //float input = 0;

            if (myPaddle == PlayerNumber.Player1)
            {
                verticalInput = Input.GetAxis("Vertical");

                
                
                    horizontalInput = Input.GetAxis("Horizontal");
                    playerX();
                
            }



            if (myPaddle == PlayerNumber.Player2)
            {
                verticalInput = Input.GetAxis("Vertical2");
                
                
                    horizontalInput = Input.GetAxis("Horizontal2");
                    playerX();
                
            }



            Vector3 newPosition = transform.position;

            newPosition.y += verticalInput * moveSpeed * Time.deltaTime;

            newPosition.y = Mathf.Clamp(newPosition.y, moveNegativeRange, movePositiveRange);

            transform.position = newPosition;
        }

        private void playerX()
        {
            Vector3 newPosition1 = transform.position;
            newPosition1.x += horizontalInput * moveSpeed * Time.deltaTime;
            newPosition1.x = Mathf.Clamp(newPosition1.x, xNegativeRange, xPositiveRange);
            transform.position = newPosition1;

        }
    }


