using System;

namespace NewDevTraining
{
    /// <summary>
    /// Base class for the user controls
    /// </summary>
    public class BaseUserControl : System.Web.UI.UserControl
    {
        /// <summary>
        /// Gets the host name from the request
        /// </summary>
        protected string Host
        {
            get
            {
                return Request.Url.Host;
            }
        }

        /// <summary>
        /// Initializes a new instance of the BaseUserControl class
        /// </summary>
        public BaseUserControl()
        {

        }

        /// <summary>
        /// Gets the Content ID.  Looks for "id", "pageid" and "ekfrm" on querystring.
        /// </summary>
        public long ContentId
        {
            get
            {
                string contentIdParameter = string.Empty;

                if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    contentIdParameter = Request.QueryString["id"];
                }
                else if (!String.IsNullOrEmpty(Request.QueryString["pageid"]))
                {
                    contentIdParameter = Request.QueryString["pageid"];
                }
                else if (!String.IsNullOrEmpty(Request.QueryString["ekfrm"]))
                {
                    contentIdParameter = Request.QueryString["ekfrm"];
                }
                else
                {
                    return 0;
                }

                long contentIdValue = 0;
                long.TryParse(contentIdParameter, out contentIdValue);

                return contentIdValue;
            }
        }

        /// <summary>
        /// Returns BaseMaster object of the current controls page
        /// </summary>
        public BaseMaster BaseMaster
        {
            get
            {
                if (this.Page.Master is BaseMaster)
                {
                    return this.Page.Master as BaseMaster;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}