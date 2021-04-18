using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : Tex
{
    private bool moving;
    Vector3 movVec;
    public int scores = 1;
    public ParticleSystem smok;
    public ParticleSystem fire;
    public Tex flyingtext;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //  if (!moving) return;
      //  transform.Translate(movVec)
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag != "Ground")
        {
            Eat(col.gameObject);
        }
    }

   
    public void Eat(GameObject gg)
    {
        if (gg.GetComponent<Buildings>().health <= scores) { flyingtext.Motion(gg.GetComponent<Buildings>().prize, gg); moving = true;  scores += gg.GetComponent<Buildings>().prize; gg.GetComponent<BoxCollider2D>().enabled = false; CheckForEffects(gg); }
    }

    public void CheckForEffects(GameObject obj)
    {
        Quaternion rot = Quaternion.Euler(transform.eulerAngles.x - 90, 0, 0);
        ParticleSystem sm = Instantiate(smok, new Vector2(obj.transform.position.x, obj.transform.position.y),rot);
        // smokclear = sm;
        //    g = obj;
        StartCoroutine(Clear( obj, sm));
    }

    public IEnumerator Clear(GameObject g, ParticleSystem smm)
    {
      
        yield return new WaitForSeconds(3);
        Destroy(g);
        Destroy(smm.gameObject);
        // Destroy(fireclear.gameObject);
    }
}
