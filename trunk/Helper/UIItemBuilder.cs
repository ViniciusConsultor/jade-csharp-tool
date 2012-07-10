using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.Specialized;

namespace HFBBS
{
    public class EncodingUIBuilder
    {
        private static List<string> encodingList;

        public static List<string> EncodingList
        {
            get
            {
                if(encodingList == null)
                {
                    FileStream stream = File.OpenRead(HFBBS.Properties.Settings.Default.EncodingFilePath);
                    StreamReader reader = new StreamReader(stream);
                    encodingList = new List<string>();
                    
                    while (!reader.EndOfStream)
                    {
                        encodingList.Add(reader.ReadLine());
                    }

                    stream.Close();
                    reader.Close();
                }

                return encodingList;
            }
        }
    }
}
