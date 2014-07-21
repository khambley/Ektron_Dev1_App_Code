using System.Collections.Generic;

using Ektron.Cms;
using Ektron.Cms.Framework;
using Ektron.Cms.Framework.Content;

namespace NewDevTraining
{
    /// <summary>
    /// ContentType class that allows Smart Form properties to be mapped in code
    /// </summary>
    /// <typeparam name="T">The Smart Form object type</typeparam>
    public class ContentType<T> where T : class, new()           
    {
        /// <summary>
        /// Gets or sets the ContentData object
        /// </summary>
        public ContentData Content { get; set; }

        /// <summary>
        /// Gets or sets the Smart Form data
        /// </summary>
        public T SmartForm { get; set; }
    }

    /// <summary>
    /// ContentTypeManager class that allows Smart Form properties to be mapped in code
    /// </summary>
    /// <typeparam name="T">The type of Smart Form object</typeparam>
    public class ContentTypeManager<T> where T : class, new()
    {
        /// <summary>
        /// Reference to the Framework API Content Manager
        /// </summary>
        private ContentManager _contentManager;

        /// <summary>
        /// Reference to the Framework API access mode
        /// </summary>
        private Ektron.Cms.Framework.ApiAccessMode accessMode;

        /// <summary>
        /// Set the default Framework API access mode
        /// </summary>
        public ApiAccessMode AccessMode = ApiAccessMode.Admin;

        /// <summary>
        /// Add a smartform item to the cms.
        /// </summary>
        /// <param name="contentType">Smartform data</param>
        public void Add(ContentType<T> contentType)
        {
            this.Initialize();
            contentType.Content.Html = Ektron.Cms.EkXml.Serialize(typeof(T), contentType.SmartForm);
            this._contentManager.Add(contentType.Content);
        }
        
        /// <summary>
        /// Save the XML Smart Form content to the CMS
        /// </summary>
        /// <param name="contentType">The Smart Form object type</param>
        public void Update(ContentType<T> contentType)
        {
            Initialize();
            contentType.Content.Html = Ektron.Cms.EkXml.Serialize(typeof(T), contentType.SmartForm);
            _contentManager.Update(contentType.Content);
        }

        /// <summary>
        /// Remove the Smart Form content item from the CMS
        /// </summary>
        /// <param name="contentType">The Smart Form object type</param>
        public void Delete(ContentType<T> contentType)
        {
            Initialize();
            _contentManager.Delete(contentType.Content.Id);
        }

        /// <summary>
        /// Get the Smart Form content item from the CMS
        /// </summary>
        /// <param name="id">Content ID of the Smart Form item</param>
        /// <param name="includeMetadata">Should Metadata also be retrieved. Performance increase if false.</param>
        /// <returns>Content Type object of the Smart Form object type</returns>
        public ContentType<T> GetItem(long id, bool includeMetadata)
        {
            Initialize();

            ContentData contentItem = _contentManager.GetItem(id, includeMetadata);

            if (contentItem == null)
            {
                return EmptyContentType();
            }

            return Make(contentItem);
        }

        /// <summary>
        /// Get a generic list of Smart Form objects from the CMS
        /// </summary>
        /// <param name="criteria">The criteria by which the list will be filled</param>
        /// <returns>List of Smart Form objects</returns>
        public List<ContentType<T>> GetList(Ektron.Cms.Content.ContentCriteria criteria)
        {
            Initialize();

            List<ContentData> contentList = _contentManager.GetList(criteria);

            if (contentList == null)
            {
                return new List<ContentType<T>>();
            }

            return MakeList(contentList);
        }

        /// <summary>
        /// Get a generic list of Smart Form objects from the CMS
        /// </summary>
        /// <param name="criteria">The criteria by which the list will be filled</param>
        /// <returns>List of Smart Form objects</returns>
        public List<ContentType<T>> GetList(Ektron.Cms.Content.ContentTaxonomyCriteria criteria)
        {
            Initialize();

            List<ContentData> contentList = _contentManager.GetList(criteria);

            if (contentList == null)
            {
                return new List<ContentType<T>>();
            }

            return MakeList(contentList);
        }

        /// <summary>
        /// Public method for converting contentdata to a smartform object
        /// </summary>
        /// <param name="contentItem">content</param>
        /// <returns>smartform</returns>
        public ContentType<T> Convert(ContentData contentItem)
        {
            return this.Make(contentItem);
        }

        /// <summary>
        /// Public method for converting a list of contentdata objects to a smartform object
        /// </summary>
        /// <param name="contentList">content list</param>
        /// <returns>List of smartform objects</returns>
        public List<ContentType<T>> Convert(List<ContentData> contentList)
        {
            return this.MakeList(contentList);
        }

        /// <summary>
        /// Merge the Ektron ContentData object with the Smart Form data to make this object
        /// </summary>
        /// <param name="contentItem">Ektron ContentData item</param>
        /// <returns>The ContentType object for this Smart Form</returns>
        private ContentType<T> Make(ContentData contentItem)
        {
            ContentType<T> contentType;

            T smartForm = (T)Ektron.Cms.EkXml.Deserialize(typeof(T), contentItem.Html);

            contentType = new ContentType<T>();
            contentType.SmartForm = smartForm;
            contentType.Content = contentItem;

            return contentType;
        }

        /// <summary>
        /// Create a list of ContentType Smart Form objects
        /// </summary>
        /// <param name="contentList">List of ContentData objects</param>
        /// <returns>List of Smart Form ContentType objects</returns>
        private List<ContentType<T>> MakeList(List<ContentData> contentList)
        {
            List<ContentType<T>> list = new List<ContentType<T>>();
            foreach (ContentData contentItem in contentList)
            {
                ContentType<T> contentType = Make(contentItem);
                list.Add(contentType);
            }

            return list;
        }
      
        /// <summary>
        /// Initialize method
        /// </summary>
        private void Initialize()
        {
            if (_contentManager == null)
            {
                _contentManager = new ContentManager(AccessMode);
            }
        }

        private ContentType<T> EmptyContentType()
        {     
            ContentType<T> contentType = new ContentType<T>
            {
                Content = new ContentData(),
                SmartForm = new T()
            };            
            
            return contentType;
        }
    }
}