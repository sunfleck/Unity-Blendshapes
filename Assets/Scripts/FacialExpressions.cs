using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
In Unity 2019, the Animator component on your NPC must have Update Mode set to “Animate Physics”.
In Unity 6, the Animator component on your NPC must have “Animate Physics’ checked and Update Mode set to “Fixed”.
These settings can be changed if needed in your code (but not done here).
*/

    public class FacialExpressions : MonoBehaviour
    {
        SkinnedMeshRenderer skinnedMeshRenderer;      
        public float speed;
        private bool smile;
        private bool determination;
        private bool lookLeft;
        public bool isPlaying;
        private float[] current; //gets the animation settings before the facial expression is triggered
        public float[] endValuesSmile; //smile
        public float[] endValuesDetermination; //show determination
        public float[] endValuesLookLeft; //look left
        private float[] intermediateValues;

        // Start is called before the first frame update
        void Start()
        {
            skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
            current = new float[29];
            intermediateValues = new float[29];
            GetCurrent();
        }

        public void GetCurrent()
        {
            for (int i = 0; i < current.Length; i++)
            {
                current[i] = skinnedMeshRenderer.GetBlendShapeWeight(i);
            }
        }
        public IEnumerator LookLeft()
        {
            GetCurrent();
            isPlaying = true;
            float t = 0;
            speed = 4;
            while (t < 1) //start looking left
            {
                for (int i = 0; i < current.Length; i++)
                {
                    if (i == 26)
                    {
                        intermediateValues[i] = Mathf.Lerp(current[i], endValuesLookLeft[i], t); //lerps from current to final values
                        skinnedMeshRenderer.SetBlendShapeWeight(i, intermediateValues[i]);
                    }
                }
                t += speed * Time.deltaTime;
                yield return null;
            }
            t = 0;
            while (t < 3) //stay looking left for 3 seconds
            {
                for (int i = 0; i < current.Length; i++)
                {
                    if (i == 26)
                    {
                        skinnedMeshRenderer.SetBlendShapeWeight(i, endValuesLookLeft[i]);
                    }
                }
                t += speed * Time.deltaTime;
                yield return null;
            }
            t = 0;
            while (t < 1) //end looking left
            {
                for (int i = 0; i < current.Length; i++)
                {
                    if (i == 26)
                    {
                        intermediateValues[i] = Mathf.Lerp(endValuesLookLeft[i], current[i], t); //lerps back to original values
                        skinnedMeshRenderer.SetBlendShapeWeight(i, intermediateValues[i]);
                    }
                }
                t += speed * Time.deltaTime;
                yield return null;
            }
            isPlaying = false;
        }

        public IEnumerator Determination()
        {
            GetCurrent();
            isPlaying = true;
            float t = 0;
            speed = 2;
            while (t < 1) //start looking determined
            {
                for (int i = 0; i < current.Length; i++)
                {
                    if (i == 0 || i == 1 || i == 16)
                    {
                        intermediateValues[i] = Mathf.Lerp(current[i], endValuesDetermination[i], t); //lerps from current to final values
                    skinnedMeshRenderer.SetBlendShapeWeight(i, intermediateValues[i]);
                    }             
                } 
                t += speed * Time.deltaTime;
                yield return null;                
            }
            t = 0;
            while (t < 4) //maintain looking determined for 4 seconds
            {
                for (int i = 0; i < current.Length; i++)
                {
                    if (i == 0 || i == 1 || i == 16)
                    {
                        skinnedMeshRenderer.SetBlendShapeWeight(i, endValuesDetermination[i]);
                    }             
                } 
                t += speed * Time.deltaTime;
                yield return null;                
            }
            t = 0;
            while (t < 1) //end being determined
            {
                for (int i = 0; i < current.Length; i++)
                {
                    if (i == 0 || i == 1 || i == 16)
                    {
                        intermediateValues[i] = Mathf.Lerp(endValuesDetermination[i], current[i], t); //lerps back to original values
                    skinnedMeshRenderer.SetBlendShapeWeight(i, intermediateValues[i]);
                    }
                }
                t += speed * Time.deltaTime;
                yield return null;
            }
            isPlaying = false;
        }

        public IEnumerator Smile() //requires Animator Update Mode set to Animate Physics
        {
            GetCurrent();
            isPlaying = true;
            speed = 2;
            float t = 0; //start smiling
            while (t < 1)
            {
                for (int i = 0; i < current.Length; i++)
                {
                    if (i == 2 || i == 3 || i == 6 || i == 11 || i == 15 || i == 21 || i == 22)
                    {
                        intermediateValues[i] = Mathf.Lerp(current[i], endValuesSmile[i], t); //lerps from current to final values
                    skinnedMeshRenderer.SetBlendShapeWeight(i, intermediateValues[i]);
                    }            
                } 
                t += speed * Time.deltaTime;
                yield return null;              
            }
            t = 0;
            while (t < 4) //maintain smile for 4 seconds
            {
                for (int i = 0; i < current.Length; i++)
                {
                    if (i == 2 || i == 3 || i == 6 || i == 11 || i == 15 || i == 21 || i == 22)
                    {
                        skinnedMeshRenderer.SetBlendShapeWeight(i, endValuesSmile[i]);
                    }            
                } 
                t += speed * Time.deltaTime;
                yield return null;              
            }
            t = 0;
            speed = 1;
            while (t < 1) //end smile
            {
                for (int i = 0; i < current.Length; i++)
                {
                    if (i == 2 || i == 3 || i == 6 || i == 11 || i == 15 || i == 21 || i == 22)
                    {
                        intermediateValues[i] = Mathf.Lerp(endValuesSmile[i], current[i], t); //lerps back to original values
                        skinnedMeshRenderer.SetBlendShapeWeight(i, intermediateValues[i]);
                    }
                }
                t += speed * Time.deltaTime;
                yield return null;
            }
            isPlaying = false;
        }
    }

