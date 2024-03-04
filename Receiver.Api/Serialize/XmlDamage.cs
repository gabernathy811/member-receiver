using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Receiver.Api.Serialize
{
    public class XmlDamage
    {
        [XmlElement(ElementName = "FacilityTypeDamaged")]
        public string FacilityTypeDamaged { get; set; }

        [XmlElement(ElementName = "TypeOfLine")]
        public string TypeOfLine { get; set; }

        [XmlElement(ElementName = "DamageExtent")]
        public string DamageExtent { get; set; }

        [XmlElement(ElementName = "ServiceIsOut")]
        public string ServiceIsOut { get; set; }

        [XmlElement(ElementName = "EquipmentTypeUsed")]
        public string EquipmentTypeUsed { get; set; }

        [XmlElement(ElementName = "IsCrewOnSite")]
        public string IsCrewOnSite { get; set; }

        [XmlElement(ElementName = "DamagedOnDate")]
        public string DamagedOnDate { get; set; }

    }
}
