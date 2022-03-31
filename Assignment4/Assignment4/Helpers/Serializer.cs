using Assignment4.Animals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Assignment4.Birds;
using Assignment4.Insects;
using Assignment4.Mammals;
using Assignment4.Reptiles;

namespace Assignment4.Helpers
{
    public static class Serializer
    {
        public static void BinaryFileSerialize<T>(string path, T obj)
        {
            FileStream fileStream = null;
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    throw new SerializerException($"Directory {Path.GetDirectoryName(path)} was not found!");
                } else
                {
                    fileStream = new FileStream(path, FileMode.Create);
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(fileStream, obj);
                }                
            }
            // Make sure filestream is closed, but let error go up the callstack
            finally
            {
                if(fileStream != null)
                {
                    fileStream.Close();
                }
            }            
        }
        public static T BinaryFileDeSerialize<T>(string path)
        {
            FileStream fileStream = null;
            // I used this form because it was used in examples, but I would probably prefer to let errors fall through
            Object obj = null;
            try
            {
                if(!File.Exists(path))
                {
                    throw new SerializerException($"File {path} was not found!");
                } else
                {
                    fileStream = new FileStream(path, FileMode.Open);
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    obj = binaryFormatter.Deserialize(fileStream);
                }                
            }            
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
            return (T)obj;
        }
        /// <summary>
        /// A minimum effort to show serializing into text
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static void TextFileSerialize<T>(string path, List<T> objects)
        {
            // In this case I let errors fall through
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {                    
                throw new SerializerException($"Directory {Path.GetDirectoryName(path)} was not found!");
            }
            else
            {
                using (FileStream fileStream = File.Create(path))
                {
                    using (StreamWriter streamWriter = new StreamWriter(fileStream))
                    {
                        for (int i = 0; i < objects.Count; i++)
                        {                            
                            streamWriter.WriteLine(objects[i].ToString());
                            // Using a delimiter to know where to split animal info
                            streamWriter.WriteLine("----");
                        }
                    }
                }
            }                        
        }
        /// <summary>
        /// WIP: Was trying to figure out a nice way of serializing the animals
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">Path to file</param>
        /// <param name="objects">List of objects</param>
        /// <param name="errorMsg">Error output</param>
        /// <returns>Creates file with two rows per object</returns>
        public static string TextFileSerializeProper<T>(string path, List<T> objects, out string errorMsg)
        {
            // I used this form because it was used in examples, but I would probably prefer to let errors fall through
            errorMsg = null;
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    errorMsg = $"Directory {Path.GetDirectoryName(path)} was not found!";
                    throw new SerializerException(errorMsg);
                } else
                {
                    using (FileStream fileStream = File.Create(path))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(fileStream))
                        {                            
                            for(int i = 0; i < objects.Count;i++)
                            {
                                //streamWriter.WriteLine(ListManager<T>.GetTypeHeaders(objects[i]));
                                var typeName = (object)objects[i].GetType().Name;
                                switch (typeName)
                                {
                                    case "Blackbird":
                                        streamWriter.WriteLine(((Blackbird)(object)objects[i]).SerializeToText());
                                        break;
                                    case "Swallow":
                                        streamWriter.WriteLine(((Swallow)(object)objects[i]).SerializeToText());
                                        break;
                                    case "Bee":
                                        streamWriter.WriteLine(((Bee)(object)objects[i]).SerializeToText());
                                        break;
                                    case "Butterfly":
                                        //streamWriter.WriteLine(GetHeadersForObject((Butterfly)(object)objects[i]));
                                        streamWriter.WriteLine(((Butterfly)(object)objects[i]).SerializeToText());
                                        break;
                                    case "Cat":
                                        streamWriter.WriteLine(((Cat)(object)objects[i]).SerializeToText());
                                        break;
                                    case "Dog":
                                        streamWriter.WriteLine(((Dog)(object)objects[i]).SerializeToText());
                                        break;
                                    case "Elephant":
                                        streamWriter.WriteLine(((Elephant)(object)objects[i]).SerializeToText());
                                        break;
                                    case "Horse":
                                        streamWriter.WriteLine(((Horse)(object)objects[i]).SerializeToText());
                                        break;
                                    case "Crocodile":
                                        streamWriter.WriteLine(((Crocodile)(object)objects[i]).SerializeToText());
                                        break;
                                    case "Snake":
                                        streamWriter.WriteLine(((Snake)(object)objects[i]).SerializeToText());
                                        break;
                                }
                            }
                        }
                    }
                }                
            }
            catch (Exception e)
            {
                errorMsg = e.Message;
            }            
            return errorMsg;
        }       

        /// <summary>
        /// Opens saved animal info
        /// </summary>
        /// <typeparam name="T">Type of object, but not used as it returns string</typeparam>
        /// <param name="path"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static string[] TextFileDeSerialize<T>(string path)
        {
            // I used this form because it was used in examples, but I would probably prefer to let errors fall through
            string[] animalInfo = null;
            
            string info;
            using (FileStream fileStream = File.OpenRead(path))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    info = streamReader.ReadToEnd();                        
                }
                animalInfo = info.Replace("\r\n", "").Split("----");
            }                        
            return animalInfo;
        }
        /// <summary>
        /// WIP: Was trying to figure out a nice way of de-serializing the animals
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static List<T> TextFileDeSerializeProper<T>(string path, out string errorMsg)
        {
            errorMsg = null;
            Object obj = null;
            string output;
            try
            {
                using (FileStream fileStream = File.OpenRead(path))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream))
                    {
                        output = streamReader.ReadToEnd();
                    }
                }
                // TODO
            }
            catch (Exception e) 
            {
                errorMsg = e.Message;
            }
            return (List<T>)obj;
        }
        public static void XmlFileSerialize<T>(string path, T obj)
        {
            // I used this form because it was used in examples, but I would probably prefer to let errors fall through
            TextWriter writer = null;
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    throw new SerializerException($"Directory {Path.GetDirectoryName(path)} was not found!");
                } else
                {
                    writer = new StreamWriter(path);
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(writer, obj);
                }                
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
        public static T XmlFileDeSerialize<T>(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            // I used this form because it was used in examples, but I would probably prefer to let errors fall through
            Object obj = null;
            TextReader reader = null;
            try
            {
                if (!File.Exists(path))
                {
                    throw new SerializerException($"File {path} was not found!");
                }
                reader = new StreamReader(path);
                obj =  (T)xmlSerializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return (T)obj;
        }
    }
}

