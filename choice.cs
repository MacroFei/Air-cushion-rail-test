using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class choice : MonoBehaviour
{   /*切换场景*/

    public void OnStartGame(string ScneneName)
    {
         Application.LoadLevel(ScneneName);//读取场景，场景名称 
    }


    public class button_test : MonoBehaviour
    {

        public InputField input;
        public Button button;
        public Text show;
        // Use this for initialization
        void Start()
        {
            GameObject.Find("button").GetComponent<Button>().onClick.AddListener(OnClickMethod);
        }
        private void OnClickMethod()
        {
            InputField input = GameObject.Find("input").GetComponent<InputField>();
            GameObject.Find("show").GetComponent<Text>().text = input.text;

            GameObject.Find("show").GetComponent<Text>().text = (int.Parse(input.text) + 10).ToString();
        }


        // Update is called once per frame
        void Update()
        {

        }

    }

}


