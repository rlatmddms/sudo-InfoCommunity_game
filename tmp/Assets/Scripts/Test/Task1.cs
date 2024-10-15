using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Task1 : MonoBehaviour
{
    public Button exitButton;
    public Button nextButton;
    public GameObject[] pages;
    public Button pc;

    public Button desktop;
    public Image desktop_screen;

    public Button IP_conf;
    public Image IP_conf_screen;

    public InputField ipfd1;
    public InputField ipfd2;
    public InputField ipfd3;

    public Image canvas_ui;

    Color wrong = new Color(140 / 255f, 15 / 255f, 15 / 255f);
    Color right = new Color(40 / 255f, 210 / 255f, 40 / 255f);
    public bool success = false;
    public GetLicenseSystem glc;

    // Start is called before the first frame update
    void Start()
    {
        nextButton.onClick.AddListener(submit);
        exitButton.onClick.AddListener(close_all);
        pc.onClick.AddListener(show_p2);
        desktop.onClick.AddListener(show_p3);
        IP_conf.onClick.AddListener(show_p4);
        for(int i = 0; i < pages.Length; i++) {
            pages[i].gameObject.SetActive(false);
        }
        canvas_ui.gameObject.SetActive(false);
    }

    public void show()
    {
        ipfd1.interactable = true;
        ipfd2.interactable = true;
        ipfd3.interactable = true;
        pages[0].gameObject.SetActive(true);
        pages[1].gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
    }
    void show_p2()
    {
        pages[1].gameObject.SetActive(false);
        pages[2].gameObject.SetActive(true);
        desktop.gameObject.SetActive(true);

        desktop_screen.gameObject.SetActive(false);
        IP_conf.gameObject.SetActive(false);
        IP_conf_screen.gameObject.SetActive(false);
        ipfd1.gameObject.SetActive(false);
        ipfd2.gameObject.SetActive(false);
        ipfd3.gameObject.SetActive(false);

    }
    void show_p3()
    {
        desktop_screen.gameObject.SetActive(true);
        desktop.gameObject.SetActive(false);
        IP_conf.gameObject.SetActive(true);
    }

    void show_p4()
    {
        IP_conf.gameObject.SetActive(false);
        IP_conf_screen.gameObject.SetActive(true);
        ipfd1.gameObject.SetActive(true);
        ipfd2.gameObject.SetActive(true);
        ipfd3.gameObject.SetActive(true);
    }


    void submit()
    {
        nextButton.gameObject.SetActive(false);
        if(ipfd1.text == "100.0.0.1" && ipfd2.text == "255.192.0.0" && ipfd3.text == "100.63.255.254")
        {
            StartCoroutine(effect(right));
            success = true;
        }
        else
        {
            StartCoroutine(effect(wrong));
        }
        ipfd1.interactable = false;
        ipfd2.interactable = false;
        ipfd3.interactable = false;
    }

    void close_all()
    {
        if(success)
        {   
            Debug.Log("ddd");
            glc.get_license_event();
        }
        else
        {
            glc.start_date = glc.d + 20;
        }
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].gameObject.SetActive(false);
        }
    }
    public IEnumerator effect(Color color)
    {
        canvas_ui.gameObject.SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            canvas_ui.color = new Color(color.r, color.g, color.b, (i * 10) / 255f);
            yield return new WaitForSeconds(0.01f);
        }
        for (int i = 0; i < 10; i++)
        {
            canvas_ui.color = new Color(color.r, color.g, color.b, (100 - i * 10) / 255f);
            yield return new WaitForSeconds(0.01f);
        }
        canvas_ui.color = color;
        canvas_ui.gameObject.SetActive(false);
    }
}
