﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour {
	void Start () {  
  
        GameObject btnObj = GameObject.Find("Button");//"Button"为你的Button的名称  
        Button btn = btnObj.GetComponent<Button>();  
        btn.onClick.AddListener(delegate ()  
        {  
            this.GoNextScene(btnObj);  
        });  
    }  
	public void GoNextScene(GameObject NScene)  
    {  
        Application.LoadLevel("mali");//切换到场景Scene_2  
    }  
}
