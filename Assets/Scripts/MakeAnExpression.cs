using UnityEngine;

public class MakeAnExpression : MonoBehaviour
{
    public FacialExpressions expressions;

    public void MakeSmile()
    {
        if (!expressions.isPlaying)
        {
            expressions.StartCoroutine("Smile");
        }
    }

    public void LookLeft()
    {
        if (!expressions.isPlaying)
        {
            expressions.StartCoroutine("LookLeft");
        }
    }

    public void LookDetermined()
    {
        if (!expressions.isPlaying)
        {
            expressions.StartCoroutine("Determination");
        }
    }
}
