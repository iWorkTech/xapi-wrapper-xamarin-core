#region License and Warranty Information

// ==========================================================
//  <copyright file="StatementTest.cs" company="iWork Technologies">
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
using Newtonsoft.Json.Linq;
using Xunit;

#endregion

namespace TinCan.Standard.Tests
{ /// <summary>
  /// Class StatementTest.
  /// </summary>
    
    public class StatementTest
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Init()
        {
            Console.WriteLine("Running StatementTest");
        }

        /// <summary>
        /// Tests the empty CTR.
        /// </summary>
        [Fact]
        public void TestEmptyCtr()
        {
            var obj = new Statement();
            Assert.IsType<Statement>(obj);
            Assert.Null(obj.ID);
            Assert.Null(obj.Actor);
            Assert.Null(obj.Verb);
            Assert.Null(obj.Target);
            Assert.Null(obj.Result);
            Assert.Null(obj.Context);
            Assert.Null(obj.Version);
            Assert.Null(obj.Timestamp);
            Assert.Null(obj.Stored);

            Assert.Equal("{\"version\":\"1.0.1\"}", obj.ToJSON());
        }

        /// <summary>
        /// Tests the j object CTR sub statement.
        /// </summary>
        [Fact]
        public void TestJObjectCtrSubStatement()
        {
            var cfg = new JObject
            {
                {"actor", Support.Agent.ToJObject()},
                {"verb", Support.Verb.ToJObject()},
                {"object", Support.SubStatement.ToJObject()}
            };

            var obj = new Statement(cfg);
            Assert.IsType<Statement>(obj);
            Assert.IsType<SubStatement>(obj.Target);
        }
    }
}