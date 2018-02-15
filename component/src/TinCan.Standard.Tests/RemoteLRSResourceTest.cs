#region License and Warranty Information

// ==========================================================
//  <copyright file="RemoteLRSResourceTest.cs" company="iWork Technologies">
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
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TinCan.Standard.Documents;

#endregion

namespace TinCan.Standard.Tests
{
    /// <summary>
    /// Class RemoteLRSResourceTest.
    /// </summary>
    public class RemoteLRSResourceTest
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public RemoteLRSResourceTest()
        {
            Console.WriteLine("Running RemoteLRSResourceTest");

            //
            // these are credentials used by the other OSS libs when building via Travis-CI
            // so are okay to include in the repository, if you wish to have access to the
            // results of the test suite then supply your own endpoint, username, and password
            //
            //_lrs = new RemoteLRS(
            //    "https://lrs.adlnet.gov/xapi/",
            //    "Nja986GYE1_XrWMmFUE",
            //    "Bd9lDr1kjaWWY6RID_4"
            //);
            _lrs = new RemoteLRS(
                "https://trial-lrs.yetanalytics.io/xapi",
                "ae71f2a120eff211904994b8bfbc7328",
                "97ebd26e2ac39f1c408ecb5efd2ea915"
            );
        }

        /// <summary>
        /// The LRS
        /// </summary>
        readonly RemoteLRS _lrs;

        /// <summary>
        /// Tests the about.
        /// </summary>
        [Fact]
        public void TestAbout()
        {
            var lrsRes = _lrs.About();
            Assert.True(lrsRes.Success);
        }

        /// <summary>
        /// Tests the about failure.
        /// </summary>
        [Fact]
        public void TestAboutFailure()
        {
            //_lrs.Endpoint = new Uri("http://cloud.scorm.com/tc/3TQLAI9/sandbox/");
            _lrs.Endpoint = new Uri("https://trial-lrs.yetanalytics.io/xapii");

            var lrsRes = _lrs.About();
            Assert.False(lrsRes.Success);
            Console.WriteLine("TestAboutFailure - errMsg: " + lrsRes.ErrMsg);
        }

        /// <summary>
        /// Tests the state of the clear.
        /// </summary>
        [Fact]
        public void TestClearState()
        {
            var lrsRes = _lrs.ClearState(Support.Activity, Support.Agent);
            Assert.True(lrsRes.Success);
        }

        /// <summary>
        /// Tests the state of the clear.
        /// </summary>
        [Fact]
        public async Task TestClearStateAsync()
        {
            var lrsRes = await _lrs.ClearStateAsync(Support.Activity, Support.Agent).ConfigureAwait(false);
            Assert.True(lrsRes.Success);
        }

        /// <summary>
        /// Tests the delete activity profile.
        /// </summary>
        [Fact]
        public void TestDeleteActivityProfile()
        {
            var doc = new ActivityProfileDocument
            {
                Activity = Support.Activity,
                ID = Guid.NewGuid().ToString()
            };

            var lrsRes = _lrs.DeleteActivityProfile(doc);
            Assert.True(lrsRes.Success);
        }

        /// <summary>
        /// Tests the delete activity profile.
        /// </summary>
        [Fact]
        public async Task TestDeleteActivityProfileAsync()
        {
            var doc = new ActivityProfileDocument
            {
                Activity = Support.Activity,
                ID = Guid.NewGuid().ToString()
            };

            var lrsRes = await _lrs.DeleteActivityProfileAsync(doc).ConfigureAwait(false);
            Assert.True(lrsRes.Success);
        }

        /// <summary>
        /// Tests the delete agent profile.
        /// </summary>
        [Fact]
        public void TestDeleteAgentProfile()
        {
            var doc = new AgentProfileDocument
            {
                Agent = Support.Agent,
                ID = Guid.NewGuid().ToString()
            };

            var lrsRes = _lrs.DeleteAgentProfile(doc);
            Assert.True(lrsRes.Success);
        }

        /// <summary>
        /// Tests the delete agent profile.
        /// </summary>
        [Fact]
        public async Task TestDeleteAgentProfileAsync()
        {
            var doc = new AgentProfileDocument
            {
                Agent = Support.Agent,
                ID = Guid.NewGuid().ToString()
            };

            var lrsRes = await _lrs.DeleteAgentProfileAsync(doc).ConfigureAwait(false);
            Assert.True(lrsRes.Success);
        }

