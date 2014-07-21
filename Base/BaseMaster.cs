using System;

namespace NewDevTraining
{
    /// <summary>
    /// Base class from which all master pages should inherit.
    /// </summary>
    public class BaseMaster : System.Web.UI.MasterPage
    {
        /// <summary>
        /// Initializes a new instance of the BaseMaster class
        /// </summary>
        public BaseMaster()
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
    }
}