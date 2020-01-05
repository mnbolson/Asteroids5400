using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    Camera cam;

    bool isWrappingX = false;
    bool isWrappingY = false;

    float screenWidth = Screen.width;
    float screenHeight = Screen.height;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        ScreenWrap();
    }

    private void ScreenWrap()
    {

        var isVisibile = this.GetComponent<SpriteRenderer>().isVisible;

        if (isVisibile)
        {
            isWrappingX = false;
            isWrappingY = false;
            return;
        }

        if (isWrappingX && isWrappingY)
        {
            return;
        }

        Vector3 PlayerPosition = cam.WorldToScreenPoint(this.transform.position);
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        if (!isWrappingX && (PlayerPosition.x < 0 || PlayerPosition.x > screenWidth))
        {
            this.transform.position = new Vector3(-this.transform.position.x, this.transform.position.y, this.transform.position.z);
            isWrappingX = true;

        }
        else if (!isWrappingY && (PlayerPosition.y < 0 || PlayerPosition.y > screenHeight))
        {
            this.transform.position = new Vector3(this.transform.position.x, -this.transform.position.y, this.transform.position.z);
            isWrappingY = true;

        }

        if (PlayerPosition.x < -screenWidth / 3 || PlayerPosition.x > screenWidth * 1.3)
        {
            Destroy(this.gameObject);
        }
        else if (PlayerPosition.y < -screenHeight / 3 || PlayerPosition.y > screenHeight * 1.3)
        {
            Destroy(this.gameObject);
        }
    }


}