        /// <summary>
        /// Tests the state of the delete.
        /// </summary>
        [Fact]
        public void TestDeleteState()
        {
            var doc = new StateDocument
            {
                Activity = Support.Activity,
                Agent = Support.Agent,
                ID = Guid.NewGuid().ToString()
            };

            var lrsRes = _lrs.DeleteState(doc);
            Assert.True(lrsRes.Success);
        }

        /// <summary>
        /// Tests the state of the delete.
        /// </summary>
        [Fact]
        public async Task TestDeleteStateAsync()
        {
            var doc = new StateDocument
            {
                Activity = Support.Activity,
                Agent = Support.Agent,
                ID = Guid.NewGuid().ToString()
            };

            var lrsRes = await _lrs.DeleteStateAsync(doc).ConfigureAwait(false);
            Assert.True(lrsRes.Success);
        }

        /// <summary>
        /// Tests the more statements.
        /// </summary>
        [Fact]
        public void TestMoreStatements()
        {
            var query = new StatementsQuery
            {
                Format = StatementsQueryResultFormat.IDS,
                Limit = 2
            };

            var queryRes = _lrs.QueryStatements(query);
            if (!queryRes.Success || queryRes.Content.More == null) return;
            var moreRes = _lrs.MoreStatements(queryRes.Content);
            Assert.True(queryRes.Success);
            Assert.NotNull(moreRes);
            Console.WriteLine("TestMoreStatements - statement count: " + queryRes.Content.Statements.Count);
        }

        /// <summary>
        /// Tests the more statements.
        /// </summary>
        [Fact]
        public async Task TestMoreStatementsAsync()
        {
            var query = new StatementsQuery
            {
                Format = StatementsQueryResultFormat.IDS,
                Limit = 2
            };

            var queryRes = await _lrs.QueryStatementsAsync(query).ConfigureAwait(false);
            if (queryRes.Success && queryRes.Content.More != null)
            {
                var moreRes = await _lrs.MoreStatementsAsync(queryRes.Content).ConfigureAwait(false);
                Assert.True(queryRes.Success);
                Assert.NotNull(moreRes);
                Console.WriteLine("TestMoreStatementsAsync - statement count: " + queryRes.Content.Statements.Count);
            }
        }

        /// <summary>
        /// Tests the query statements.
        /// </summary>
        [Fact]
        public void TestQueryStatements()
        {
            var query = new StatementsQuery
            {
                Agent = Support.Agent,
                VerbId = Support.Verb.ID,
                ActivityId = Support.Parent.ID,
                RelatedActivities = true,
                RelatedAgents = true,
                Format = StatementsQueryResultFormat.IDS,
                Limit = 10
            };

            var lrsRes = _lrs.QueryStatements(query);
            Assert.True(lrsRes.Success);
            Console.WriteLine("TestQueryStatements - statement count: " + lrsRes.Content.Statements.Count);
        }

        /// <summary>
        /// Tests the query statements.
        /// </summary>
        [Fact]
        public async Task TestQueryStatementsAsync()
        {
            var query = new StatementsQuery
            {
                Agent = Support.Agent,
                VerbId = Support.Verb.ID,
                ActivityId = Support.Parent.ID,
                RelatedActivities = true,
                RelatedAgents = true,
                Format = StatementsQueryResultFormat.IDS,
                Limit = 10
            };

            var lrsRes = await _lrs.QueryStatementsAsync(query).ConfigureAwait(false);
            Assert.True(lrsRes.Success);
            Console.WriteLine("TestQueryStatements - statement count: " + lrsRes.Content.Statements.Count);
        }

        /// <summary>
        /// Tests the retrieve activity profile.
        /// </summary>
        [Fact]
        public void TestRetrieveActivityProfile()
        {
            var lrsRes = _lrs.RetrieveActivityProfile("test", Support.Activity);
            Assert.True(lrsRes.Success);
            Assert.IsType<ActivityProfileDocument>(lrsRes.Content);
        }

