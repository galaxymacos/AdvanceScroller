using System.Collections;
using UnityEngine;

// public class BlurMaterialController : MaterialController
// {
//     private static readonly int BlurAmount = Shader.PropertyToID("_BlurAmount");
//
//     public override void Run(SpriteRenderer sr)
//     {
//         StartCoroutine(BlurCoroutine());
//     }
//     
//
//     private IEnumerator BlurCoroutine()
//     {
//         var currentBlurAmount = material.GetFloat(BlurAmount);
//         while (currentBlurAmount < 5)
//         {
//             currentBlurAmount += 0.08f;
//             material.SetFloat(BlurAmount, currentBlurAmount);
//             yield return null;
//         }
//
//         StartCoroutine(ClearCoroutine());
//     }
//
//     private IEnumerator ClearCoroutine()
//     {
//         var currentBlurAmount = material.GetFloat(BlurAmount);
//         while (currentBlurAmount > 0)
//         {
//             currentBlurAmount -= 0.08f;
//             material.SetFloat(BlurAmount, currentBlurAmount);
//             yield return null;
//         }
//
//         material.SetFloat(BlurAmount, 0);
//     }
//
//     
// }