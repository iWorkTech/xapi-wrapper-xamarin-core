#region License and Warranty Information

// ==========================================================
//  <copyright file="SubStatementTest.cs" company="iWork Technologies">
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

namespace xAPI.Standard.Tests
{
    /// <summary>
    /// Class SubStatementTest.
    /// </summary>
    
    public class SubStatementTests
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Init()
        {
            Console.WriteLine("Running SubStatementTest");
        }

        /// <summary>
        /// Tests the empty CTR.
        /// </summary>
        [Fact]
        public void TestEmptyCtr()
        {
            var obj = new SubStatement();
            Assert.IsType<SubStatement>(obj);
            Assert.Null(obj.Actor);
            Assert.Null(obj.Verb);
            Assert.Null(obj.Target);
            Assert.Null(obj.Result);
            Assert.Null(obj.Context);

            Assert.Equal("{\"objectType\":\"SubStatement\"}", obj.ToJSON());
        }

        /// <summary>
        /// Tests the j object CTR nested sub statement.
        /// </summary>
        [Fact]
        public void TestJObjectCtrNestedSubStatement()
        {
            var cfg = new JObject
            {
                {"actor", Supports.Agent.ToJObject()},
                {"verb", Supports.Verb.ToJObject()},
                {"object", Supports.SubStatement.ToJObject()}
            };

            var obj = new SubStatement(cfg);
            Assert.IsType<SubStatement>(obj);
            Assert.Null(obj.Target);
        }
    }
}