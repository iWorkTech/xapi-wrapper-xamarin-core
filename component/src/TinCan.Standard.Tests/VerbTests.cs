// ***********************************************************************
// Assembly         : xAPI.Standard.Tests
// Author           : ashedge
// Created          : 03-09-2018
//
// Last Modified By : ashedge
// Last Modified On : 03-09-2018
// ***********************************************************************
// <copyright file="VerbTests.cs" company="xAPI.Standard.Tests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region License and Warranty Information

// ==========================================================
//  <copyright file="VerbTest.cs" company="iWork Technologies">
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

using Newtonsoft.Json.Linq;
using Xunit;
using xAPI.Standard.Json;

#endregion

namespace xAPI.Standard.Tests
{

    /// <summary>
    /// Class VerbTest.
    /// </summary>

    public class VerbTests
    {
        /// <summary>
        /// Tests the empty CTR.
        /// </summary>
        [Fact]
        public void TestEmptyCtr()
        {
            var obj = new Verb();
            Assert.IsType<Verb>(obj);
            Assert.Null(obj.ID);
            Assert.Null(obj.Display);

            Assert.Equal("{}", obj.ToJSON());
        }

        /// <summary>
        /// Tests the j object CTR.
        /// </summary>
        [Fact]
        public void TestJObjectCtr()
        {
            var id = "https://w3id.org/xapi/adl/verbs/experienced";

            var cfg = new JObject { { "id", id } };

            var obj = new Verb(cfg);
            Assert.IsType<Verb>(obj);
            Assert.Equal(obj.ToJSON(), "{\"id\":\"" + id + "\"}");
        }

        /// <summary>
        /// Tests the string of json CTR.
        /// </summary>
        [Fact]
        public void TestStringOfJSONCtr()
        {
            var id = "https://w3id.org/xapi/adl/verbs/experienced";
            var json = "{\"id\":\"" + id + "\"}";
            var strOfJson = new StringOfJSON(json);

            var obj = new Verb(strOfJson);
            Assert.IsType<Verb>(obj);
            Assert.Equal(obj.ToJSON(), json);
        }
    }
}