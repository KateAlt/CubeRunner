using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubicRun.MainGame
{
    public class FinishController : MonoBehaviour
    {
        public Material whiteMat;
        public Material blackMat;
        public GameObject box;

        public GameObject finishTriger;

        public static ParticleSystem newEffect;

        public ParticleSystem effect;

        private int countColor;

        private void OnEnable()
        {
            SpawnMeneger.CreateFinishPlatforms += CreateFinishPanel;
            SpawnMeneger.CreateFinishEffects += CreateFinishEffect;
        }

        private void OnDisable()
        {
            SpawnMeneger.CreateFinishPlatforms -= CreateFinishPanel;
            SpawnMeneger.CreateFinishEffects -= CreateFinishEffect;
        }

        public void CreateFinishPanel(int posZ)
        {
            for( int i = -2; i < 3; i++ )       // z
            {
                for( int j = -2; j < 3; j++ )   // x
                {
                    /// position calculation
                    Vector3 positionSpawn = new Vector3((float)j, 20.0f, posZ - (float)i + 10f);
                    Vector3 posotionTarget = new Vector3((float)j, 0.0f, posZ - (float)i);

                    /// creating an object
                    GameObject objBox = Instantiate(box, positionSpawn, Quaternion.identity);
                                objBox.name = posotionTarget.ToString();

                    /// adding material
                    Renderer objBoxRen = objBox.GetComponent<Renderer>();
                    if(countColor % 2 == 0)
                        objBoxRen.material = blackMat;
                    else
                        objBoxRen.material = whiteMat;
                    countColor ++;

                    /// adding motion
                    float randomSpeedBox = UnityEngine.Random.Range(20f, 45f);
                    StartCoroutine(MovementHandler.MoveBox(objBox, posotionTarget, randomSpeedBox));                    
                }
            }            
        }

        public void CreateFinishEffect(int posZ)  /// 2
        {
            Vector3 positionSpawn = new Vector3(0.0f, 1.0f, posZ - 2.0f);
            newEffect = Instantiate(effect, positionSpawn, Quaternion.identity);
            // newEffect.Play();

            Instantiate(finishTriger, positionSpawn, Quaternion.identity);
        }
    }
}