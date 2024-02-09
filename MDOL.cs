using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexibleEyeController
{
    public class MDOL
    {
        public static class Extension
        {
            static System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.InvariantCulture;
            public static float ToFloat(string text)
            {
                return float.Parse(text, culture);
            }
            public static double ToDouble(string text)
            {
                return double.Parse(text, culture);
            }
            public static int mod(int i, int divider)
            {
                int rem = i % divider;
                return rem >= 0 ? rem : mod(rem + divider, divider);
            }
            public static string ToStringF(float value, int decimalplaces = int.MaxValue)
            {
                if (decimalplaces != int.MaxValue)
                {
                    string format = "0.";
                    for (int i = 0; i < decimalplaces; i++)
                        format += "0";
                    return value.ToString(format, culture);
                }
                else
                    return value.ToString(culture);
            }
            public static double Sqr(double d)
            {
                return d * d;
            }
        }
        public static class Helper
        {
            public static void SetImage(System.Windows.Forms.Form form, System.Drawing.Bitmap bmp)
            {
                if (form.BackgroundImage != null)
                    form.BackgroundImage.Dispose();
                form.BackgroundImage = bmp;
            }
            public static void DrawCenteredString(System.Drawing.Image img, string String)
            {
                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(img))
                {
                    for (int i = 1; i < 1000; i++)
                    {
                        System.Drawing.Font font = new System.Drawing.Font(System.Drawing.FontFamily.Families.FirstOrDefault(family => family.Name.Contains("Arial")), i);
                        System.Drawing.SizeF size = g.MeasureString(String, font);
                        if (size.Width > img.Width || size.Height > img.Height)
                        {
                            font = new System.Drawing.Font(System.Drawing.FontFamily.Families.FirstOrDefault(family => family.Name.Contains("Arial")), i - 1);
                            size = g.MeasureString(String, font);
                            g.DrawString(String, font, System.Drawing.Brushes.Black, (img.Width - size.Width) / 2, (img.Height - size.Height) / 2);
                            break;
                        }
                    }
                }
            }
        }
        public class IO
        {
            public class XML
            {
                public readonly string mTag;
                readonly List<XML> mElements = new List<XML>();
                readonly string mValue = "";

                public static XML Read(string Filename)
                {
                    return new XML(System.IO.File.ReadAllText(Filename));
                }
                public XML(string Tag, string Value)
                {
                    mTag = Tag;
                    mValue = Value;
                }
                public XML(string Tag, params XML[] elements)
                {
                    mTag = Tag;
                    foreach (XML element in elements)
                        addElement(element);
                }
                public void addElement(XML element)
                {
                    mElements.Add(element);
                }
                public bool hasElement(string Tag)
                {
                    foreach (XML element in mElements)
                        if (element.mTag.Equals(Tag))
                            return true;
                    return false;
                }
                public List<XML> getElements()
                {
                    return mElements;
                }
                public XML getElement(string Tag, bool Contains = false)
                {
                    foreach (XML element in mElements)
                        if (element.mTag.Equals(Tag) || (Contains && element.mTag.Contains(Tag)))
                            return element;
                    return null;
                }
                public int getInt(string Tag, int def)
                {
                    if (hasElement(Tag))
                        return int.Parse(getElement(Tag).mValue);
                    else
                        return def;
                }
                public double getDouble(string Tag, double def)
                {
                    if (hasElement(Tag))
                        return Extension.ToDouble(getElement(Tag).mValue);
                    else
                        return def;
                }
                public float getFloat(string Tag, float def)
                {
                    if (hasElement(Tag))
                        return Extension.ToFloat(getElement(Tag).mValue);
                    else
                        return def;
                }
                public long getLong(string Tag, long def)
                {
                    if (hasElement(Tag))
                        return long.Parse(getElement(Tag).mValue);
                    else
                        return def;
                }
                public bool getBool(string Tag, bool def)
                {
                    if (hasElement(Tag))
                        return bool.Parse(getElement(Tag).mValue);
                    else
                        return def;
                }
                public string getString(string Tag, string def)
                {
                    if (hasElement(Tag))
                        return getElement(Tag).mValue;
                    else
                        return def;
                }

                readonly int iCurrent;
                public XML(string str) : this(str.Replace("\t", "").Replace("\r", "").Replace("\n", ""), 0)
                {
                }
                private XML(string str, int icurrent)
                {
                    if (str[0] != '<')
                    {
                        mTag = str;
                    }
                    else
                    {
                        iCurrent = icurrent;
                        int iStart = iCurrent + 1;
                        while (str[iCurrent] != '>')
                            iCurrent++;
                        int iEnd = iCurrent - 1;
                        iCurrent++;
                        mTag = str.Substring(iStart, iEnd + 1 - iStart);
                        if (str[iCurrent] == '<')
                        {
                            while (!str.Substring(iCurrent, mTag.Length + 3).Equals("</" + mTag + ">"))
                            {
                                XML element = new XML(str, iCurrent);
                                mElements.Add(element);
                                iCurrent = element.iCurrent;
                            }
                            iCurrent += mTag.Length + 3;
                        }
                        else
                        {
                            iStart = iCurrent;
                            while (!str.Substring(iCurrent, mTag.Length + 3).Equals("</" + mTag + ">"))
                            {
                                iCurrent++;
                            }
                            iEnd = iCurrent - 1;
                            mValue = str.Substring(iStart, iEnd + 1 - iStart);
                            iCurrent += mTag.Length + 3;
                        }
                    }
                }

                public override string ToString()
                {
                    string str = "<" + mTag + ">";
                    if (mElements.Count == 0)
                        str += mValue;
                    else
                        foreach (XML value in mElements)
                        {
                            str += value.ToString();
                        }
                    str += "</" + mTag + ">";
                    return str;
                }

                public string ToString(int Indent)
                {
                    string str = "";
                    for (int i = 0; i < Indent; i++)
                        str += "\t";
                    str += "<" + mTag + ">\r\n";
                    if (mElements.Count == 0)
                    {
                        for (int i = 0; i < Indent + 1; i++)
                            str += "\t";
                        str += mValue + "\r\n";
                    }
                    else
                        foreach (XML value in mElements)
                            str += value.ToString(Indent + 1);
                    for (int i = 0; i < Indent; i++)
                        str += "\t";
                    str += "</" + mTag + ">\r\n";
                    return str;
                }

                public static XML[] ToXML<T>(T t)
                {
                    System.Reflection.FieldInfo[] fields = t.GetType().GetFields();
                    return fields.Select(field =>
                    {
                        return new XML(field.Name, field.GetValue(t).ToString());
                    }).ToArray();
                }
                public static T FromXML<T>(XML xml) where T : new()
                {
                    System.Reflection.FieldInfo[] fields = typeof(T).GetFields();
                    T t = new T();

                    foreach (System.Reflection.FieldInfo field in fields)
                        if (field.FieldType == typeof(int))
                            field.SetValue(t, xml.getInt(field.Name, -1));
                        else if (field.FieldType == typeof(double))
                            field.SetValue(t, xml.getDouble(field.Name, double.NaN));
                        else if (field.FieldType == typeof(float))
                            field.SetValue(t, xml.getFloat(field.Name, float.NaN));
                        else if (field.FieldType == typeof(bool))
                            field.SetValue(t, xml.getBool(field.Name, false));
                        else if (field.FieldType == typeof(long))
                            field.SetValue(t, xml.getLong(field.Name, -1));
                        else if (field.FieldType == typeof(string))
                            field.SetValue(t, xml.getString(field.Name, null));
                        else if (field.FieldType.IsEnum)
                            field.SetValue(t, Enum.Parse(field.FieldType, xml.getString(field.Name, null)));
                        else
                            throw new TypeAccessException();
                    return t;
                }
                public static void SetFromXML<T>(XML xml, T t)
                {
                    System.Reflection.FieldInfo[] fields = t.GetType().GetFields();
                    foreach (System.Reflection.FieldInfo field in fields)
                        if (field.FieldType == typeof(int))
                            field.SetValue(t, xml.getInt(field.Name, -1));
                        else if (field.FieldType == typeof(double))
                            field.SetValue(t, xml.getDouble(field.Name, double.NaN));
                        else if (field.FieldType == typeof(float))
                            field.SetValue(t, xml.getFloat(field.Name, float.NaN));
                        else if (field.FieldType == typeof(bool))
                            field.SetValue(t, xml.getBool(field.Name, false));
                        else if (field.FieldType == typeof(long))
                            field.SetValue(t, xml.getLong(field.Name, -1));
                        else if (field.FieldType == typeof(string))
                            field.SetValue(t, xml.getString(field.Name, null));
                        else if (field.FieldType.IsEnum)
                            field.SetValue(t, Enum.Parse(field.FieldType, xml.getString(field.Name, null)));
                        else
                            throw new TypeAccessException();
                }
            }
        }
    }
}