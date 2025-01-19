using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    public Button button; // 버튼 참조
    public Sprite pressedSprite; // 눌린 상태의 이미지
    public Sprite unpressedSprite; // 안 눌린 상태의 이미지

    public bool isPressed = false; // 버튼이 눌린 상태를 추적하는 변수
    private Image buttonImage; // 버튼의 이미지 컴포넌트

    public List<ToggleButton> buttonGroup;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    void Start()
    {
        // 버튼의 Image 컴포넌트를 가져옴
        buttonImage = button.GetComponent<Image>();

        // 버튼 클릭 시 ToggleImage 함수를 호출
        button.onClick.AddListener(ToggleImage);
    }

    void ToggleImage()
    {
        foreach (var button in buttonGroup)
        {
            button.isPressed = false;
            button.buttonImage.sprite = unpressedSprite;
        }

        // 버튼의 상태를 반전시킴
        isPressed = !isPressed;

        // 상태에 따라 이미지 변경
        if (isPressed)
        {
            buttonImage.sprite = pressedSprite;
        }
        else
        {
            buttonImage.sprite = unpressedSprite;
        }

      
    }
}
