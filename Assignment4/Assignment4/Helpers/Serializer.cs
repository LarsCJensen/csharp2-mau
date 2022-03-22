using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment4.Helpers
{
    public static class Serializer
    {
        public static string BinaryFileSerialize<T>(string path, List<T> objects, out string errorMsg)
        {
            FileStream fileStream = null;
            errorMsg = null;
            try
            {
                // TODO check if location exists?
                fileStream = new FileStream(path, FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, objects);
            } 
            catch (Exception e) // TODO Narrow error down
            {
                errorMsg = e.Message;
            }
            finally
            {
                if(fileStream != null)
                {
                    fileStream.Close();
                }
            }
            return errorMsg;
        }
        public static List<T> BinaryFileDeSerialize<T>(string path, out string errorMsg)
        {
            FileStream fileStream = null;
            errorMsg = null;
            Object obj = null;
            try
            {
                if(!File.Exists(path))
                {
                    errorMsg = $"File {path} was not found!";
                    throw (new FileNotFoundException(errorMsg));
                }
                fileStream = new FileStream(path, FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                obj = binaryFormatter.Deserialize(fileStream);
            }
            catch (Exception e) // TODO Narrow error down
            {
                if(errorMsg == null)
                {
                    errorMsg = e.Message;
                }
                
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
            return (List<T>)obj;
        }
        public static string TextFileSerialize<T>(string path, List<T> objects, out string errorMsg)
        {
            errorMsg = null;
            try
            {
                // TODO check if location exists?
                using(FileStream fileStream = File.Create(path))
                {
                    using(StreamWriter streamWriter = new StreamWriter(fileStream))
                    {
                        foreach(T obj in objects)
                        {
                            streamWriter.WriteLine(obj);
                        }                        
                    }
                }                
            }
            catch (Exception e) // TODO Narrow error down
            {
                errorMsg = e.Message;
            }
            
            return errorMsg;
        }
        public static List<T> TextFileDeSerialize<T>(string path, out string errorMsg)
        {
            throw new NotImplementedException();
            //errorMsg = null;
            //try
            //{
            //    // TODO check if location exists?
            //    using (FileStream fileStream = File.OpenRead(path))
            //    {
            //        using (StreamReader streamReader= new StreamReader(fileStream))
            //        {
            //            // TODO HOW TO READ BACK TO OBJECTS?
            //            streamReader.ReadToEnd();
            //        }
            //    }
            //}
            //catch (Exception e) // TODO Narrow error down
            //{
            //    errorMsg = e.Message;
            //}
            //return errorMsg;
        }
        public static string XmlFileSerialize<T>(string path, List<T> objects, out string errorMsg)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
            TextWriter writer = new StreamWriter(path);
            errorMsg = null;
            try
            {
                xmlSerializer.Serialize(writer, objects);
            }
            catch (Exception e) // TODO Narrow error down
            {
                errorMsg = e.Message;
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
            return errorMsg;
        }
        public static List<T> XmlFileDeSerialize<T>(string path, out string errorMsg)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
            errorMsg = null;
            Object objects = null;
            TextReader reader = null;
            try
            {
                if (!File.Exists(path))
                {
                    errorMsg = $"File {path} was not found!";
                    throw (new FileNotFoundException(errorMsg));
                }
                reader = new StreamReader(path);
                objects =  (List<T>)xmlSerializer.Deserialize(reader);
            }
            catch (Exception e) // TODO Narrow error down
            {
                errorMsg = e.Message;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return (List<T>)objects;
        }
    }
}
