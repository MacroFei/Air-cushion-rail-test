using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class move_tree : MonoBehaviour {

      public Transform start;     public Transform end;     //public InputField inputField;     //public Button button;     private float speed;
    private float M;  //滑块重量
    private float m;  //砝码重量
    private float f1; //滑块的风阻
    private float f2; //滑轮的阻力
    private float x0; //滑块起始点到第一个光电门的距离
    private float x1; //滑块起始点到第二个光电门的距离
    private float x2;     private float G;//重力加速度
   
    private float v1; //滑块经过第一个光电门的平均速度
    private float v2; //滑块经过第二个光电门的平均速度
    private float t;  //相对时间
    private float v;  //

    private float a;

    private static int going = 0 ;        /*   private void Start()     {         GameObject.Find("Cube").GetComponent<Button>().onClick.AddListener(Update);     }*/      void Update()     {
        InputField Mdemo = GameObject.Find("InputField_huakuai").GetComponent<InputField>();
        InputField mdemo = GameObject.Find("InputField_fama").GetComponent<InputField>();
        InputField f1demo = GameObject.Find("InputField_fengzu").GetComponent<InputField>();
        InputField f2demo = GameObject.Find("InputField_hualun").GetComponent<InputField>();
        InputField x0demo = GameObject.Find("InputField_x0").GetComponent<InputField>();
        InputField x1demo = GameObject.Find("InputField_x1").GetComponent<InputField>();
        InputField x2demo = GameObject.Find("InputField_x2").GetComponent<InputField>();
        InputField Gdemo = GameObject.Find("InputField_G").GetComponent<InputField>();

  
        M = float.Parse(Mdemo.text);
        m = float.Parse(mdemo.text);
        f1 = float.Parse(f1demo.text);
        f2 = float.Parse(f2demo.text);
        x0 = float.Parse(x0demo.text);
        x1 = float.Parse(x1demo.text);
        x2 = float.Parse(x2demo.text);
        G = float.Parse(Gdemo.text);
        //a = (m * G - f1 - f2) / (M + m) * (2 * x1 + x0);

        v1 = Mathf.Sqrt((m * G - f1 - f2) / (M + m) * (2 * x1 + x0));
        v2 = Mathf.Sqrt((m * G - f1 - f2) / (M + m) * (2 * x1 + 2 * x2 + x0));//速度计算公式
        t = 2 * x2 / (v1 + v2); //时间计算公式

       // GameObject.Find("show2").GetComponent<Text>().text = (t).ToString();
        //GameObject.Find("").GetComponent<Text>().text = ().toString;

        /*InputField input = GameObject.Find("speed").GetComponent<InputField>();         speed = int.Parse(input.text);*/
        //speed =  transform.position = Vector3.MoveTowards(start.position, end.position, speed * Time.deltaTime);


        GameObject.Find("Time_start").GetComponent<Button>().onClick.AddListener(timestart);
        GameObject.Find("Time_stop").GetComponent<Button>().onClick.AddListener(timestop);
      

        //时间暂停 功能
        Time.timeScale = going;



        speed += (m * G - f1 - f2) / (M + m) * Time.deltaTime; //速度控制

        transform.position = Vector3.MoveTowards(start.position, end.position, speed*Time.deltaTime);


        // transform.position = Vector3.MoveTowards(start.position, end.position, 1 * Time.deltaTime);


        GameObject.Find("show5").GetComponent<Text>().text = Mathf.Round(speed).ToString();
          //  speed.ToString();

        /* var aa = GameObject.Find("SlidingBolck1");
         var bb = GameObject.Find("SlidingBolck2");
         if (Vector3.Distance(aa.transform.position,bb.transform.position)>(Vector3.Distance(bb.transform.position,bb.transform.position))){
             GameObject.Find("show4").GetComponent<Text>().text = "速度趋势：" + speed.ToString();
         }*/
        a = (m * G - f1 - f2) / (M + m);//加速度计算公式

        GameObject.Find("Button_start").GetComponent<Button>().onClick.AddListener(ashow);//展示数据

    }
    void timestart(){//开始函数
        going = 1;
    }
    void timestop(){//暂停函数
        going = 0;
    }
    void ashow(){
        GameObject.Find("show").GetComponent<Text>().text = a.ToString();
    } 
}
