using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WaterForce : MonoBehaviour
{
    public bool backwards = false;
    [SerializeField]
    private float pullSpeed = 0;

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.name == "Swampy Water")
            backwards = true;

        if (gameObject.GetComponent<Rigidbody>())
        {
            gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 10000f * Time.deltaTime);
        }
    }

    private void Update()
    {
        if (backwards)
        {
            //Acceleration of the object falling
            //The higher the number the slower the object falls
            pullSpeed += Time.deltaTime/9770;
            //changing the position of the object falling(down)
            transform.position = new Vector3(transform.position.x - pullSpeed, transform.position.y, transform.position.z);
        }
    }
}