        /// <summary>
        /// Tests the retrieve activity profile.
        /// </summary>
        [Fact]
        public async Task TestRetrieveActivityProfileAsync()
        {
            var lrsRes = await _lrs.RetrieveActivityProfileAsync("test", Support.Activity).ConfigureAwait(false);
            Assert.True(lrsRes.Success);
            Assert.IsType<ActivityProfileDocument>(lrsRes.Content);
        }

        /// <summary>
        /// Tests the retrieve activity profile ids.
        /// </summary>
        [Fact]
        public void TestRetrieveActivityProfileIds()
        {
            var lrsRes = _lrs.RetrieveActivityProfileIds(Support.Activity);
            Assert.True(lrsRes.Success);
        }

        /// <summary>
        /// Tests the retrieve activity profile ids.
        /// </summary>
        [Fact]
        public async Task TestRetrieveActivityProfileIdsAsync()
        {
            var lrsRes = await _lrs.RetrieveActivityProfileIdsAsync(Support.Activity).ConfigureAwait(false);
            Assert.True(lrsRes.Success);
        }

        /// <summary>
        /// Tests the retrieve agent profile.
        /// </summary>
        [Fact]
        public void TestRetrieveAgentProfile()
        {
            var lrsRes = _lrs.RetrieveAgentProfile("test", Support.Agent);
            Assert.True(lrsRes.Success);
            Assert.IsType<AgentProfileDocument>(lrsRes.Content);
        }

        /// <summary>
        /// Tests the retrieve agent profile.
        /// </summary>
        [Fact]
        public async Task TestRetrieveAgentProfileAsync()
        {
            var lrsRes = await _lrs.RetrieveAgentProfileAsync("test", Support.Agent).ConfigureAwait(false);
            Assert.True(lrsRes.Success);
            Assert.IsType<AgentProfileDocument>(lrsRes.Content);
        }

        /// <summary>
        /// Tests the retrieve agent profile ids.
        /// </summary>
        [Fact]
        public void TestRetrieveAgentProfileIds()
        {
            var lrsRes = _lrs.RetrieveAgentProfileIds(Support.Agent);
            Assert.True(lrsRes.Success);
        }

        /// <summary>
        /// Tests the retrieve agent profile ids.
        /// </summary>
        [Fact]
        public async Task TestRetrieveAgentProfileIdsAsync()
        {
            var lrsRes = await _lrs.RetrieveAgentProfileIdsAsync(Support.Agent).ConfigureAwait(false);
            Assert.True(lrsRes.Success);
        }

        /// <summary>
        /// Tests the state of the retrieve.
        /// </summary>
        [Fact]
        public void TestRetrieveState()
        {
            var lrsRes = _lrs.RetrieveState("test", Support.Activity, Support.Agent);
            Assert.True(lrsRes.Success);
            Assert.IsType<StateDocument>(lrsRes.Content);
        }

        /// <summary>
        /// Tests the state of the retrieve.
        /// </summary>
        [Fact]
        public async Task TestRetrieveStateAsync()
        {
            var lrsRes = await _lrs.RetrieveStateAsync("test", Support.Activity, Support.Agent).ConfigureAwait(false);
            Assert.True(lrsRes.Success);
            Assert.IsType<StateDocument>(lrsRes.Content);
        }

        /// <summary>
        /// Tests the retrieve state ids.
        /// </summary>
        [Fact]
        public void TestRetrieveStateIds()
        {
            var lrsRes = _lrs.RetrieveStateIds(Support.Activity, Support.Agent);
            Assert.True(lrsRes.Success);
        }

        /// <summary>
        /// Tests the retrieve state ids.
        /// </summary>
        [Fact]
        public async Task TestRetrieveStateIdsAsync()
        {
            var lrsRes = await _lrs.RetrieveStateIdsAsync(Support.Activity, Support.Agent).ConfigureAwait(false);
            Assert.True(lrsRes.Success);
        }

