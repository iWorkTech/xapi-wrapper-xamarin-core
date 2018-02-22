using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xAPI.Standard;
using xAPI.Standard.Documents;
using xAPI.Standard.LRSResponses;

namespace xAPIWrapper
{
    /// <summary>
    /// Class xAPIWrapper. - Test
    /// </summary>
    /// <seealso cref="T:xAPIWrapper.IxAPIWrapper" />
    /// <seealso cref="T:xAPIWrapper.IxAPIWrapper" />
    /// <seealso cref="T:xAPIWrapper.IxAPIWrapper" />
    /// <seealso cref="T:System.IDisposable" />
    public class ApiWrapper : IxApiWrapper, IDisposable
    {
        /// <summary>
        /// The LRS
        /// </summary>
        private RemoteLRS _lrs;

        /// <summary>
        /// The username
        /// </summary>
        private string _username;
        /// <summary>
        /// The password
        /// </summary>
        private string _password;
        /// <summary>
        /// The endpoint
        /// </summary>
        private string _endpoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiWrapper" /> class.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public ApiWrapper(string endpoint, string username, string password)
        {
            Init(endpoint, username, password);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        void IDisposable.Dispose()
        {
            _lrs = null;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public void Init(string endpoint, string username, string password)
        {
            //_endpoint = string.IsNullOrWhiteSpace(endpoint) ? "https://lrs.adlnet.gov/xAPI/" : endpoint;
            //_username = string.IsNullOrWhiteSpace(username) ? "Nja986GYE1_XrWMmFUE" : username;
            //_password = string.IsNullOrWhiteSpace(password) ? "Bd9lDr1kjaWWY6RID_4" : password;

            _endpoint = string.IsNullOrWhiteSpace(endpoint) ? "https://trial-lrs.yetanalytics.io/xapi" : endpoint;
            _username = string.IsNullOrWhiteSpace(username) ? "ae71f2a120eff211904994b8bfbc7328" : username;
            _password = string.IsNullOrWhiteSpace(password) ? "97ebd26e2ac39f1c408ecb5efd2ea915" : password;

           _lrs = new RemoteLRS(_endpoint, _username, _password);
        }

        /// <summary>
        /// Abouts this instance.
        /// </summary>
        /// <returns>Task&lt;LRSResponse&gt;.</returns>
        public async Task<AboutLRSResponse> AboutAsync()
        {
            var lrsRes = await _lrs.AboutAsync().ConfigureAwait(false);
            return lrsRes;
        }

        /// <inheritdoc />
        /// <summary>
        /// Changes the configuration.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <exception cref="T:System.NotImplementedException"></exception>
        public void ChangeConfig(string endpoint, string username, string password)
        {
            _endpoint = string.IsNullOrWhiteSpace(username) ? "https://lrs.adlnet.gov/xAPI/" : endpoint;
            _username = string.IsNullOrWhiteSpace(username) ? "Nja986GYE1_XrWMmFUE" : username;
            _password = string.IsNullOrWhiteSpace(password) ? "Bd9lDr1kjaWWY6RID_4" : password;

            _lrs = new RemoteLRS(_endpoint, _username, _password);
        }

        /// <inheritdoc />
        /// <summary>
        /// Prepares the statement.
        /// </summary>
        /// <param name="agent">The agent.</param>
        /// <param name="verb">The verb.</param>
        /// <param name="target">The target.</param>
        /// <returns>Statement.</returns>
        /// <exception cref="T:System.NotImplementedException"></exception>
        public Statement PrepareStatement(Agent agent, Verb verb, IStatementTarget target)
        {
            var statement = new Statement
            {
                Actor = agent,
                Target = target,
                Verb = verb
            };

            return statement;
        }

        /// <inheritdoc />
        /// <summary>
        /// Prepares the statement.
        /// </summary>
        /// <param name="agentEmail">The agent.</param>
        /// <param name="verb">The verb.</param>
        /// <param name="activityType">The target.</param>
        /// <returns>Statement.</returns>
        public Statement PrepareStatement(string agentEmail, string verb, string activityType)
        {
            var agent = new Agent {Mbox = "mailto:" + agentEmail};

            var verbLocal = new Verb
            {
                ID = new Uri(string.Format("http://adlnet.gov/expapi/verbs/{0}", verb)),
                Display = new LanguageMap()
            };

            verbLocal.Display.Add("en-US", "experienced");

            var target = new Activity { ID = string.Format("http://adlnet.gov/expapi/activities/{0}", activityType) };

            var statement = new Statement
            {
                Actor = agent,
                Target = target,
                Verb = verbLocal
            };

            return statement;
        }

        /// <inheritdoc />
        /// <summary>
        /// Sends the statement.
        /// </summary>
        /// <param name="statement">The statement.</param>
        /// <returns>LRSResponse.</returns>
        /// <exception cref="T:System.NotImplementedException"></exception>
        public async Task<StatementLRSResponse> SendStatementAsync(Statement statement)
        {
            var result = await _lrs.SaveStatementAsync(statement).ConfigureAwait(false);
            return result;          
        }

        /// <summary>
        /// Sends the statement.
        /// </summary>
        /// <param name="agent">The agent.</param>
        /// <param name="verb">The verb.</param>
        /// <param name="target">The target.</param>
        /// <returns>Task&lt;LRSResponse&gt;.</returns>
        public async Task<LRSResponse> SendStatementAsync(Agent agent, Verb verb, IStatementTarget target)
        {
            var statement = new Statement
            {
                Version = xAPIVersion.Latest(),
                Actor = agent,
                Target = target,
                Verb = verb
            };

            var result = await _lrs.SaveStatementAsync(statement).ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        /// <summary>
        /// Sends the statements.
        /// </summary>
        /// <param name="statements">The statements.</param>
        /// <returns>LRSResponse.</returns>
        /// <exception cref="T:System.NotImplementedException"></exception>
        public async Task<StatementsResultLRSResponse> SendStatementsAsync(List<Statement> statements)
        {
            var result =  await _lrs.SaveStatementsAsync(statements).ConfigureAwait(false);
            return result;
        }

        /// <summary>
        /// Gets the statements.
        /// </summary>
        /// <param name="searchParams">The search parameters.</param>
        /// <returns>List&lt;Statement&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<StatementsResultLRSResponse> GetStatementsAsync(StatementsQuery searchParams)
        {
            var result =  await _lrs.QueryStatementsAsync(searchParams).ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the statements.
        /// </summary>
        /// <param name="since">Since a particular date</param>
        /// <param name="limit">Limit or size of the resultset</param>
        /// <returns>List&lt;Statement&gt;.</returns>
        /// <exception cref="T:System.NotImplementedException"></exception>
        public async Task<StatementsResultLRSResponse> GetStatementsAsync(DateTime since, int limit)
        {
            var queryParams = new StatementsQuery
            {
                Since = since,
                Limit = limit
            };
            var result =  await _lrs.QueryStatementsAsync(queryParams).ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the activities.
        /// </summary>
        /// <param name="activityId">The activity identifier.</param>
        /// <param name="activity"></param>
        /// <returns>List&lt;Activity&gt;.</returns>
        /// <exception cref="T:System.NotImplementedException"></exception>
        public async Task<ActivityProfileLRSResponse> GetActivityAsync(string activityId, Activity activity)
        {
            var result =  await _lrs.RetrieveActivityProfileAsync(activityId, activity).ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        /// <summary>
        /// Sends the state.
        /// </summary>
        /// <param name="activityId">The activity identifier.</param>
        /// <param name="agent">The agent.</param>
        /// <param name="stateId">The state identifier.</param>
        /// <param name="registration">The registration.</param>
        /// <param name="stateVal">The state value.</param>
        /// <param name="matchHash">The match hash.</param>
        /// <param name="noneMatchHash">The none match hash.</param>
        /// <returns>LRSResponse.</returns>
        /// <exception cref="T:System.NotImplementedException"></exception>
        public async Task<LRSResponse> SendStateAsync(string activityId, Agent agent, string stateId, Guid? registration, string stateVal, string matchHash,
            string noneMatchHash)
        {
            var activity = new Activity {ID = activityId};

            var doc = new StateDocument
            {   Activity = activity,
                Agent = agent,
                ID = stateId,
                Content = Encoding.UTF8.GetBytes(stateVal),
                Registration = registration
            };

            var result =  await _lrs.SaveStateAsync(doc).ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <param name="activityId">The activity identifier.</param>
        /// <param name="agent">The agent.</param>
        /// <param name="stateId">The state identifier.</param>
        /// <param name="registration">The registration.</param>
        /// <param name="stateVal">The state value.</param>
        /// <param name="matchHash">The match hash.</param>
        /// <param name="noneMatchHash">The none match hash.</param>
        /// <returns>Task&lt;LRSResponse&gt;.</returns>
        /// <exception cref="T:System.NotImplementedException"></exception>
        public async Task<StateLRSResponse> GetStateAsync(string activityId, Agent agent, string stateId, Guid? registration, string stateVal, string matchHash,
            string noneMatchHash)
        {
            var activity = new Activity {ID = activityId};
            var result =  await _lrs.RetrieveStateAsync(stateId, activity, agent, registration).ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        /// <summary>
        /// Deletes the state.
        /// </summary>
        /// <param name="activityId">The activity identifier.</param>
        /// <param name="agent">The agent.</param>
        /// <param name="stateId">The state identifier.</param>
        /// <param name="registration">The registration.</param>
        /// <param name="stateVal">The state value.</param>
        /// <param name="matchHash">The match hash.</param>
        /// <param name="noneMatchHash">The none match hash.</param>
        /// <returns>Task&lt;LRSResponse&gt;.</returns>
        /// <exception cref="T:System.NotImplementedException"></exception>
        public async Task<LRSResponse> DeleteStateAsync(string activityId, Agent agent, string stateId, Guid? registration, string stateVal, string matchHash,
            string noneMatchHash)
        {
            var activity = new Activity { ID = activityId };

            var doc = new StateDocument
            {
                Activity = activity,
                Agent = agent,
                ID = stateId,
                Content = Encoding.UTF8.GetBytes(stateVal),
                Registration = registration
            };

            var result =  await _lrs.DeleteStateAsync(doc).ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        /// <summary>
        /// Sends the activity profile.
        /// </summary>
        /// <param name="activityId">The activity identifier.</param>
        /// <param name="profileId">The profile identifier.</param>
        /// <param name="profilEval">The profil eval.</param>
        /// <param name="matchHash">The match hash.</param>
        /// <param name="noneMatchHash">The none match hash.</param>
        /// <returns>Task&lt;LRSResponse&gt;.</returns>
        public async Task<LRSResponse> SendActivityProfileAsync(string activityId, string profileId, string profilEval, string matchHash, string noneMatchHash)
        {
            var activity = new Activity { ID = activityId };

            var doc = new ActivityProfileDocument
            {
                Activity = activity,
                ID = profileId,
                Content = Encoding.UTF8.GetBytes(profilEval)
            };

            var result =  await _lrs.SaveActivityProfileAsync(doc).ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the activity profile.
        /// </summary>
        /// <param name="activityId">The activity identifier.</param>
        /// <param name="profileId">The profile identifier.</param>
        /// <param name="since">The since.</param>
        /// <returns>Task&lt;LRSResponse&gt;.</returns>
        public async Task<ActivityProfileLRSResponse> GetActivityProfileAsync(string activityId, string profileId, DateTime? since)
        {
            var activity = new Activity {ID = activityId};
            var result =  await _lrs.RetrieveActivityProfileAsync(profileId, activity).ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        /// <summary>
        /// Deletes the activity profile.
        /// </summary>
        /// <param name="activityId">The activity identifier.</param>
        /// <param name="profileId">The profile identifier.</param>
        /// <param name="matchHash">The match hash.</param>
        /// <param name="noneMatchHash">The none match hash.</param>
        /// <returns>Task&lt;LRSResponse&gt;.</returns>
        /// <exception cref="T:System.NotImplementedException"></exception>
        public async Task<LRSResponse> DeleteActivityProfileAsync(string activityId, string profileId, string matchHash, string noneMatchHash)
        {
            var activity = new Activity { ID = activityId };

            var doc = new ActivityProfileDocument
            {
                Activity = activity,
                ID = profileId,
            };

            var result =  await _lrs.DeleteActivityProfileAsync(doc).ConfigureAwait(false);
            return result;

        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the agents.
        /// </summary>
        /// <param name="agent">The agent.</param>
        /// <returns>Task&lt;LRSResponse&gt;.</returns>
        /// <exception cref="T:System.NotImplementedException"></exception>
        public async Task<AgentProfileLRSResponse> GetAgentAsync(Agent agent)
        {
            var result =  await _lrs.RetrieveAgentProfileAsync(agent.Mbox, agent).ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        /// <summary>
        /// Sends the agent profile.
        /// </summary>
        /// <param name="agent">The agent.</param>
        /// <param name="profileId">The profile identifier.</param>
        /// <param name="profilEval">The profil eval.</param>
        /// <param name="matchHash">The match hash.</param>
        /// <param name="noneMatchHash">The none match hash.</param>
        /// <returns>Task&lt;LRSResponse&gt;.</returns>
        /// <exception cref="T:System.NotImplementedException"></exception>
        public async Task<LRSResponse> SendAgentProfileAsync(Agent agent, string profileId, string profilEval, string matchHash, string noneMatchHash)
        {
            var doc = new AgentProfileDocument
            {
                Agent = agent,
                ID = profileId,
                Content = Encoding.UTF8.GetBytes(profilEval)
            };

            var result =  await _lrs.SaveAgentProfileAsync(doc).ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the agent profile.
        /// </summary>
        /// <param name="agentId">The agent identifier.</param>
        /// <param name="profileId">The profile identifier.</param>
        /// <param name="since">The since.</param>
        /// <returns>Task&lt;LRSResponse&gt;.</returns>
        /// <exception cref="T:System.NotImplementedException"></exception>
        public async Task<LRSResponse> GetAgentProfileAsync(string agentId, string profileId, DateTime? since)
        {
            var agent = new Agent {Mbox = agentId};
            var result =  await _lrs.RetrieveAgentProfileAsync(profileId, agent).ConfigureAwait(false);
            return result;
        }

        /// <summary>
        /// Deletes the agent profile.
        /// </summary>
        /// <param name="agent">The agent.</param>
        /// <param name="profileId">The profile identifier.</param>
        /// <param name="matchHash">The match hash.</param>
        /// <param name="noneMatchHash">The none match hash.</param>
        /// <returns>Task&lt;LRSResponse&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<LRSResponse> DeleteAgentProfileAsync(Agent agent, string profileId, string matchHash, string noneMatchHash)
        {
            var doc = new AgentProfileDocument
            {
                Agent = agent,
                ID = profileId,
            };

            var result =  await _lrs.DeleteAgentProfileAsync(doc).ConfigureAwait(false);
            return result;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Dispose()
        {
            _lrs = null;
        }

    }
}