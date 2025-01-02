using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Transform hp_shape;
    public Transform st_shape;
    public SpriteRenderer st_rd;
    float stbar_x, stbar_sizex;
    float hpbar_x, hpbar_sizex;

    public Camera cam;
    public Text NoticeText;
    Color text_color;

    public bool[] having_license;
    public License[] licenses;


    void Awake()
    {
        having_license = new bool[10];
        for (int i = 0; i < 10; i++) {
            having_license[i] = false;
        }
        stbar_x = st_shape.localPosition.x;
        stbar_sizex = st_shape.localScale.x;

        hpbar_x = hp_shape.localPosition.x;
        hpbar_sizex = hp_shape.localScale.x;
    }

    private void Start()
    {
        text_color = NoticeText.color;
        NoticeText.gameObject.SetActive(false);
    }

    private void Update()
    {
        
    }

    public void Notice(string text,float x, float y, float time,int fontsize,bool fade)
    {
        NoticeText.transform.localPosition = new Vector3(x,y);
        NoticeText.fontSize = fontsize;
        NoticeText.text = text;
        NoticeText.gameObject.SetActive(true);
        NoticeText.color = text_color;
        StartCoroutine(close_text(time,fade));
    }
    private IEnumerator close_text(float time, bool fade)
    {
        yield return new WaitForSeconds(time);
        if (fade)
        {
            for (int aa = 0; aa < 255; aa += 5)
            {
                NoticeText.color = new Color(0, 0, 0, (255 - aa) / 255f);
                yield return new WaitForSeconds(0.01f); // 1초마다 반복문 실행
            }
        }
        NoticeText.gameObject.SetActive(false);
    }
    /*
     private void Start()
    {
        path = new List<Vector3Int>();
        StartCoroutine(UpdatePath());
    }

    private void Update()
    {
        MoveAlongPath();
    }

    private IEnumerator UpdatePath()
    {
        while (true)
        {
            CalculatePath();
            yield return new WaitForSeconds(1f); // 1초마다 경로 재계산
        }
    }
     */
    private void FixedUpdate()
    {
        show_hpbar(GameManager.gm.player.hp);
        show_stbar(GameManager.gm.player.stamina);
    }

    public void show_hpbar(int hp)
    {
        //hp 증감에 따른 변화
        hp_shape.localPosition = new Vector3(hpbar_x - (hpbar_sizex * (100 - hp) * 0.01f) / 2, hp_shape.localPosition.y, 1);
        hp_shape.localScale = new Vector3(hpbar_sizex * hp * 0.01f, hp_shape.localScale.y, 1);
    }
    public void show_stbar(int st)
    {
        //st 증감에 따른 변화
        st_shape.localPosition = new Vector3(stbar_x - (stbar_sizex * (1000 - st) * 0.001f) / 2, st_shape.localPosition.y, 1);
        st_shape.localScale = new Vector3(stbar_sizex * st * 0.001f, st_shape.localScale.y, 1);
    }

    public void get_license(int id)
    {
        if (id >= having_license.Length)
        {
            Debug.Log("index ERROR");
            return;
        }
        having_license[id] = true;
        licenses[id].get_license();
    }
    public void giveup_license(int id)
    {
        if (id >= having_license.Length)
        {
            Debug.Log("index ERROR");
            return;
        }
        having_license[id] = false;
        licenses[id].giveup_license();
    }

    public int license_sum()
    {
        int sum = 0;

        for(int i = 0; i < having_license.Length; i++)
        {
            if (having_license[i]) sum++;
        }

        return sum;
    }

}
