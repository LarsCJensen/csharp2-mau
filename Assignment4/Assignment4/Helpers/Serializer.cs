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
        public static string BinaryFileSerialize<T>(string path, List<T> objects, out string errorMsg)
        {
            FileStream fileStream = null;
            // I used this form because it was used in examples, but I would probably prefer to let errors fall through
            errorMsg = null;
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    errorMsg = $"Directory {Path.GetDirectoryName(path)} was not found!";
                    throw new FileNotFoundException(errorMsg);
                } else
                {
                    fileStream = new FileStream(path, FileMode.Create);
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(fileStream, objects);
                }                
            } 
            catch (Exception e)
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
            // I used this form because it was used in examples, but I would probably prefer to let errors fall through
            errorMsg = null;
            Object obj = null;
            try
            {
                if(!File.Exists(path))
                {
                    errorMsg = $"File {path} was not found!";
                    throw new FileNotFoundException(errorMsg);
                } else
                {
                    fileStream = new FileStream(path, FileMode.Open);
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    obj = binaryFormatter.Deserialize(fileStream);
                }                
            }
            catch (Exception e)
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
        /// <summary>
        /// A minimum effort to show serializing into text
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="objects"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static string TextFileSerialize<T>(string path, List<T> objects, out string errorMsg)
        {
            // I used this form because it was used in examples, but I would probably prefer to let errors fall through
            errorMsg = null;
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    errorMsg = $"Directory {Path.GetDirectoryName(path)} was not found!";
                    throw new FileNotFoundException(errorMsg);
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
            catch (Exception e) 
            {
                errorMsg = e.Message;
            }
            return errorMsg;
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
                    throw new FileNotFoundException(errorMsg);
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
        public static string[] TextFileDeSerialize<T>(string path, out string errorMsg)
        {
            // I used this form because it was used in examples, but I would probably prefer to let errors fall through
            errorMsg = null;
            string[] animalInfo = null;
            try
            {
                string info;
                using (FileStream fileStream = File.OpenRead(path))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream))
                    {
                        info = streamReader.ReadToEnd();                        
                    }
                    animalInfo = info.Replace("\r\n", "").Split("----");
                }
            }
            catch (Exception e)
            {
                if (errorMsg == null)
                {
                    errorMsg = e.Message;
                }

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
                // TODO check if location exists?
                using (FileStream fileStream = File.OpenRead(path))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream))
                    {
                        output = streamReader.ReadToEnd();
                    }
                }
                //obj = JsonConvert.DeserializeObject<T>(output);
            }
            catch (Exception e) 
            {
                errorMsg = e.Message;
            }
            return (List<T>)obj;
        }
        public static string XmlFileSerialize<T>(string path, List<T> objects, out string errorMsg)
        {
            // I used this form because it was used in examples, but I would probably prefer to let errors fall through
            errorMsg = null;
            TextWriter writer = null;
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    errorMsg = $"Directory {Path.GetDirectoryName(path)} was not found!";
                    throw new FileNotFoundException(errorMsg);
                } else
                {
                    writer = new StreamWriter(path);
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
                    xmlSerializer.Serialize(writer, objects);
                }                
            }
            catch (Exception e) 
            {
                errorMsg = e.ToString();
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
            // I used this form because it was used in examples, but I would probably prefer to let errors fall through
            errorMsg = null;
            Object objects = null;
            TextReader reader = null;
            try
            {
                if (!File.Exists(path))
                {
                    errorMsg = $"File {path} was not found!";
                    throw new FileNotFoundException(errorMsg);
                }
                reader = new StreamReader(path);
                objects =  (List<T>)xmlSerializer.Deserialize(reader);
            }
            catch (Exception e) 
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

