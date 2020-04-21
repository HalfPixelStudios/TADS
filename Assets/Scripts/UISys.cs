using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISys : MonoBehaviour
{
    private Text textComp;
    string message = "Due to unfortunate circumstances, " +
                     "you have been turned into an omnipotent deity." +
                     " However, you are still short on pocket change " +
                     "so you decide to work as a pizza delivery man. " +
                     "There is one catch however, you do not have a " +
                     "tangible form. Therefore, using your new founded " +
                     "powers, you must possess other mortals to complete " +
                     "the delivery before the pizza gets cold.";
    
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
                yield return new WaitForSeconds(0.9f);
                textComp.text = "";
            }
            else
            {
                yield return new WaitForSeconds(0.02f);
                
            }
            
        }

        gameObject.SetActive(false);
    }
}
