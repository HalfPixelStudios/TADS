using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobberController : Possesable
{
    public override void DefaultBehavior()
    {
        
    }

    public override void PossessedBehavior()
    {
        Vector2 clickPos = GlobalContainer.Global.screenManager.GetScreenClick();
        transform.LookAt(new Vector3(clickPos.x,0,clickPos.y));
        transform.rotation=Quaternion.Euler(0,transform.rotation.eulerAngles.y,0);
        
        
    }
}
