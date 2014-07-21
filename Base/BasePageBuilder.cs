using System;
using System.Web.UI.WebControls;

using Ektron.Cms.PageBuilder;

namespace NewDevTraining
{
    /// <summary>
    /// Base class from which all PageBuilde classes will inherit
    /// </summary>
    public class BasePageBuilder : PageBuilder
    {
        /// <summary>
        /// Initializes a new instance of the BasePageBuilder class
        /// </summary>
        public BasePageBuilder()
        {

        }
        /// <summary>
        /// Standard Ektron PageBuilder method, required
        /// </summary>
        /// <param name="message">Error message</param>
        public override void Error(string message)
        {
            this.JsAlert(message);
        }

        /// <summary>
        /// Standard Ektron PageBuilder method, required
        /// </summary>
        /// <param name="message">The message to notify</param>
        public override void Notify(string message)
        {
            this.JsAlert(message);
        }

        /// <summary>
        /// Standard Ektron PageBuilder method, required
        /// </summary>
        /// <param name="message">string message</param>
        public void JsAlert(string message)
        {
            Literal lit = new Literal();
            lit.Text = "<script type=\"\" language=\"\">{0}</script>";
            lit.Text = string.Format(lit.Text, "alert('" + message + "');");
            Form.Controls.Add(lit);
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