using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISys : MonoBehaviour
{
    private Text textComp;
    string message = "Due to unfortunate circumstances, you have been turned into an omnipotent deity. " +
                     "It seems as if your powers come from this baby. Maybe you should protect it?";
    
    // Start is called before the first frame update
    void Start()
    {
        textComp = GetComponent<Text>();
        textComp.text = "";
        StartCoroutine(TypeText ());

    }
    
    IEnumerator TypeText () {
        foreach (char letter in message.ToCharArray())
        {
            textComp.text+= letter;
            if (letter == '?' || letter == '.')
            {
                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield return new WaitForSeconds(0.05f);
                
            }
            
        }
    }
}
