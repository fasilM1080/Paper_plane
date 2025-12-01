using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public Slider Slider;
    private bool isHolding = false;
    private float VerticalInput;
    private float HorizontalInput;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        TouchDetector();
        SetInput();
    }

    private void TouchDetector()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x > Screen.width * 0.5f)
                {
                    isHolding = true;
                }
            }

            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isHolding = false;
            }
        }
    }

    private void SetInput()
    {
        //Vertical Input
        float touchvalue = isHolding ? 1f : -0.3f;
        VerticalInput = Mathf.Lerp(VerticalInput, touchvalue, Time.deltaTime * 5);
        //Horizontal Input
        HorizontalInput = Slider.value;
    }
    public float Vertical()
    {
        return VerticalInput;
    }
    public float Horizontal()
    {
        return HorizontalInput;
    }
}
