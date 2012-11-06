﻿using System;
using System.Xml;
using System.Xml.Linq;

namespace Umbraco.Core.Models
{
    public static class PropertyExtensions
    {
        /// <summary>
        /// Creates the xml representation for the <see cref="Property"/> object
        /// </summary>
        /// <param name="property"><see cref="Property"/> to generate xml for</param>
        /// <returns>Xml of the property and its value</returns>
        public static XElement ToXml(this Property property)
        {
            string nodeName = property.Alias.ToUmbracoAlias();

            var xd = new XmlDocument();
            XmlNode xmlNode = xd.CreateNode(XmlNodeType.Element, nodeName, "");
            xmlNode.AppendChild(property.PropertyType.DataType(property.Id).Data.ToXMl(xd));

            var element = xmlNode.GetXElement();
            return element;
        }
    }
}