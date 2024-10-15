using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Num0 : MonoBehaviour
{
    

    public static Num0 num0;
    public Button btn;

    void Awake()
    {
        num0 = this;
    }

    void Start()
    {
       // Button bt = btn.GetComponent<Button>();
       // bt.onClick.AddListener(IsClicked);
    }
    // Update is called once per frame
    public void IsClicked()
    {
        Debug.Log("»Æ¿Œ");
    }
}
