using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore;
using TMPro;
public class Tex : MonoBehaviour
{
    private bool move = false;
    public TMP_Text tmp;
    private Vector2 vect;
    public GameObject ggg;
    public TMP_Text pref;
    public TMP_Text preff;
    public Canvas can;
    void Start()
    {
       // tmp = GetComponent<TMP_Text>();
    }
    public void Motion(int score, GameObject gg)
    {

        TMP_Text t = Instantiate(pref, gg.transform.position, Quaternion.identity);
       
        t.transform.SetParent(can.transform);
        t.GetComponent<TMP_Text>().text = "+" + score;
        t.transform.position = new Vector2(gg.transform.position.x, gg.transform.position.y);
        preff = t;
        vect = new Vector2(0, 4);
        move = true;
       
    }
  
    void Update()
    {
        

        if (move == true)
        {
            
            preff.transform.Translate(vect * Time.deltaTime);
            
        }  
        
        
       
    }

  
}
