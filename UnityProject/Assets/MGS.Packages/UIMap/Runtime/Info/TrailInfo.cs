/*************************************************************************
 *  Copyright © 2017-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TrailInfo.cs
 *  Description  :  Flag Trail Info.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace MGS.UIMap
{
    /// <summary>
    /// Flag Trail Info.
    /// </summary>
    [Serializable]
    public class TrailInfo
    {
        /// <summary>
        /// Target flag.
        /// </summary>
        public RectTransform flag;

        /// <summary>
        /// Trail color.
        /// </summary>
        public Color color = Color.red;

        /// <summary>
        /// Trail pixel diffuse.
        /// </summary>
        public int diffuse = 0;

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
}