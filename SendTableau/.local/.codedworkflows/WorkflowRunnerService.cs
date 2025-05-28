using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UiPath.CodedWorkflows;
using UiPath.Activities.Contracts;

namespace AutoEmail
{
    public class WorkflowRunnerService
    {
        private readonly Func<string, IDictionary<string, object>, TimeSpan?, bool, InvokeTargetSession, IDictionary<string, object>> _runWorkflowHandler;
        public WorkflowRunnerService(Func<string, IDictionary<string, object>, TimeSpan?, bool, InvokeTargetSession, IDictionary<string, object>> runWorkflowHandler)
        {
            _runWorkflowHandler = runWorkflowHandler;
        }

        /// <summary>
        /// Invokes the tableau.xaml
        /// </summary>
        public void tableau(System.Data.DataTable DTInputs)
        {
            var result = _runWorkflowHandler(@"tableau.xaml", new Dictionary<string, object>{{"DTInputs", DTInputs}}, default, default, default);
        }

        /// <summary>
        /// Invokes the SendEmail.xaml
        /// </summary>
        public void SendEmail(System.Data.DataTable DTInputs)
        {
            var result = _runWorkflowHandler(@"SendEmail.xaml", new Dictionary<string, object>{{"DTInputs", DTInputs}}, default, default, default);
        }

        /// <summary>
        /// Invokes the Main.xaml
        /// </summary>
        public void Main()
        {
            var result = _runWorkflowHandler(@"Main.xaml", new Dictionary<string, object>{}, default, default, default);
        }
    }
}