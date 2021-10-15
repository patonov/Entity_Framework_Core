using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Text.Json;
using System.Linq;

namespace XmlAndJsonPastedSpecialAsClasses
{
   //Json as Classes

    public class Rootobject
    {
        public Menu menu { get; set; }
    }

    public class Menu
    {
        public string id { get; set; }
        public string value { get; set; }
        public Popup popup { get; set; }
    }

    public class Popup
    {
        public Menuitem[] menuitem { get; set; }
    }

    public class Menuitem
    {
        public string value { get; set; }
        public string onclick { get; set; }
    }

    // Xml as Classes
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class widget
    {

        private string debugField;

        private widgetWindow windowField;

        private widgetImage imageField;

        private widgetText textField;

        /// <remarks/>
        public string debug
        {
            get
            {
                return this.debugField;
            }
            set
            {
                this.debugField = value;
            }
        }

        /// <remarks/>
        public widgetWindow window
        {
            get
            {
                return this.windowField;
            }
            set
            {
                this.windowField = value;
            }
        }

        /// <remarks/>
        public widgetImage image
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
        public widgetText text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class widgetWindow
    {

        private string nameField;

        private ushort widthField;

        private ushort heightField;

        private string titleField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public ushort width
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
        public ushort height
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
        public string title
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class widgetImage
    {

        private byte hOffsetField;

        private byte vOffsetField;

        private string alignmentField;

        private string srcField;

        private string nameField;

        /// <remarks/>
        public byte hOffset
        {
            get
            {
                return this.hOffsetField;
            }
            set
            {
                this.hOffsetField = value;
            }
        }

        /// <remarks/>
        public byte vOffset
        {
            get
            {
                return this.vOffsetField;
            }
            set
            {
                this.vOffsetField = value;
            }
        }

        /// <remarks/>
        public string alignment
        {
            get
            {
                return this.alignmentField;
            }
            set
            {
                this.alignmentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class widgetText
    {

        private string nameField;

        private byte hOffsetField;

        private byte vOffsetField;

        private string alignmentField;

        private string onMouseUpField;

        private string dataField;

        private byte sizeField;

        private string styleField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public byte hOffset
        {
            get
            {
                return this.hOffsetField;
            }
            set
            {
                this.hOffsetField = value;
            }
        }

        /// <remarks/>
        public byte vOffset
        {
            get
            {
                return this.vOffsetField;
            }
            set
            {
                this.vOffsetField = value;
            }
        }

        /// <remarks/>
        public string alignment
        {
            get
            {
                return this.alignmentField;
            }
            set
            {
                this.alignmentField = value;
            }
        }

        /// <remarks/>
        public string onMouseUp
        {
            get
            {
                return this.onMouseUpField;
            }
            set
            {
                this.onMouseUpField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string style
        {
            get
            {
                return this.styleField;
            }
            set
            {
                this.styleField = value;
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
