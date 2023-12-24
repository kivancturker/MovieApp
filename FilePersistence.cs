using System.Text.Json;
using System.Xml.Serialization;

namespace MovieApp;

public class FilePersistence<TEntity>
{
    private XmlSerializer _serializer;
    private string _fileName;
    
    public FilePersistence(string fileName)
    {
        _serializer = new XmlSerializer(typeof(List<TEntity>));
        _fileName = fileName;
    }
    
    public void WriteToFile(List<TEntity> datas)
    {
        CreateFileIfNotExist();
        StreamWriter sw = new StreamWriter(_fileName);
        using (sw)
        {
            _serializer.Serialize(sw, datas);
        }
    }

    private void CreateFileIfNotExist()
    {
        if (!File.Exists(_fileName))
        {
            using (StreamWriter sw = File.CreateText(_fileName)) { }
        }
    }

    public List<TEntity>? ReadFromFile()
    {   
        if (!File.Exists(_fileName))
            return new List<TEntity>();
        StreamReader sr = new StreamReader(_fileName);
        using (sr)
        {
            return (List<TEntity>?)_serializer.Deserialize(sr);
        }
    }
}