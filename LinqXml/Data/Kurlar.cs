using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinqXml.Data
{
    [Table("tblKurlar")]
    public class Kurlar
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string MeetingType { get; set; }
        public DateTime CallDate { get; set; }
        public int DurationInHours { get; set; }
        public int Contacts { get; set; }
    }
}