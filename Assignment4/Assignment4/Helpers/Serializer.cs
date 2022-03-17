using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Helpers
{
    public static class Serializer
    {
        public static string BinaryFileSerialize<T>(string path, List<T> obj, out string errorMsg)
        {
            FileStream fileStream = null;
            errorMsg = null;
            try
            {
                // TODO check if location exists?
                fileStream = new FileStream(path, FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, obj);
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
        public static string BinaryFileDeSerialize<T>(string path, out string errorMsg)
        {
            FileStream fileStream = null;
            errorMsg = null;
            Object obj = null;
            try
            {
                if(!File.Exists(path))
                {

                }
                fileStream = new FileStream(path, FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, obj);
            }
            catch (Exception e) // TODO Narrow error down
            {
                errorMsg = e.Message;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
            return errorMsg;
        }
    }
}
