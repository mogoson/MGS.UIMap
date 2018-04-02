/*************************************************************************
 *  Copyright © 2016-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SimpleMove.cs
 *  Description  :  Simple move controller.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Mogoson.Map
{
    public class SimpleMove : MonoBehaviour
    {
        #region Field and Property
        public float moveSpeed = 10;
        public float rotateSpeed = 60;
        #endregion

        #region Private Method
        private void Update()
        {
            transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
            transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime);
        }
        #endregion
    }
}