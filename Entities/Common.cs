// -----------------------------------------------------------------------
// Common Smartform elements
// ------------------------------------------------------------------------

using System.Text;

namespace NewDevTraining
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class Link
    {
        private Anchor anchorField;
        [System.Xml.Serialization.XmlElementAttribute("a")]
        public Anchor Anchor
        {
            get
            {
                return this.anchorField;
            }
            set
            {
                this.anchorField = value;
            }
        }

        public string GetTag()
        {
            if (anchorField != null)
            {
                return anchorField.ToString();
            }
            else
            {
                return "<a></a>";
            }
        }
    }

    [System.SerializableAttribute()]
    public partial class Anchor
    {
        private System.Xml.XmlNode[] anyField;

        private string hrefField;
        private string targetField;
        private string tooltipField;

        [System.Xml.Serialization.XmlTextAttribute()]
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlNode[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        public string Title
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (this.anyField != null)
                {
                    foreach (System.Xml.XmlNode item in this.anyField)
                    {
                        sb.Append(item.OuterXml);
                    }
                }
                return sb.ToString();
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string href
        {
            get
            {
                if (string.IsNullOrEmpty(hrefField))
                {
                    return "";
                }
                else
                {
                    return this.hrefField;
                }
            }
            set
            {
                this.hrefField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
        public string target
        {
            get
            {
                if (string.IsNullOrEmpty(targetField))
                {
                    return "";
                }
                else
                {
                    return this.targetField;
                }
            }
            set
            {
                this.targetField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN", AttributeName = "title")]
        public string ToolTip
        {
            get
            {
                if (string.IsNullOrEmpty(tooltipField))
                {
                    return "";
                }
                else
                {
                    return this.tooltipField;
                }
            }
            set
            {
                this.tooltipField = value;
            }
        }
        
        public override string ToString()
        {
            return "<a href='" + href + "' target='" + target + "'>" + Title + "</a>";
        }
    }

    [System.SerializableAttribute()]
    public partial class rich
    {
        private System.Xml.XmlNode[] anyField;

        [System.Xml.Serialization.XmlTextAttribute()]
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlNode[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.anyField != null)
            {
                foreach (System.Xml.XmlNode item in this.anyField)
                {
                    sb.Append(item.OuterXml);
                }
            }
            return sb.ToString();
        }
    }

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class Image
    {
        private ImageTag imageTagField;

        [System.Xml.Serialization.XmlElementAttribute("img")]
        public ImageTag ImageTag
        {
            get
            {
                return this.imageTagField;
            }
            set
            {
                this.imageTagField = value;
            }
        }
    }

    [System.SerializableAttribute()]
    public partial class ImageTag
    {

        private string srcField;

        private string altField;

        private string heightField;

        private string widthField;

        private ImageAlign imageAlignField;

        private bool alignFieldSpecified;

        private string borderField;

        private string hspaceField;

        private string vspaceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string src
        {
            get
            {
                return this.srcField;
            }
            set
            {
                this.srcField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string alt
        {
            get
            {
                return this.altField;
            }
            set
            {
                this.altField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "align")]
        
        public ImageAlign Align
        {
            get
            {
                return this.imageAlignField;
            }
            set
            {
                this.imageAlignField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool alignSpecified
        {
            get
            {
                return this.alignFieldSpecified;
            }
            set
            {
                this.alignFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string border
        {
            get
            {
                return this.borderField;
            }
            set
            {
                this.borderField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "nonNegativeInteger")]
        public string hspace
        {
            get
            {
                return this.hspaceField;
            }
            set
            {
                this.hspaceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "nonNegativeInteger")]
        public string vspace
        {
            get
            {
                return this.vspaceField;
            }
            set
            {
                this.vspaceField = value;
            }
        }
    }

    [System.SerializableAttribute()]
    public enum ImageAlign
    {

        /// <remarks/>
        top,

        /// <remarks/>
        middle,

        /// <remarks/>
        bottom,

        /// <remarks/>
        left,

        /// <remarks/>
        right,
    }

    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FolderSelector))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ContentSelector))]
    [System.SerializableAttribute()]
    public partial class ResourceSelector
    {
        private string datavalue_idtypeField;

        private string datavalue_displayvalueField;

        private long valueField;

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
        public string datavalue_idtype
        {
            get
            {
                return this.datavalue_idtypeField;
            }
            set
            {
                this.datavalue_idtypeField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string datavalue_displayvalue
        {
            get
            {
                return this.datavalue_displayvalueField;
            }
            set
            {
                this.datavalue_displayvalueField = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute()]
        public long Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    [System.SerializableAttribute()]
    public partial class FolderSelector : ResourceSelector
    {
    }

    [System.SerializableAttribute()]
    public partial class ContentSelector : ResourceSelector
    {
    }


    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public enum Imagealignment
    {

        /// <remarks/>
        Left,

        /// <remarks/>
        Right,
    }

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public enum PriceUnit
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("$")]
        Dollor,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("£")]
        Pound,
        [System.Xml.Serialization.XmlEnumAttribute("Select")]
        Select
    }
}
