using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFlow : MonoBehaviour
{
    //[SerializeField]
    //float speed = 0f;
    //[SerializeField]
    //float height = 0f;
    //[SerializeField]
    //float distance = 0f;

    //private Vector3 initialPosition;
    //private float offset;

    //public AnimationCurve myCurve;

    //public Vector3 userDirection = Vector3.right;

    public bool inCurrent = false;
    public GameObject WaterCurrents;
    CharacterController controller;
    const float boostExhaust = 3.8f;
    [SerializeField]
    float boostTime = 0;
    public float minBoost = 0;
    public float maxBoost = 5;
    public float boostDecline = -2f;
    public float boostIncrease = 10f;

    public float coolDownTime = 5f;
    public float timer;

    //public bool startCou = false;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        //boostTime -= Time.deltaTime;
        //get the objects current position and put it in a variable so we can access it later with less code
        //Vector3 pos = transform.position;

        //offset = 1 - (Random.value * 2);
        //calculate what the new Y position will be
        //float newY = Mathf.Sin(Time.time * speed);

        //float newX = Mathf.Sin(Time.time * distance);
        //set the object's Y to the new calculated Y
        //transform.position = new Vector3(pos.x, newY, pos.z) * height;


        //transform.Translate(userDirection * speed * Time.deltaTime);

        //--------------------------------------------------------------------------------------------------------------------------------------------
        if (inCurrent)
        {
            //Allows DD to move inside of the water current collider
            controller.SimpleMove(WaterCurrents.GetComponent<WaterCurrent>().direction * WaterCurrents.GetComponent<WaterCurrent>().strength);
        }
        timer -= 1f * Time.deltaTime;
        if (timer <= 0f)
        {
            WaterCurrents.SetActive(true);
            //inCurrent = true;
            timer = 0f;
        }
    }

    private void FixedUpdate()
    {
        //constantly decreases the boostTime number until it reaches minBoost
        //Also stops the number from exceeding the maxBoost cap
        /*if (inCurrent)
        {
            controller.SimpleMove(WaterCurrents.GetComponent<WaterCurrent>().direction * WaterCurrents.GetComponent<WaterCurrent>().strength);
        }*/

        /*if (Input.GetKey(KeyCode.Q))
        {
            StartCoroutine(Boost());
        }
        else
        {
            StopCoroutine(Boost());
        }*/
        //^^Everything above boostTime is a failure in FixedUpdate :(
        //----------------------------------------------------------------------------------------------------

        //constantly decreases the boostTime number until it reaches minBoost
        //Also stops the number from exceeding the maxBoost cap
        //boostTime = Mathf.Clamp(boostTime + boostDecline * Time.deltaTime, minBoost, maxBoost);



        if ((Input.GetKeyDown(KeyCode.Q)) && (timer == 0f))
        {
            WaterCurrents.SetActive(false);
            inCurrent = false;
            timer += coolDownTime;
            //increases boostTime in the inspector whenever player holds Q

            //Nate made this block comment
            /*boostTime += boostIncrease * Time.deltaTime;
            //untoggles the watercurrent game object in the hierarchy
            //gives off the illusion of a swim boost
            WaterCurrents.SetActive(false);
            inCurrent = false;

            if (boostTime > boostExhaust)
            {
                //whenever the boostTime number is greater than whatever the boostExhaust is set to, the watercurrent gameobject toggles back on
                WaterCurrents.SetActive(true);
                inCurrent = true;
            }
            if (boostTime == minBoost)
            {
                //This isn't working unfortunately
                //Tried to have it so that whenever the boostTime equals the minBoost would be the same thing as the above line
                WaterCurrents.SetActive(true);
                inCurrent = true;
            }
        }

        if (boostTime > boostExhaust)
        {
            //whenever the boostTime number is greater than whatever the boostExhaust is set to, the watercurrent gameobject toggles back on
            WaterCurrents.SetActive(true);
            inCurrent = true;
            */
        }
        
        
    }

    /*IEnumerator Boost()
    {
            boostTime += Time.deltaTime;

            WaterCurrents.SetActive(false);
            inCurrent = false;

            if (boostTime > boostExhaust)
            {
                WaterCurrents.SetActive(true);
            }

            yield return new WaitForSeconds(2f);
    
    // I HATE COROUNTINES :)
    }*/
    
    private void OnTriggerEnter(Collider coll)
    {
        //The nucleus of the water current script
        if (coll.gameObject.tag == "current")
        {
            WaterCurrents = coll.gameObject;
            inCurrent = true;
        }

    }

    private void OnTriggerStay(Collider coll)
    {
        //The nucleus of the water current script
        if (coll.gameObject.tag == "current")
        {
            WaterCurrents = coll.gameObject;
            inCurrent = true;
        }

    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "current")
        {
            inCurrent = false;
        }
    }
}
