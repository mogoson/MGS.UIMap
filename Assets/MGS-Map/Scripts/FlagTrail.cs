/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  FlagTrail.cs
 *  Description  :  Define flag trail.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  1/5/2017
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Developer.Map
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

    [AddComponentMenu("Developer/Map/FlagTrail")]
    [RequireComponent(typeof(RectTransform), typeof(RawImage))]
    public class FlagTrail : MonoBehaviour
    {
        #region Property and Field
        /// <summary>
        /// Trail info.
        /// </summary>
        public List<TrailInfo> trailInfo;

        /// <summary>
        /// Pixels of trail texture.
        /// </summary>
        protected Color[] pixels;

        /// <summary>
        /// RectTransform of trail.
        /// </summary>
        protected RectTransform rectTrans;

        /// <summary>
        /// Texture2D of trail.
        /// </summary>
        protected Texture2D texture;

        /// <summary>
        /// Sixe of trial.
        /// </summary>
        protected Vector2 size;
        #endregion

        #region Protected Method
        protected virtual void Start()
        {
            Initialise();
            ClearPixels();
        }

        protected virtual void LateUpdate()
        {
            foreach (var info in trailInfo)
            {
                var mPos = GetMappingPos(info.flag);
                var x = (int)mPos.x;
                var y = (int)mPos.y;
                var r = info.diffuse;

                //Set the circle(center is (x, y), radius is r) area's color.
                for (int h = -r; h <= r; h++)
                {
                    for (int v = -r; v <= r; v++)
                    {
                        var oX = x + h;
                        var oY = y + v;
                        if (Mathf.Pow(oX - x, 2) + Mathf.Pow(oY - y, 2) <= Mathf.Pow(r, 2))
                            UpdatePixel(oX, oY, info.color);
                    }
                }
            }
            UpdatePixels();
        }

        /// <summary>
        /// Initialise trail texture.
        /// </summary>
        protected void Initialise()
        {
            rectTrans = GetComponent<RectTransform>();
            var width = (int)rectTrans.rect.width;
            var height = (int)rectTrans.rect.height;
            size = new Vector2(width, height);
            pixels = new Color[width * height];
            texture = new Texture2D(width, height);
            GetComponent<RawImage>().texture = texture;
        }

        /// <summary>
        /// Get mapping position.
        /// </summary>
        /// <param name="rTrans">RectTransform.</param>
        protected Vector2 GetMappingPos(RectTransform rTrans)
        {
            return rTrans.anchoredPosition + size * 0.5f;
        }

        /// <summary>
        /// Update trail pixels.
        /// </summary>
        protected void UpdatePixels()
        {
            texture.SetPixels(pixels);
            texture.Apply();
        }

        /// <summary>
        /// Update trail pixel at mapping position.
        /// </summary>
        /// <param name="x">Mapping x.</param>
        /// <param name="y">Mapping y.</param>
        /// <param name="color">Pixel color.</param>
        protected void UpdatePixel(int x, int y, Color color)
        {
            if (x >= 0 && x < size.x && y >= 0 && y < size.y)
                pixels[y * (int)size.x + x] = color;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Clear trail pixels.
        /// </summary>
        public void ClearPixels()
        {
            for (int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = new Color(0, 0, 0, 0);
            }
            UpdatePixels();
        }

#if UNITY_EDITOR
        /// <summary>
        /// Clear trail pixels in edit mode (Only call this method in editor script).
        /// </summary>
        public void ClearPixelsInEditMode()
        {
            Start();
        }
#endif
        #endregion
    }
}