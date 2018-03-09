// ***********************************************************************
// Assembly         : xAPI.Standard.Tests
// Author           : ashedge
// Created          : 11-16-2017
//
// Last Modified By : ashedge
// Last Modified On : 02-19-2018
// ***********************************************************************
// <copyright file="ResultTest.cs" company="xAPI.Standard.Tests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region License and Warranty Information

// ==========================================================
//  <copyright file="ResultTest.cs" company="iWork Technologies">
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
    /// Class ResultTest.
    /// </summary>
    public class ResultTest
    {
        /// <summary>
        /// Tests the empty CTR.
        /// </summary>
        [Fact]
        public void TestEmptyCtr()
        {
            var obj = new Result();
            Assert.IsType<Result>(obj);
            Assert.Null(obj.Completion);
            Assert.Null(obj.Success);
            Assert.Null(obj.Response);
            Assert.Null(obj.Duration);
            Assert.Null(obj.Score);
            Assert.Null(obj.Extensions);

            Assert.Equal("{}", obj.ToJSON());
        }

        /// <summary>
        /// Tests the j object CTR.
        /// </summary>
        [Fact]
        public void TestJObjectCtr()
        {
            var cfg = new JObject { { "completion", true }, { "success", true }, { "response", "Yes" } };

            var obj = new Result(cfg);
            Assert.IsType<Result>(obj);
            Assert.True(obj.Completion);
            Assert.True(obj.Success);
            Assert.Equal("Yes", obj.Response);
        }

        /// <summary>
        /// Tests the string of json CTR.
        /// </summary>
        [Fact]
        public void TestStringOfJSONCtr()
        {
            var json = "{\"success\": true, \"completion\": true, \"response\": \"Yes\"}";
            var strOfJson = new StringOfJSON(json);

            var obj = new Result(strOfJson);
            Assert.IsType<Result>(obj);
            Assert.True(obj.Success);
            Assert.True(obj.Completion);
            Assert.Equal("Yes", obj.Response);
        }
    }
}