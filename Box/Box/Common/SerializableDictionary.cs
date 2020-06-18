using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.IO;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
namespace Game.Box
{
    [Serializable]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ICustomXmlSerializable
    {
        bool valueTypeIsNullable = false;
        Type valueBaseType = null;
        public SerializableDictionary()
        {
            valueTypeIsNullable = typeof(TValue).IsGenericType
                && typeof(TValue).GetGenericTypeDefinition().Equals(typeof(System.Nullable<>));
            if (valueTypeIsNullable)
            {
                valueBaseType = typeof(TValue).GetGenericArguments()[0];
            }
        }
        public SerializableDictionary(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        public new TValue this[TKey key]
        {
            get { return base[key]; }
            set 
            {
                base[key] = value;
                if (ItemAddEventHandler != null) ItemAddEventHandler(new KeyValuePair<TKey, TValue>(key, value));
            }
        }
        public void WriteXml(XmlWriter writer)
        {
            foreach (KeyValuePair<TKey, TValue> pair in this)
            {
                writer.WriteStartElement("pair");
                if (valueTypeIsNullable)
                {
                    if (pair.Value == null)
                        writer.WriteAttributeString(pair.Key.ToString(), string.Empty);
                    else
                        writer.WriteAttributeString(pair.Key.ToString(), pair.Value.ToString());
                }
                else
                {
                    writer.WriteStartElement("key");
                    new XmlSerializer(typeof(TKey)).Serialize(writer, pair.Key);
                    writer.WriteEndElement();
                    writer.WriteStartElement("value");
                    new XmlSerializer(typeof(TValue)).Serialize(writer, pair.Value);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }

        public void ReadXml(XmlReader reader)
        {
            this.Clear();
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();
            if (wasEmpty) return;
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                reader.ReadStartElement("pair");
                reader.ReadStartElement("key");
                TKey key = (TKey)(keySerializer.Deserialize(reader));
                reader.ReadEndElement();
                reader.ReadStartElement("value");
                TValue value = (TValue)(valueSerializer.Deserialize(reader));
                reader.ReadEndElement();
                Add(key, value);
                reader.ReadEndElement();
                reader.MoveToContent();
            }
            reader.ReadEndElement();
        }
        public string XML
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                XmlTextWriter w = new XmlTextWriter(new StringWriter(sb));
                this.WriteXml(w);
                return sb.ToString();
            }
            set
            {
                XmlTextReader r = new XmlTextReader(new StringReader(value));
                this.ReadXml(r);
            }
        }
        public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            if (ItemAddEventHandler != null) ItemAddEventHandler(new KeyValuePair<TKey, TValue>(key, value));
        }
        private Action<KeyValuePair<TKey, TValue>> ItemAddEventHandler;
        public event Action<KeyValuePair<TKey, TValue>> ItemAdd
        {
            add { this.ItemAddEventHandler += value; }
            remove { this.ItemAddEventHandler -= value; }
        }
        public XmlSchema GetSchema()
        {
            return null;
        }
    }

    public interface ICustomXmlSerializable : IXmlSerializable
    {
        string XML { get; set; }
    }
}
