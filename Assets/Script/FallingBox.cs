using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBox : MonoBehaviour
{
    public Vector2 speedMinMax;
    float speed;
    float visibleVerticalDistance;

    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
        visibleVerticalDistance = -Camera.main.orthographicSize - transform.localScale.y;
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if(transform.localPosition.y < visibleVerticalDistance)
        {
            Destroy(gameObject);
        }
    }
}