        /// <summary>
        /// Tests the retrieve statement.
        /// </summary>
        [Fact]
        public void TestRetrieveStatement()
        {
            var statement = new Statement();
            statement.Stamp();
            statement.Actor = Support.Agent;
            statement.Verb = Support.Verb;
            statement.Target = Support.Activity;
            statement.Context = Support.Context;
            statement.Result = Support.Result;

            var saveRes = _lrs.SaveStatement(statement);
            if (!saveRes.Success) return;
            if (saveRes.Content.ID == null) return;
            var retRes = _lrs.RetrieveStatement(saveRes.Content.ID.Value);
            Assert.True(retRes.Success);
            Console.WriteLine("TestRetrieveStatement - statement: " + retRes.Content.ToJSON(true));
        }

        /// <summary>
        /// Tests the retrieve statement.
        /// </summary>
        [Fact]
        public async Task TestRetrieveStatementAsync()
        {
            var statement = new Statement();
            statement.Stamp();
            statement.Actor = Support.Agent;
            statement.Verb = Support.Verb;
            statement.Target = Support.Activity;
            statement.Context = Support.Context;
            statement.Result = Support.Result;

            var saveRes = await _lrs.SaveStatementAsync(statement).ConfigureAwait(false);
            if (!saveRes.Success) return;
            if (saveRes.Content.ID == null) return;
            var retRes = await _lrs.RetrieveStatementAsync(saveRes.Content.ID.Value).ConfigureAwait(false);
            Assert.True(retRes.Success);
            Console.WriteLine("TestRetrieveStatement - statement: " + retRes.Content.ToJSON(true));
        }

        /// <summary>
        /// Tests the save activity profile.
        /// </summary>
        [Fact]
        public void TestSaveActivityProfile()
        {
            var doc = new ActivityProfileDocument
            {
                Activity = Support.Activity,
                ID = Guid.NewGuid().ToString(),
                Content = Encoding.UTF8.GetBytes("Test value"), 
                Etag = "1234567890", 
                ContentType = "text", 
                Timestamp = DateTime.Now
          
            };

            var lrsRes = _lrs.SaveActivityProfile(doc);
            Assert.True(lrsRes.Success);
        }

        /// <summary>
        /// Tests the save activity profile.
        /// </summary>
        [Fact]
        public async Task TestSaveActivityProfileAsync()
        {
            var doc = new ActivityProfileDocument
            {
                Activity = Support.Activity,
                ID = Guid.NewGuid().ToString(),
                Content = Encoding.UTF8.GetBytes("Test value"),
                Etag = "1234567890", 
                ContentType = "text", 
                Timestamp = DateTime.Now
            };

            var lrsRes = await _lrs.SaveActivityProfileAsync(doc).ConfigureAwait(false);
            Assert.True(lrsRes.Success);
        }

        /// <summary>
        /// Tests the save agent profile.
        /// </summary>
        [Fact]
        public void TestSaveAgentProfile()
        {
            var doc = new AgentProfileDocument
            {
                Agent = Support.Agent,
                ID = Guid.NewGuid().ToString(),
                Content = Encoding.UTF8.GetBytes("Test value"),
                Etag = "1234567890", 
                ContentType = "text", 
                Timestamp = DateTime.Now
            };

            var lrsRes = _lrs.SaveAgentProfile(doc);
            Assert.True(lrsRes.Success);
        }

        /// <summary>
        /// Tests the save agent profile.
        /// </summary>
        [Fact]
        public async Task TestSaveAgentProfileAsync()
        {
            var doc = new AgentProfileDocument
            {
                Agent = Support.Agent,
                ID = Guid.NewGuid().ToString(),
                Content = Encoding.UTF8.GetBytes("Test value"),
                Etag = "1234567890", 
                ContentType = "text", 
                Timestamp = DateTime.Now
            };

            var lrsRes = await _lrs.SaveAgentProfileAsync(doc).ConfigureAwait(false);
            Assert.True(lrsRes.Success);
        }

        /// <summary>
        /// Tests the state of the save.
        /// </summary>
        [Fact]
        public void TestSaveState()
        {
            var doc = new StateDocument
            {
                Activity = Support.Activity,
                Agent = Support.Agent,
                ID = Guid.NewGuid().ToString(),
                Content = Encoding.UTF8.GetBytes("Test value")
            };

            var lrsRes = _lrs.SaveState(doc);
            Assert.True(lrsRes.Success);
        }

