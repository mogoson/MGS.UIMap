/*************************************************************************
 *  Copyright © 2016-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TerrainInfo.cs
 *  Description  :  Terrain Info.
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
    /// Terrain Info.
    /// </summary>
    [Serializable]
    public class TerrainInfo
    {
        /// <summary>
        /// Center of terrain.
        /// </summary>
        public Transform center;

        /// <summary>
        /// Width of terrain.
        /// </summary>
        public float width = 500;

        /// <summary>
        /// Length of terrain.
        /// </summary>
        public float length = 500;

        /// <summary>
        /// Constructor of TerrainInfo.
        /// </summary>
        /// <param name="center">Center of terrain.</param>
        /// <param name="width">Width of terrain.</param>
        /// <param name="length">Length of terrain.</param>
        public TerrainInfo(Transform center, float width, float length)
        {
            this.center = center;
            this.width = width;
            this.length = length;
        }
    }
}