using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    public float lifeTime = 15;
    public float heatPower = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Temperature>() != null)
        {
            Temperature temperature = other.GetComponent<Temperature>();

            if (temperature.temperatureCurrent < temperature.temperatureNormal)
            {
                temperature.temperatureCurrent += heatPower * Time.deltaTime;
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            gameObject.SetActive(false);
        }


    }
}
