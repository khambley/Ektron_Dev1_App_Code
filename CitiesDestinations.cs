using System.Xml.Serialization;

namespace NewDevTraining
{

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", ElementName = "root", IsNullable = false)]
    public partial class CitiesandDestination
    {

        private CitiesandDestinations[] citiesandDestinationsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CitiesandDestinations")]
        public CitiesandDestinations[] citiesandDestinations
        {
            get
            {
                return this.citiesandDestinationsField;
            }
            set
            {
                this.citiesandDestinationsField = value;
            }
        }
    }


    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CitiesandDestinations
    {

        private string titleField;

        private Image imageField;

        private Imagealignment imagealignmentField;

        private string subTitleField;

        private string headingField;

        private rich descriptionField;

        /// <remarks/>
        public string Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        public Image Image
        {
            get
            {
                return this.imageField;
            }
            set
            {
                this.imageField = value;
            }
        }

        /// <remarks/>
        public Imagealignment Imagealignment
        {
            get
            {
                return this.imagealignmentField;
            }
            set
            {
                this.imagealignmentField = value;
            }
        }

        /// <remarks/>
        public string SubTitle
        {
            get
            {
                return this.subTitleField;
            }
            set
            {
                this.subTitleField = value;
            }
        }

        /// <remarks/>
        public string Heading
        {
            get
            {
                return this.headingField;
            }
            set
            {
                this.headingField = value;
            }
        }

        /// <remarks/>
        public rich Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    

    

}
