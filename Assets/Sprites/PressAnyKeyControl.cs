using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PressAnyKeyTextControl : MonoBehaviour
{
    public float fadeSpeed = 1f; // 透明度变化的速度
    public float minAlpha = 0.05f;  // 最小透明度
    public float maxAlpha = 1.0f;  // 最大透明度
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
        // 获取当前颜色
        Color currentColor = textMeshPro.color;

        // 根据fadingOut决定透明度增加还是减少
        if (fadingOut)
        {
            currentColor.a = Mathf.Lerp(currentColor.a, minAlpha, fadeSpeed * Time.deltaTime);

            // 如果透明度接近最小值，切换为透明度增加
            if (currentColor.a <= minAlpha + 0.1f)
            {
                fadingOut = false;
            }
        }
        else
        {
            currentColor.a = Mathf.Lerp(currentColor.a, maxAlpha, fadeSpeed * Time.deltaTime);

            // 如果透明度接近最大值，切换为透明度减少
            if (currentColor.a >= maxAlpha - 0.1f)
            {
                fadingOut = true;
            }
        }

        // 应用新的颜色
        textMeshPro.color = currentColor;
    }
}
