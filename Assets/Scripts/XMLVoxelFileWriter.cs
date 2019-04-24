using UnityEngine;
using System.Collections;
using System.Xml;

public class XMLVoxelFileWriter
{
    
    public static void SaveChunkToXML(int[ , , ]voxelArray ,string filename)
    {
        XmlWriterSettings writerSettings = new XmlWriterSettings();
        writerSettings.Indent = true;

        XmlWriter xmlWriter = XmlWriter.Create(filename + ".xml", writerSettings);

        xmlWriter.WriteStartDocument();

        xmlWriter.WriteStartElement("VoxelChunk");

        

        for (int x = 0; x<voxelArray.GetLength(0); x++)
        {
            for(int y = 0; y<voxelArray.GetLength(1); y++)
            {
                for(int z = 0; z<voxelArray.GetLength(1); z++)
                {
                    if(voxelArray[x,y,z]!=0)
                    {
                        xmlWriter.WriteStartElement("Voxel");

                        xmlWriter.WriteAttributeString("z", z.ToString());
                        xmlWriter.WriteAttributeString("y", y.ToString());
                        xmlWriter.WriteAttributeString("x", x.ToString());
                        
                        

                        xmlWriter.WriteString(voxelArray[x, y, z].ToString());

                        xmlWriter.WriteEndElement();
                    }
                }
            }
        }

        xmlWriter.WriteEndElement();
        xmlWriter.WriteEndDocument();
        xmlWriter.Close();

    }


    public static int[, ,] LoadChunkFromXML(int size, string fileName)
    {
        int[,,] voxelArray = new int[size, size, size];
        XmlReader xmlReader = XmlReader.Create(fileName + ".xml");

        while (xmlReader.Read())
        {
            if (xmlReader.IsStartElement("Voxel"))
            {
                int x = int.Parse(xmlReader["x"]);
                int y = int.Parse(xmlReader["y"]);
                int z = int.Parse(xmlReader["z"]);
                xmlReader.Read();
                int value = int.Parse(xmlReader.Value);
                voxelArray[x, y, z] = value;

            }

        }

        return voxelArray;
    }

}
