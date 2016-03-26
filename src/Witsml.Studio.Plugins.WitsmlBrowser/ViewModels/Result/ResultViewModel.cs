﻿using Caliburn.Micro;
using ICSharpCode.AvalonEdit.Document;
using PDS.Witsml.Studio.Runtime;
using PDS.Witsml.Studio.ViewModels;

namespace PDS.Witsml.Studio.Plugins.WitsmlBrowser.ViewModels.Result
{
    /// <summary>
    /// Manages the behavior for the query result UI elements.
    /// </summary>
    /// <seealso cref="Caliburn.Micro.Screen" />
    public class ResultViewModel : Screen
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(ResultViewModel));

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultViewModel"/> class.
        /// </summary>
        /// <param name="runtime">The runtime service.</param>
        public ResultViewModel(IRuntimeService runtime, TextDocument queryResults, TextDocument messages)
        {
            _log.Debug("Creating view model instance");
            Runtime = runtime;

            QueryResults = new TextEditorViewModel(runtime, "XML", true)
            {
                Document = queryResults
            };
            Messages = new TextEditorViewModel(runtime, "XML", true)
            {
                Document = messages
            };
        }

        /// <summary>
        /// Gets the Parent <see cref="T:Caliburn.Micro.IConductor" /> for this view model.
        /// </summary>
        public new MainViewModel Parent
        {
            get { return (MainViewModel)base.Parent; }
        }

        /// <summary>
        /// Gets the data model for this view model.
        /// </summary>
        /// <value>
        /// The WitsmlSettings data model.
        /// </value>
        public Models.WitsmlSettings Model
        {
            get { return Parent.Model; }
        }

        /// <summary>
        /// Gets the runtime service.
        /// </summary>
        /// <value>The runtime.</value>
        public IRuntimeService Runtime { get; private set; }

        private TextEditorViewModel _queryResults;

        /// <summary>
        /// Gets or sets the query results editor.
        /// </summary>
        /// <value>The query results editor.</value>
        public TextEditorViewModel QueryResults
        {
            get { return _queryResults; }
            set
            {
                if (!ReferenceEquals(_queryResults, value))
                {
                    _queryResults = value;
                    NotifyOfPropertyChange(() => QueryResults);
                }
            }
        }

        private TextEditorViewModel _messages;

        /// <summary>
        /// Gets or sets the messages editor.
        /// </summary>
        /// <value>The messages editor.</value>
        public TextEditorViewModel Messages
        {
            get { return _messages; }
            set
            {
                if (!string.Equals(_messages, value))
                {
                    _messages = value;
                    NotifyOfPropertyChange(() => Messages);
                }
            }
        }
    }
}
