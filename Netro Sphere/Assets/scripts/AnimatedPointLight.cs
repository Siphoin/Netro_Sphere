using UnityEngine;
using System.Collections;

public class AnimatedPointLight : MonoBehaviour
{
    bool status = false;
    private float animatedRangeValue = 0;
    private float originalRange = 0;
    private Light light;
    float t = 0;
    [SerializeField] float speedAnimation;
    // Use this for initialization
    void Start()
    {
        light = GetComponent<Light>();
        originalRange = light.range;
        animatedRangeValue = light.range - 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!status)
        {
            if (light.range != animatedRangeValue)
            {
                t += speedAnimation * Time.deltaTime;
                light.range = Mathf.Lerp(light.range, animatedRangeValue, t);
            }

            else
            {
                t = 0;
                status = true;
            }
        }

        else
        {
            if (light.range != originalRange)
            {
                t += speedAnimation * Time.deltaTime;
                light.range = Mathf.Lerp(light.range, originalRange, t);
            }

            else
            {
                t = 0;
                status = false;
            }
        }
    }
}
