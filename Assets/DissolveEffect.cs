using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEffect : MonoBehaviour
{
    Material dissolve;
    public bool dissolving;
    public float fade = 0f;
    // Start is called before the first frame update
    void Start()
    {
        dissolve = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        dissolve.SetFloat("_Dissolve", fade);

        if (Input.GetKeyDown("space"))
        {
            dissolving = true;
        }

        if (dissolving)
        {
            fade += Time.deltaTime;
            if (fade >= 1f)
            {
                fade = 1f;
                dissolving = false;
            }
            //dissolve.SetFloat("_Dissolve", fade);
        }
    }
}
