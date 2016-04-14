using LinqXml.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Globalization;


namespace LinqXml.Controllers
{
    public class HomeController : Controller
    {

        private LinqXmlContext _context = new LinqXmlContext();
 

        public ActionResult Index()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\dene.xml");

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/billing/item");

            List<Kurlar> kurlars = new List<Kurlar>();
            string format = "ddd dd MMM h:mm tt yyyy";

            foreach(XmlNode node in nodes){

                var k = new Kurlar();
                k.ID = Int32.Parse(node.SelectSingleNode("id").InnerText);
                k.Name = node.SelectSingleNode("customer").InnerText;
                k.MeetingType = node.SelectSingleNode("type").InnerText;
                k.DurationInHours = Int32.Parse(node.SelectSingleNode("hours").InnerText);
                k.Contacts = int.Parse(node.SelectSingleNode("contact").InnerText);
             //   k.ID = node.Attributes["id"].Value.;
               kurlars.Add(k);
               _context.Kurlars.Add(k);
            }
         //   _context.SaveChanges();
            return View(kurlars);
        }



    /*      public ActionResult Create(Kurlar tstenty)
        {
            if (ModelState.IsValid)
            {
                _context.Kurlars.Add(tstenty);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tstenty);
        }


        public ActionResult Delete(int id = 0) {
            Kurlar test = _context.Kurlars.Find(id);  // o id ye ait nesneyi bulduk 
            if (test == null) {
                return HttpNotFound();
            }
            _context.Kurlars.Remove(test); // delete obje from db 
            _context.SaveChanges(); // save changes
            return RedirectToAction("Index"); // turn to index view
        }

        public ActionResult Update(Kurlar testentity)
        {

            if(ModelState.IsValid){
                _context.Entry(testentity).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testentity);
        }

        public ActionResult Details(int id = 0)
        {
            Kurlar testentity = _context.Kurlars.Find(id);
            if (testentity == null)
            {
                return HttpNotFound();
            }
            return View(testentity);
        }
        */
       /* public ActionResult Research(string lookfor) {

            var models = from s in _context.Kurlars
                           select s;
            if (!String.IsNullOrEmpty(lookfor))
            {
                models = models.Where(s => s.Name.ToUpper().Contains(lookfor.ToUpper())
                                       || s.Surname.ToUpper().Contains(lookfor.ToUpper()));
            }
            return View(models.ToList());
            /*var models = from s in _context.TestEntities
                        select s;

            if(!String.IsNullOrEmpty(lookfor)){
                models = models.Where(s => s.Surname.Contains(lookfor) || s.No.Contains(lookfor));
            }
        
            return View(models.ToList()); // bulduklarının listesini dönüyor
        }

    */

    }
}
