/*************************************************************************
 *  Copyright © 2017-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  FlagTrail.cs
 *  Description  :  Define flag trail.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MGS.UIMap
{
    /// <summary>
    /// Trail of flag on map.
    /// </summary>
    [RequireComponent(typeof(RectTransform), typeof(RawImage))]
    public class FlagTrail : MonoBehaviour
    {
        #region Field and Property
        /// <summary>
        /// Trail info.
        /// </summary>
        [Tooltip("Trail info.")]
        public List<TrailInfo> trailInfo;

        /// <summary>
        /// Pixels color of trail texture.
        /// </summary>
        protected Color[] pixelColors;

        /// <summary>
        /// RectTransform of trail.
        /// </summary>
        protected RectTransform rectTrans;

        /// <summary>
        /// Texture2D to draw trail.
        /// </summary>
        protected Texture2D texture;

        /// <summary>
        /// Width of trial texture.
        /// </summary>
        protected int width = 0;

        /// <summary>
        /// Height of trial texture.
        /// </summary>
        protected int height = 0;
        #endregion

        #region Protected Method
        /// <summary>
        /// Component awake.
        /// </summary>
        protected virtual void Awake()
        {
            Initialize();
            ClearTrail();
        }

        /// <summary>
        /// Initialize trail texture.
        /// </summary>
        protected virtual void Initialize()
        {
            rectTrans = GetComponent<RectTransform>();
            width = (int)rectTrans.rect.width;
            height = (int)rectTrans.rect.height;

            pixelColors = new Color[width * height];
            texture = new Texture2D(width, height) { name = "Trail" };
            GetComponent<RawImage>().texture = texture;
        }

        /// <summary>
        /// Component late update.
        /// </summary>
        protected virtual void LateUpdate()
        {
            UpdateTrail();
        }

        /// <summary>
        /// Update the pixels color of trail texture.
        /// </summary>
        protected void UpdateTrail()
        {
            foreach (var info in trailInfo)
            {
                var pos = GetMappingPos(info.flag);
                var x = (int)pos.x;
                var y = (int)pos.y;
                var r = info.diffuse;

                //Set the circle(center is (x, y), radius is r) area's color.
                for (int h = -r; h <= r; h++)
                {
                    for (int v = -r; v <= r; v++)
                    {
                        if (Mathf.Pow(h, 2) + Mathf.Pow(v, 2) <= Mathf.Pow(r, 2))
                        {
                            SetPixelAt(x + h, y + v, info.color);
                        }
                    }
                }
            }
            UpdateTexture(pixelColors);
        }

        /// <summary>
        /// Get mapping position of flag trail.
        /// </summary>
        /// <param name="flag">RectTransform of map flag.</param>
        /// <returns>Mapping position.</returns>
        protected Vector2 GetMappingPos(RectTransform flag)
        {
            return flag.anchoredPosition + new Vector2(width, height) * 0.5f;
        }

        /// <summary>
        /// Update the pixels of trail texture.
        /// </summary>
        /// <param name="pixels">Pixels color of trail texture.</param>
        protected void UpdateTexture(Color[] pixels)
        {
            texture.SetPixels(pixels);
            texture.Apply();
        }

        /// <summary>
        /// Set trail pixel color at mapping position.
        /// </summary>
        /// <param name="x">Mapping x.</param>
        /// <param name="y">Mapping y.</param>
        /// <param name="color">Pixel color.</param>
        protected void SetPixelAt(int x, int y, Color color)
        {
            x = Mathf.Clamp(x, 0, width - 1);
            y = Mathf.Clamp(y, 0, height - 1);
            pixelColors[y * width + x] = color;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Clear trail pixels.
        /// </summary>
        public void ClearTrail()
        {
            for (int i = 0; i < pixelColors.Length; i++)
            {
                pixelColors[i] = Color.clear;
            }
            UpdateTexture(pixelColors);
        }
        #endregion
    }
}