using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PressAnyKeyTextControl : MonoBehaviour
{
    public float fadeSpeed = 1f; // ͸���ȱ仯���ٶ�
    public float minAlpha = 0.05f;  // ��С͸����
    public float maxAlpha = 1.0f;  // ���͸����
    private TextMeshProUGUI textMeshPro;
    private bool fadingOut = true;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        AlphaChange();
    }

    public void AlphaChange()
    {
        // ��ȡ��ǰ��ɫ
        Color currentColor = textMeshPro.color;

        // ����fadingOut����͸�������ӻ��Ǽ���
        if (fadingOut)
        {
            currentColor.a = Mathf.Lerp(currentColor.a, minAlpha, fadeSpeed * Time.deltaTime);

            // ���͸���Ƚӽ���Сֵ���л�Ϊ͸��������
            if (currentColor.a <= minAlpha + 0.1f)
            {
                fadingOut = false;
            }
        }
        else
        {
            currentColor.a = Mathf.Lerp(currentColor.a, maxAlpha, fadeSpeed * Time.deltaTime);

            // ���͸���Ƚӽ����ֵ���л�Ϊ͸���ȼ���
            if (currentColor.a >= maxAlpha - 0.1f)
            {
                fadingOut = true;
            }
        }

        // Ӧ���µ���ɫ
        textMeshPro.color = currentColor;
    }
}
