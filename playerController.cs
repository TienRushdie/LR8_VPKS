using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEditor;
public class playerController : MonoBehaviour
    
{
    float hor, vert;
    public float speed;
    int Capacity;
    Rigidbody2D rb;
    public GameObject ratingtable;
    public float Money;
    public Text moneytext;
    public Text nicktext;
    public Text[] texts = new Text[10];
    public GameObject Panel;
    public bool IsPanelActive;
    static int id = 1;// Camera cam;
    [SerializeField] private string udURL = "http://localhost/mining_farm_db/upload_data.php";

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        // cam=Camera.main;
        Money = PlayerPrefs.GetFloat("Balance");
        Capacity = PlayerPrefs.GetInt("Capacity");
        nicktext.text = PlayerPrefs.GetString("NickName");
        StartCoroutine(EarningMoney());
        Panel.SetActive(false);
        IsPanelActive = false;

    }
    private void Awake()
    {
       
    }

    public void ExitFromGame() {
        PlayerPrefs.SetString("NickName", "");
        PlayerPrefs.SetFloat("Balance", 0);
        PlayerPrefs.SetInt("Capacity", 0);
        UpdateBalance();
         SceneManager.LoadScene("Menu"); }
    public void OnApplicationQuit()
    {
        PlayerPrefs.SetString("NickName", "");
        PlayerPrefs.SetFloat("Balance", 0);
        PlayerPrefs.SetInt("Capacity", 0);
        UpdateBalance();

    }
    IEnumerator EarningMoney()
    {
        while (true)
        {
            Money = Money + Capacity*0.1f;
            moneytext.text = Money.ToString("0");
            yield return new WaitForSeconds(1);
        }
    }
    private void UpdateBalance()
    {
        WWWForm form = new WWWForm();
        form.AddField("nick", nicktext.text);
        form.AddField("money", Money.ToString());
        form.AddField("t1c", texts[0].text.ToString());
        form.AddField("t2c", texts[1].text.ToString());
        form.AddField("t3c", texts[2].text.ToString());
        Capacity =
            (int.Parse(texts[0].text.ToString())*4 +
            int.Parse(texts[1].text.ToString())*8 +
            int.Parse(texts[2].text.ToString())*20);
        form.AddField("cap", Capacity);

        WWW www = new WWW(udURL, form);
     

    }
    
  


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) { Panel.SetActive(false);ratingtable.SetActive(true); }
        if (Panel.active == false)
        {

            if (Input.GetAxis("Horizontal") != 0)
            {
                anim.SetTrigger("Input");
                hor = Input.GetAxis("Horizontal");
                if (hor <= 0)
                {
                    transform.rotation = new Quaternion(0, -180, 0, 0);
                }
                else { transform.rotation = new Quaternion(0, 0, 0, 0); }
                rb.velocity = new Vector2(hor * speed * Time.deltaTime, rb.velocity.y);
            }
            else { anim.SetTrigger("Output"); }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

}
