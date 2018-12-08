using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WS_2DWorldManager : WS_WorldManager
{
    [SerializeField] WS_ObjectData2D[] WS_ObjectData2DArray;

    public override void Init()
    {
        foreach(WS_ObjectData2D od in WS_ObjectData2DArray)
        {
            AddObjectData(od);
        }
    }

    void Update()
    {
        RaycastHit[] hits;
        Vector3 vector = transform.position;

        int x, y, px, nx, py, ny, d;
        hits = Physics.RaycastAll(vector, transform.forward);
        if (hits != null)
        {

            foreach (RaycastHit hit in hits)
            {

                if (hit.collider.gameObject.tag == "Ball")
                {

                    Renderer rend = hit.transform.GetComponent<Renderer>();
                    Texture2D tex = rend.material.mainTexture as Texture2D;
                    Vector2 pixelUV = hit.textureCoord;
                    pixelUV.x *= tex.width;
                    pixelUV.y *= tex.height;

                    Debug.Log(pixelUV.x + " " + pixelUV.y);



                    /* int r = 5;
                     for (x = 0; x <= r; x++)
                     {
                         d = (int)Mathf.Ceil(Mathf.Sqrt(r * r - x * x));
                         for (y = 0; y <= d; y++)
                         {
                             px = -((int)pixelUV.x + x);
                             nx = -((int)pixelUV.x - x);
                             py = (int)pixelUV.y + y;
                             ny = (int)pixelUV.y - y;

                             Color c1 = tex.GetPixel(px, py);
                             Color c2 = tex.GetPixel(nx, py);
                             Color c3 = tex.GetPixel(px, ny);
                             Color c4 = tex.GetPixel(nx, ny);

                             if (c1 == Color.red || c2 == Color.red || c3 == Color.red || c4 == Color.red)
                             {
                                 _target.SetActive(false);
                             }
                             // tex.SetPixel(px, py, Color.red);
                              //tex.SetPixel(nx, py, Color.red);

                             // tex.SetPixel(px, ny, Color.red);
                             // tex.SetPixel(nx, ny, Color.red);
                         }
                     }

                     tex.Apply();
             */
                    //  mat.material.SetTexture("_Tex", tex);

                    // tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, tex.GetPixel(0,0));
                    // tex.Apply();*/
                }
            }
        }
      }

    }
