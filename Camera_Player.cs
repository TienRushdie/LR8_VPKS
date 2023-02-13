using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera_Player : MonoBehaviour
{
    public GameObject ratingtable;
    public GameObject Panel;
    public GameObject ProfilePanel;
    public LeaderBoard_strings.lb_srting lbs { get; set; } = new LeaderBoard_strings.lb_srting();
    public GameObject LeaderBoard; //Основной Canvas
    public GameObject objectPrefab;// Создаваемый объект;
    public bool IsPanelActive;
    [SerializeField] private string URLL = "http://localhost/mining_farm_db/rating.php";
    [SerializeField] private string URLLL = "http://localhost/mining_farm_db/profile.php?user_Nick=";
    public string[,] top10=new string[5,3];
    public Text[] rating=new Text[18];
    public Text[] profile_info = new Text[7];
    void Start()
    {
        Panel.SetActive(false);
        ProfilePanel.SetActive(false);
        IsPanelActive = false;
        URLLL += PlayerPrefs.GetString("NickName");

    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
            Transform objecthit = hit.transform;
            if (objecthit.transform.gameObject == null)
            {
                Debug.Log("Null Hit");
            }
            else if (hit.transform.gameObject != null)
            {
                Debug.Log("Hit Collider: " + hit.transform.name);
            }

            
            if (hit.transform.tag == "RatingTable")
            {
                ratingtable.SetActive(false);
                Panel.gameObject.SetActive(true);
                IsPanelActive = true;
                StartCoroutine(Load_Rating());
               
            }


        }
    }
    public void Profile()
    {ProfilePanel.SetActive(true);
        print("Kurwa");
        StartCoroutine(Load_Profile_Info());
    }
    public void pExit()
    {
        ProfilePanel.SetActive(false);
    }
    IEnumerator Load_Profile_Info()
    {
        WWW www = new(URLLL);
        yield return www;
        var result = www.text;
        var split = result.Split(' ');
        profile_info[0].text=split[0];
        profile_info[1].text=split[1];
        profile_info[2].text="Balance:"+split[2];
        profile_info[3].text="Capacity:"+split[3];
        profile_info[4].text=split[4];
        profile_info[5].text=split[5];
        profile_info[6].text=split[6];

    }
   
    IEnumerator Load_Rating()
    {
        int g = 0;
        WWW www = new(URLL);
        yield return www;
        var result = www.text;
        var split = result.Split(',');
        print(split[0]);
        int i = 0;
        foreach (var item in split)
        {
            if (i ==5) { break; }
            var splitItem = item.Split(' ');

            for (int j = 0; j < splitItem.Length; j++)
            {
                top10[i, j] = splitItem[j];
                if (splitItem[j] == PlayerPrefs.GetString("NickName"))
                {
                    rating[15].text= splitItem[j-1];
                    rating[16].text = splitItem[j];
                    rating[17].text = splitItem[j + 1];

                }
               
              
                
            }
            print(top10[i, 0]+ top10[i, 1]+ top10[i, 2]);
            rating[g].text = (i+1).ToString();     
            g++;
            rating[g].text= top10[i, 1];           
            g++;
            rating[g].text= top10[i, 2];  
            g++;
            i++;
        }

        

    }
    //private void OnGUI()
    //{
    //    GUI.Label(new Rect(100, 20, 150, 80), "" + "          " + "      ");
    //}
    //public void OnMouseDown()
    //{

    //    Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
    //    Transform objecthit = hit.transform;
    //    if (hit.transform.gameObject.name != null)
    //    {
    //        Debug.Log("Hit Collider: " + hit.transform.name);
    //    }
    //}
}
