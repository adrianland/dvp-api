using System.Xml;

namespace DVP.Project.Infrastructure.Finder.Util;

public static class SQLReader
{
    public static async Task<string> GetQuery(string query)
    {
        XmlTextReader xmlReader = new XmlTextReader(Directory.GetCurrentDirectory() + "/Configuration/queries.xml");
        var queryFounded = false;
        while (xmlReader.Read())
        {
            if (xmlReader.NodeType == XmlNodeType.Element)
            {
                while (xmlReader.MoveToNextAttribute())
                {
                    if (xmlReader.Value.Equals(query))
                    {
                        queryFounded = true;
                        break;
                    }
                }
            }
            if (queryFounded)
            {
                var line = xmlReader.Value.ToLower();
                if (line.Trim().Contains("select"))
                {
                    //_logger.Information(xmlReader.Value);
                    return xmlReader.Value;
                }
            }
        }

        return "";
    }
}