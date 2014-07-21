using System.Xml.Serialization;

namespace NewDevTraining
{

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", ElementName = "root", IsNullable = false)]
    public partial class FeaturedItem
    {

        private FeaturedItems[] featuredItemsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FeaturedItems")]
        public FeaturedItems[] FeaturedItems
        {
            get { return this.featuredItemsField; }
            set { this.featuredItemsField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class FeaturedItems
    {

        private string titleField;

        private Image featureImageField;

        private Imagealignment imagealignmentField;

        private string subTitleField;

        private rich featuresField;

        private Link moreDetailsLinkField;

        /// <remarks/>
        public string Title
        {
            get { return this.titleField; }
            set { this.titleField = value; }
        }

        /// <remarks/>
        public Image FeatureImage
        {
            get { return this.featureImageField; }
            set { this.featureImageField = value; }
        }

        /// <remarks/>
        public Imagealignment Imagealignment
        {
            get { return this.imagealignmentField; }
            set { this.imagealignmentField = value; }
        }

        /// <remarks/>
        public string SubTitle
        {
            get { return this.subTitleField; }
            set { this.subTitleField = value; }
        }

        /// <remarks/>
        public rich features
        {
            get { return this.featuresField; }
            set { this.featuresField = value; }
        }

        /// <remarks/>
        public Link MoreDetailsLink
        {
            get { return this.moreDetailsLinkField; }
            set { this.moreDetailsLinkField = value; }
        }
    }

}