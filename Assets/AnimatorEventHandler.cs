using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEventHandler : MonoBehaviour
{
   public void SelfDestroy()
   {
      Destroy(gameObject);
   }
}
