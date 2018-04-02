/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  FlagTrail.cs
 *  Description  :  Define flag trail.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mogoson.Map
{
    /// <summary>
    /// Flag Trail Info.
    /// </summary>
    [Serializable]
    public struct TrailInfo
    {
        /// <summary>
        /// Target flag.
        /// </summary>
        public RectTransform flag;

        /// <summary>
        /// Trail color.
        /// </summary>
        public Color color;

        /// <summary>
        /// Trail pixel diffuse.
        /// </summary>
        public int diffuse;

        /// <summary>
        /// Constructor of TrailInfo.
        /// </summary>
        /// <param name="flag">Target flag.</param>
        /// <param name="color">Trail color.</param>
        /// <param name="diffuse">Trail pixel diffuse.</param>
        public TrailInfo(RectTransform flag, Color color, int diffuse)
        {
            this.flag = flag;
            this.color = color;
            this.diffuse = diffuse;
        }
    }

	/// <summary>
	/// Trail of flag on map.
	/// </summary>
    [AddComponentMenu("Mogoson/Map/FlagTrail")]
    [RequireComponent(typeof(RectTransform), typeof(RawImage))]
    public class FlagTrail : MonoBehaviour
    {
        #region Field and Property
        /// <summary>
        /// Trail info.
        /// </summary>
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

        private Vector2 pos = Vector2.zero;
        private int x = 0, y = 0, r = 0;
        #endregion

        #region Protected Method
        protected virtual void Start()
        {
            Initialise();
            ClearTrail();
        }

        protected virtual void LateUpdate()
        {
            UpdateTrail();
        }

        /// <summary>
        /// Initialise trail texture.
        /// </summary>
        protected void Initialise()
        {
            rectTrans = GetComponent<RectTransform>();

            width = (int)rectTrans.rect.width;
            height = (int)rectTrans.rect.height;

            pixelColors = new Color[width * height];
            texture = new Texture2D(width, height) { name = "Trail" };
            GetComponent<RawImage>().texture = texture;
        }

        /// <summary>
        /// Update the pixels color of trail texture.
        /// </summary>
        protected void UpdateTrail()
        {
            foreach (var info in trailInfo)
            {
                pos = GetMappingPos(info.flag);
                x = (int)pos.x;
                y = (int)pos.y;
                r = info.diffuse;

                //Set the circle(center is (x, y), radius is r) area's color.
                for (int h = -r; h <= r; h++)
                {
                    for (int v = -r; v <= r; v++)
                    {
                        if (Mathf.Pow(h, 2) + Mathf.Pow(v, 2) <= Mathf.Pow(r, 2))
                            SetPixelAt(x + h, y + v, info.color);
                    }
                }
            }
            UpdateTexture();
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
        protected void UpdateTexture()
        {
            texture.SetPixels(pixelColors);
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
            UpdateTexture();
        }

#if UNITY_EDITOR
        /// <summary>
        /// Clear the pixels of trail texture (Only call this method in editor script).
        /// </summary>
        public void ClearTrailInEditor()
        {
            Start();
        }
#endif
        #endregion
    }
}