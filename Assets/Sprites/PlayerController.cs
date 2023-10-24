using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed;// �ƶ��ٶ�
    private float friction; // Ħ����
    public int Dir = 0;

    private Rigidbody rb;

    public Animator Ani;

    private ControlLoading CL;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Ani = GetComponent<Animator>();
        // ���ø���Ķ�����ת����ֹ������ƶ�ʱ��б
        rb.freezeRotation = true;
        rb.drag = friction;
        CL = GameObject.Find("Sun").GetComponent<ControlLoading>();
        moveSpeed = CL.moveSpeed;
        friction = CL.friction;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �����ƶ�����
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        rb.transform.position += moveDirection * moveSpeed * Time.deltaTime;

        //�����ж�
        if (!Input.anyKey)
        {
            Ani.SetBool("IfMoveKey", false);
            Ani.SetBool("Ifrun", false);
        }
        Ani.SetInteger("FaceDir", Dir);

        if (Input.GetKeyDown(CL.GetKeyCodeForValue(1)))
        {
            Ani.SetBool("IfMoveKey", true);
            Ani.SetInteger("FaceDir", 1);
            Dir = 1;
        }
        if (Input.GetKeyDown(CL.GetKeyCodeForValue(2)))
        {
            Ani.SetBool("IfMoveKey", true);
            Ani.SetInteger("FaceDir", -1);
            Dir = -1;
        }
        if (Input.GetKeyDown(CL.GetKeyCodeForValue(3)))
        {
            Ani.SetBool("IfMoveKey", true);
            Ani.SetInteger("FaceDir", 0);
            Dir = 0;
        }
        if (Input.GetKeyDown(CL.GetKeyCodeForValue(4)))
        {
            Ani.SetBool("IfMoveKey", true);
            Ani.SetInteger("FaceDir", -2);
            Dir = -2;
        }
        if (Input.GetKeyDown(CL.GetKeyCodeForValue(7)))
        {
            moveSpeed *= 2f;
            Ani.SetBool("Ifrun", true);
        }
        if (Input.GetKeyUp(CL.GetKeyCodeForValue(7)))
        {
            moveSpeed = CL.moveSpeed;
            Ani.SetBool("Ifrun", false);
        }
        if (Input.GetKeyDown(CL.GetKeyCodeForValue(8)))
        {
            SceneManager.LoadScene("InGameControlScene");
        }

        //���������ж�
        if (Ani.GetBool("IfMoveKey"))
        {
            if (Ani.GetBool("Ifrun"))
            {
                switch (Dir)
                {
                    case 1:
                        Ani.Play("Flyback");
                        break;
                    case 0:
                        Ani.Play("Flyface");
                        break;
                    case -1:
                        Ani.Play("Flyleft");
                        break;
                    case -2:
                        Ani.Play("Flyright");
                        break;
                }
            }
            else
            {
                switch (Dir)
                {
                    case 1:
                        Ani.Play("Moveback");
                        break;
                    case 0:
                        Ani.Play("Moveface");
                        break;
                    case -1:
                        Ani.Play("Moveleft");
                        break;
                    case -2:
                        Ani.Play("Moveright");
                        break;
                }
            }
        }
        else
        {
            switch (Dir)
            {
                case 1:
                    Ani.Play("Standback");
                    break;
                case 0:
                    Ani.Play("Standface");
                    break;
                case -1:
                    Ani.Play("Standleft");
                    break;
                case -2:
                    Ani.Play("Standright");
                    break;
            }
        }
    }
}
