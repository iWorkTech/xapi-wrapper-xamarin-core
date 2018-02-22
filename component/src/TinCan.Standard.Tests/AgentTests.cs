#region License and Warranty Information

// ==========================================================
//  <copyright file="AgentTest.cs" company="iWork Technologies">
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
using xAPI.Standard.Json;
using Xunit;

#endregion

namespace xAPI.Standard.Tests
{
    /// <summary>
    /// Class AgentTest.
    /// </summary>
    
    public class AgentTests
    {
        /// <summary>
        /// Tests the empty CTR.
        /// </summary>
        [Fact]
        public void TestEmptyCtr()
        {
            var obj = new Agent();
            Assert.IsType<Agent>(obj);
            Assert.Null(obj.Mbox);

            Assert.Equal("{\"objectType\":\"Agent\"}", obj.ToJSON());
        }

        /// <summary>
        /// Tests the j object CTR.
        /// </summary>
        [Fact]
        public void TestJObjectCtr()
        {
            var mbox = "mailto:so_moni@hotmail.com";

            var cfg = new JObject {{"mbox", mbox}};

            var obj = new Agent(cfg);
            Assert.IsType<Agent>(obj);
            Assert.Same(obj.Mbox, mbox);
        }

        /// <summary>
        /// Tests the string of json CTR.
        /// </summary>
        [Fact]
        public void TestStringOfJSONCtr()
        {
            var mbox = "mailto:so_moni@hotmail.com";

            var json = "{\"mbox\":\"" + mbox + "\"}";
            var strOfJson = new StringOfJSON(json);

            var obj = new Agent(strOfJson);
            Assert.IsType<Agent>(obj);
            Assert.Equal(obj.Mbox, mbox);
        }
    }

    public class StringAssert
    {
    }
}