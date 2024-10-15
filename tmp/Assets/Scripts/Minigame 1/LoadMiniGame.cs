using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using TMPro;

public class MiniGame : MonoBehaviour
{

    public TextMeshProUGUI time;
    public TextMeshProUGUI Corrections;

    string[] Button_Tag = new string[28]{"0", "1", "2", "3", "4", "5", "6",
                            "7", "8", "9", "10", "11", "12", "13",
                            "14", "15", "16", "17", "18", "19", "20",
                            "21", "22", "23", "24", "25", "26", "27"};
           

    Vector3 Button0_Position = new(-400, -80, 0),
        Button1_Position = new(400, -80, 0),
        Button2_Position = new(-400, -320, 0),
        Button3_Position = new(400, -320, 0);

    public Button button0, button1, button2, button3;

    bool Correct;
    private static int order = 0;
    static float timer = 0;

    static int Correction = 0;
    public GameObject ButtonName0, ButtonName1, ButtonName2, ButtonName3;
    // Start is called before the first frame update
    async void Start()
    {
        //Debug.Log(order);
        //Debug.Log(Correction);
        
       

        TaskCompletionSource<int> IsButtonClicked = new TaskCompletionSource<int>();


        ButtonName0 = GameObject.Find(Button_Tag[Random.Range(0, 28)]);
        ButtonName1 = GameObject.Find(Button_Tag[Random.Range(0, 28)]);
        ButtonName2 = GameObject.Find(Button_Tag[Random.Range(0, 28)]);
        ButtonName3 = GameObject.Find(Button_Tag[Random.Range(0, 28)]);

        while ((ButtonName0 == ButtonName1 || ButtonName0 == ButtonName2 || ButtonName0 == ButtonName3 || ButtonName1 == ButtonName2 || ButtonName1 == ButtonName3 || ButtonName2 == ButtonName3) || (ButtonName0 != GameObject.Find(Button_Tag[order]) && ButtonName1 != GameObject.Find(Button_Tag[order]) && ButtonName2 != GameObject.Find(Button_Tag[order]) && ButtonName3 != GameObject.Find(Button_Tag[order])))
        {
            ButtonName0 = GameObject.Find(Button_Tag[Random.Range(0, 28)]);
            ButtonName1 = GameObject.Find(Button_Tag[Random.Range(0, 28)]);
            ButtonName2 = GameObject.Find(Button_Tag[Random.Range(0, 28)]);
            ButtonName3 = GameObject.Find(Button_Tag[Random.Range(0, 28)]);
        }
        ButtonName0.transform.localPosition = Button0_Position;
        ButtonName1.transform.localPosition = Button1_Position;
        ButtonName2.transform.localPosition = Button2_Position;
        ButtonName3.transform.localPosition = Button3_Position;

        button0 = ButtonName0.GetComponent<Button>();
        button1 = ButtonName1.GetComponent<Button>();
        button2 = ButtonName2.GetComponent<Button>();
        button3 = ButtonName3.GetComponent<Button>();



        button0.onClick.AddListener(() => { IsButtonClicked.SetResult(1); });
        button1.onClick.AddListener(() => { IsButtonClicked.SetResult(2); });
        button2.onClick.AddListener(() => { IsButtonClicked.SetResult(3); });
        button3.onClick.AddListener(() => { IsButtonClicked.SetResult(4); });

        //button0.onClick.AddListener(Num0.num0.IsClicked);
        //button1.onClick.AddListener(Num0.num0.IsClicked);
        //button2.onClick.AddListener(Num0.num0.IsClicked);
        //button3.onClick.AddListener(Num0.num0.IsClicked);

        await IsButtonClicked.Task;

        Button choose_button;
        if (IsButtonClicked.Task.Result == 1)
            choose_button = button0;
        else if (IsButtonClicked.Task.Result == 2)
            choose_button = button1;
        else if (IsButtonClicked.Task.Result == 3)
            choose_button = button2;
        else
            choose_button = button3;
        Debug.Log(choose_button);
        Debug.Log(GameObject.Find(Button_Tag[order]));
        if (order.ToString() == choose_button.gameObject.name)    
        {
            Correction++;
            order++;
        }

        

        if (order == 27 || timer >= 60f)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            SceneManager.LoadScene("MiniGame 1");
        }
        

        //ButtonName0.transform.localPosition = new(3000, 3000, 3000);
        //ButtonName1.transform.localPosition = new(3000, 3000, 3000);
        //ButtonName2.transform.localPosition = new(3000, 3000, 3000);
        //ButtonName3.transform.localPosition = new(3000, 3000, 3000);
    }


    void my_choice()
    {

    }


    // Update is called once per frame

    void Update()
    {
        timer += Time.deltaTime;
        time.text = string.Format("{0:N2}", timer);

        Corrections.text = Correction.ToString();
    }
}
