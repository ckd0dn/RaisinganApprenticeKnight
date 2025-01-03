using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    public Button button; // ��ư ����
    public Sprite pressedSprite; // ���� ������ �̹���
    public Sprite unpressedSprite; // �� ���� ������ �̹���

    public bool isPressed = false; // ��ư�� ���� ���¸� �����ϴ� ����
    private Image buttonImage; // ��ư�� �̹��� ������Ʈ

    public List<ToggleButton> buttonGroup;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    void Start()
    {
        // ��ư�� Image ������Ʈ�� ������
        buttonImage = button.GetComponent<Image>();

        // ��ư Ŭ�� �� ToggleImage �Լ��� ȣ��
        button.onClick.AddListener(ToggleImage);
    }

    void ToggleImage()
    {
        foreach (var button in buttonGroup)
        {
            button.isPressed = false;
            button.buttonImage.sprite = unpressedSprite;
        }

        // ��ư�� ���¸� ������Ŵ
        isPressed = !isPressed;

        // ���¿� ���� �̹��� ����
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