        /// <summary>
        /// Tests the state of the save.
        /// </summary>
        [Fact]
        public async Task TestSaveStateAsync()
        {
            var doc = new StateDocument
            {
                Activity = Support.Activity,
                Agent = Support.Agent,
                ID = Guid.NewGuid().ToString(),
                Content = Encoding.UTF8.GetBytes("Test value")
            };

            var lrsRes = await _lrs.SaveStateAsync(doc).ConfigureAwait(false);
            Assert.True(lrsRes.Success);
        }

        /// <summary>
        /// Tests the save statement.
        /// </summary>
        [Fact]
        public void TestSaveStatement()
        {
            var statement = new Statement
            {
                Actor = Support.Agent,
                Verb = Support.Verb,
                Target = Support.Activity
            };

            var lrsRes = _lrs.SaveStatement(statement);
            Assert.True(lrsRes.Success);
            Assert.Equal(statement, lrsRes.Content);
            Assert.NotNull(lrsRes.Content.ID);
        }

        /// <summary>
        /// Tests the save statement.
        /// </summary>
        [Fact]
        public async Task TestSaveStatementAsync()
        {
            var statement = new Statement
            {
                Actor = Support.Agent,
                Verb = Support.Verb,
                Target = Support.Activity,
            };

            var lrsRes = await _lrs.SaveStatementAsync(statement).ConfigureAwait(false);
            Assert.True(lrsRes.Success);
            Assert.Equal(statement, lrsRes.Content);
            Assert.NotNull(lrsRes.Content.ID);
        }

        /// <summary>
        /// Tests the save statement.
        /// </summary>
        //[Fact]
        //public async Task TestSaveStatementWithContextAsync()
        //{
        //    var statement = new Statement
        //    {
        //        Actor = Support.Agent,
        //        Verb = Support.Verb,
        //        Target = Support.Parent,
        //        Context = Support.Context,
        //        Result = Support.Result, 
        //        Version = TCAPIVersion.V103
        //    };

        //    var lrsRes = await _lrs.SaveStatementAsync(statement).ConfigureAwait(false);
        //    Assert.True(lrsRes.Success);
        //    Assert.Equal(statement, lrsRes.Content);
        //    Assert.NotNull(lrsRes.Content.ID);
        //}

        /// <summary>
        /// Tests the save statement.
        /// </summary>
        //[Fact]
        //public async Task TestSaveStatementWithResultAsync()
        //{
        //    var statement = new Statement
        //    {
        //        Actor = Support.Agent,
        //        Verb = Support.Verb,
        //        Target = Support.Activity,
        //        Result = Support.Result
        //    };

        //    var lrsRes = await _lrs.SaveStatementAsync(statement).ConfigureAwait(false);
        //    Assert.True(lrsRes.Success);
        //    Assert.Equal(statement, lrsRes.Content);
        //    Assert.NotNull(lrsRes.Content.ID);
        //}

        /// <summary>
        /// Tests the save statements.
        /// </summary>
        [Fact]
        public void TestSaveStatements()
        {
            var statement1 = new Statement
            {
                Actor = Support.Agent,
                Verb = Support.Verb,
                Target = Support.Parent
            };

            var statement2 = new Statement
            {
                Actor = Support.Agent,
                Verb = Support.Verb,
                Target = Support.Activity,
                Context = Support.Context
            };

            var statements = new List<Statement> { statement1, statement2 };

            var lrsRes = _lrs.SaveStatements(statements);
            Assert.True(lrsRes.Success);
            // TODO: check statements match and ids not null
        }

        /// <summary>
        /// Tests the save statements.
        /// </summary>
        [Fact]
        public async Task TestSaveStatementsAsync()
        {
            var statement1 = new Statement
            {
                Actor = Support.Agent,
                Verb = Support.Verb,
                Target = Support.Parent
            };

            var statement2 = new Statement
            {
                Actor = Support.Agent,
                Verb = Support.Verb,
                Target = Support.Activity,
                Context = Support.Context
            };

            var statements = new List<Statement> { statement1, statement2 };

            var lrsRes = await _lrs.SaveStatementsAsync(statements).ConfigureAwait(false);
            Assert.True(lrsRes.Success);
            // TODO: check statements match and ids not null
        }

