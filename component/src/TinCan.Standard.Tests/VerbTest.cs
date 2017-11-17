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
using TinCan.Standard.Json;

#endregion

namespace TinCan.Standard.Tests
{

    /// <summary>
    /// Class VerbTest.
    /// </summary>
    
    public class VerbTest
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
            var id = "http://adlnet.gov/expapi/verbs/experienced";

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
            var id = "http://adlnet.gov/expapi/verbs/experienced";
            var json = "{\"id\":\"" + id + "\"}";
            var strOfJson = new StringOfJSON(json);

            var obj = new Verb(strOfJson);
            Assert.IsType<Verb>(obj);
            Assert.Equal(obj.ToJSON(), json);
        }
    }
}