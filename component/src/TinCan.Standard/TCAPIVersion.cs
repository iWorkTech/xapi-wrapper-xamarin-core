#region License and Warranty Information

// ==========================================================
//  <copyright file="xAPIVersion.cs" company="iWork Technologies">
//  Copyright (c) 2015 All Right Reserved, http://www.iworktech.com/
// 
//  This source is subject to the iWork Technologies Permissive License.
//  Please see the License.txt file for more information.
//  All other rights reserved. 
// 
//  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY 
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
// 
//  </copyright>
//  <author>iWorkTech Dev</author>
//  <email>info@iworktech.com</email>
//  <date>2017-01-05</date>
// ===========================================================

#endregion

#region

using System;
using System.Collections.Generic;

#endregion

namespace xAPI.Standard
{
    /// <summary>
    /// Class xAPIVersion. This class cannot be inherited.
    /// </summary>
    public sealed class xAPIVersion
    {
        /// <summary>
        /// The V103
        /// </summary>
        public static readonly xAPIVersion V103 = new xAPIVersion("1.0.3");
        /// <summary>
        /// The V102
        /// </summary>
        public static readonly xAPIVersion V102 = new xAPIVersion("1.0.2");
        /// <summary>
        /// The V101
        /// </summary>
        public static readonly xAPIVersion V101 = new xAPIVersion("1.0.1");
        /// <summary>
        /// The V100
        /// </summary>
        public static readonly xAPIVersion V100 = new xAPIVersion("1.0.0");
        /// <summary>
        /// The V095
        /// </summary>
        public static readonly xAPIVersion V095 = new xAPIVersion("0.95");
        /// <summary>
        /// The V090
        /// </summary>
        public static readonly xAPIVersion V090 = new xAPIVersion("0.9");

        /// <summary>
        /// The known
        /// </summary>
        private static Dictionary<string, xAPIVersion> _known;
        /// <summary>
        /// The supported
        /// </summary>
        private static Dictionary<string, xAPIVersion> _supported;

        /// <summary>
        /// The text
        /// </summary>
        private readonly string _text;

        /// <summary>
        /// Initializes a new instance of the <see cref="xAPIVersion"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        private xAPIVersion(string value)
        {
            _text = value;
        }

        /// <summary>
        /// Latests this instance.
        /// </summary>
        /// <returns>xAPIVersion.</returns>
        public static xAPIVersion Latest()
        {
            return V103;
        }

        /// <summary>
        /// Gets the known.
        /// </summary>
        /// <returns>Dictionary&lt;System.String, xAPIVersion&gt;.</returns>
        public static Dictionary<string, xAPIVersion> GetKnown()
        {
            if (_known != null)
            {
                return _known;
            }

            _known = new Dictionary<string, xAPIVersion>
            {
                {"1.0.3", V103},
                {"1.0.2", V102},
                {"1.0.1", V101},
                {"1.0.0", V100},
                {"0.95", V095},
                {"0.9", V090}
            };

            return _known;
        }

        /// <summary>
        /// Gets the supported.
        /// </summary>
        /// <returns>Dictionary&lt;System.String, xAPIVersion&gt;.</returns>
        public static Dictionary<string, xAPIVersion> GetSupported()
        {
            if (_supported != null)
            {
                return _supported;
            }

            _supported = new Dictionary<string, xAPIVersion> { { "1.0.3", V103 }, { "1.0.2", V102}, {"1.0.1", V101}, {"1.0.0", V100}};

            return _supported;
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.String"/> to <see cref="xAPIVersion"/>.
        /// </summary>
        /// <param name="vStr">The v string.</param>
        /// <returns>The result of the conversion.</returns>
        /// <exception cref="System.ArgumentException">Unrecognized version: " + vStr</exception>
        public static explicit operator xAPIVersion(string vStr)
        {
            var s = GetKnown();
            if (!s.ContainsKey(vStr))
            {
                throw new ArgumentException("Unrecognized version: " + vStr);
            }

            return s[vStr];
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return _text;
        }
    }
}