        /// <summary>
        /// Tests the save statement statement reference.
        /// </summary>
        [Fact]
        public void TestSaveStatementStatementRef()
        {
            var statement = new Statement();
            statement.Stamp();
            statement.Actor = Support.Agent;
            statement.Verb = Support.Verb;
            statement.Target = Support.StatementRef;

            var lrsRes = _lrs.SaveStatement(statement);
            Assert.True(lrsRes.Success);
            Assert.Equal(statement, lrsRes.Content);
        }

        /// <summary>
        /// Tests the save statement statement reference.
        /// </summary>
        [Fact]
        public async Task TestSaveStatementStatementRefAsync()
        {
            var statement = new Statement();
            statement.Stamp();
            statement.Actor = Support.Agent;
            statement.Verb = Support.Verb;
            statement.Target = Support.StatementRef;

            var lrsRes = await _lrs.SaveStatementAsync(statement).ConfigureAwait(false);
            Assert.True(lrsRes.Success);
            Assert.Equal(statement, lrsRes.Content);
        }

        /// <summary>
        /// Tests the save statement sub statement.
        /// </summary>
        [Fact]
        public void TestSaveStatementSubStatement()
        {
            var statement = new Statement();
            statement.Stamp();
            statement.Actor = Support.Agent;
            statement.Verb = Support.Verb;
            statement.Target = Support.SubStatement;

            Console.WriteLine(statement.ToJSON(true));

            var lrsRes = _lrs.SaveStatement(statement);
            Assert.True(lrsRes.Success);
            Assert.Equal(statement, lrsRes.Content);
        }

        /// <summary>
        /// Tests the save statement sub statement.
        /// </summary>
        [Fact]
        public async Task TestSaveStatementSubStatementAsync()
        {
            var statement = new Statement();
            statement.Stamp();
            statement.Actor = Support.Agent;
            statement.Verb = Support.Verb;
            statement.Target = Support.SubStatement;

            Console.WriteLine(statement.ToJSON(true));

            var lrsRes = await _lrs.SaveStatementAsync(statement).ConfigureAwait(false);
            Assert.True(lrsRes.Success);
            Assert.Equal(statement, lrsRes.Content);
        }

        /// <summary>
        /// Tests the save statement with identifier.
        /// </summary>
        [Fact]
        public void TestSaveStatementWithID()
        {
            var statement = new Statement();
            statement.Stamp();
            statement.Actor = Support.Agent;
            statement.Verb = Support.Verb;
            statement.Target = Support.Activity;

            var lrsRes = _lrs.SaveStatement(statement);
            Assert.True(lrsRes.Success);
            Assert.Equal(statement, lrsRes.Content);
        }

        /// <summary>
        /// Tests the save statement with identifier.
        /// </summary>
        [Fact]
        public async Task TestSaveStatementWithIDAsync()
        {
            var statement = new Statement();
            statement.Stamp();
            statement.Actor = Support.Agent;
            statement.Verb = Support.Verb;
            statement.Target = Support.Activity;

            var lrsRes = await _lrs.SaveStatementAsync(statement).ConfigureAwait(false);
            Assert.True(lrsRes.Success);
            Assert.Equal(statement, lrsRes.Content);
        }

        /// <summary>
        /// Tests the void statement.
        /// </summary>
        [Fact]
        public void TestVoidStatement()
        {
            var toVoid = Guid.NewGuid();
            var lrsRes = _lrs.VoidStatement(toVoid, Support.Agent);

            Assert.True(lrsRes.Success, "LRS response successful");
            Assert.Equal(new Uri("http://adlnet.gov/expapi/verbs/voided"), lrsRes.Content.Verb.ID);
            Assert.Equal(toVoid, ((StatementRef)lrsRes.Content.Target).ID);
        }

        /// <summary>
        /// Tests the void statement.
        /// </summary>
        [Fact]
        public async Task TestVoidStatementAsync()
        {
            var toVoid = Guid.NewGuid();
            var lrsRes = await _lrs.VoidStatementAsync(toVoid, Support.Agent).ConfigureAwait(false);

            Assert.True(lrsRes.Success, "LRS response successful");
            Assert.Equal(new Uri("http://adlnet.gov/expapi/verbs/voided"), lrsRes.Content.Verb.ID);
            Assert.Equal(toVoid, ((StatementRef)lrsRes.Content.Target).ID);
        }
    }
}