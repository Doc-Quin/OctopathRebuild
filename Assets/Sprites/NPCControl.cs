using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class NPCControl : MonoBehaviour
{
    public PlayerController playerdata;
    private Animator Ani;
    public Transform player;
    private ControlLoading CL;
    public float distance;
    private Rigidbody rb;
    public Canvas CUI;
    public bool Diaopen = false;

    public TextMeshProUGUI textMeshProUGUI;
    public string TextContent;
    public string FilePath;
    private string[] lines;
    public int linecount;

    // Start is called before the first frame update
    void Start()
    {
        //�������׼��
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.isKinematic = true;
        playerdata = GameObject.Find("player").GetComponent<PlayerController>();
        Ani = GetComponent<Animator>();
        CL = GameObject.Find("Sun").GetComponent<ControlLoading>();

        //�Ի����׼��
        CUI = GetComponentInChildren<Canvas>();
        CUI.enabled = Diaopen;
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
        SourceLoading();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 positionA = player.transform.position;
        Vector3 positionB = transform.position;
        distance = Vector3.Distance(positionA, positionB);
        CUI.enabled = Diaopen;

        if (!Input.anyKey && distance > 1)
        {
            Diaopen = false;
        }

        if (Input.GetKeyDown(CL.GetKeyCodeForValue(5)) && distance <= 1)
        { 
            //�任��������
            switch (playerdata.Dir)
            {
                case 0:
                    Ani.Play("Standback");
                    break;
                case 1:
                    Ani.Play("Standface");
                    break;
                case -1:
                    Ani.Play("Standright");
                    break;
                case -2:
                    Ani.Play("Standleft");
                    break;
            }

            Diaopen = true;
        }

        //��ʾ�ı�

        if (Input.GetKeyDown(CL.GetKeyCodeForValue(5)) && linecount < lines.Length && distance <= 1)
        {
            textMeshProUGUI.text = lines[linecount];
            linecount++;
        }

        if (linecount == lines.Length)
        {
            Diaopen = false;
            linecount = 0;
        }
    }

    void SourceLoading()
    {
        TextContent = Resources.Load<TextAsset>(FilePath).text;//��ȡ�������������ݣ���������ı�������ȡ�����ı�
        lines = TextContent.Split('\n');
    }
}
