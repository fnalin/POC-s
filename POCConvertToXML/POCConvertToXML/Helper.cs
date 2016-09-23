using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace POCConvertToXML
{
    public static class Helper
    {

        public static string ToXML(this BaseSerializavel objeto)
        {
            var xml = string.Empty;
            try
            {
                var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

                var serializer = new XmlSerializer(objeto.GetType(), new XmlRootAttribute("ROOT"));

                var settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.OmitXmlDeclaration = true;


                using (var stream = new StringWriter())
                using (var writer = XmlWriter.Create(stream, settings))
                {
                    serializer.Serialize(writer, objeto, emptyNamepsaces);
                    xml =  stream.ToString();
                }


            }
            catch (Exception ex)
            {
                //Handle Exception Code
            }

            return xml;
        }

        public static object ToObject(this string xml, Type objectType) {
            Object obj = null;
            try
            {
                using (var strReader = new StringReader(xml))
                {
                    var serializer = new XmlSerializer(objectType, new XmlRootAttribute("ROOT"));
                    using (var xmlReader = new XmlTextReader(strReader))
                    {
                        obj= serializer.Deserialize(xmlReader);
                    }
                }
            }
            catch (Exception exp)
            {
                //Handle Exception Code
            }

            return obj;
        }
    }
}
