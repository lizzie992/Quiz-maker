using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quiz_maker
{
    public class Serializer
    {

        public static XmlSerializer serializer = new XmlSerializer(typeof(List<Quiz>));
        

    }
}
