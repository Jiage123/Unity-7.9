using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkill : MonoBehaviour
{
    Image imageSkill;
    bool isCool = false;
    float t = 5;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        imageSkill = GetComponent<Image>();
        imageSkill.fillAmount = 0;
        text = text.GetComponent<Text>();
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (isCool)
        {
            t -= Time.deltaTime;
            if (t >= 0)
            {
                imageSkill.fillAmount = t / 5;
                text.text = ((int)(t) + 1).ToString();
            }
            else
            {
                imageSkill.fillAmount = 0;
                t = 5;
                isCool = false;
                text.text = "";
            }
        }

        if (Input.GetMouseButtonDown(0) && !isCool)
        {
            imageSkill.fillAmount = 1;
            isCool = true;
        }
    }
}
