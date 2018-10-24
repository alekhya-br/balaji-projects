using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        InvestmentEntities1 myInvestment = new InvestmentEntities1();
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult GetRegistration()
        {
            var registrantQuery = from eachRegistrant in myInvestment.RegistrantAddresses
                                   join eachSeries in myInvestment.Series on eachRegistrant.SeriesID
                                   equals eachSeries.SeriesID
                                   where eachRegistrant.City == "New York"
                                  select new
                                  {eachRegistrant.NameofRegistrant,
                                   eachSeries.SeriesName};


            List<Registration> myRegistrants = new List<Registration>();

            foreach (var item in registrantQuery)
            {
                Registration nextRegistrant = new Registration();
                nextRegistrant.NameofRegistrant = item.NameofRegistrant;
                nextRegistrant.SeriesName = item.SeriesName;
                myRegistrants.Add(nextRegistrant);
            }            
            ViewBag.Registrant = myRegistrants;
            return View();
        }

        public ActionResult GetSeries()
        {
            var seriesQuery = from eachSeries in myInvestment.Series
                              join eachRegistrant in myInvestment.RegistrantAddresses
                              on eachSeries.SeriesID equals eachRegistrant.SeriesID
                              join eachClass in myInvestment.Classes 
                              on eachRegistrant.AddressID equals eachClass.AddressID
                              where eachClass.ClassName == "Class A"
                              select new
                              {
                                  eachSeries.SeriesName
                              };



            List<Series> mySeries = new List<Series>();

            foreach (var item in seriesQuery)
            {
                Series nextSeries = new Series();
                nextSeries.SeriesName = item.SeriesName;
                mySeries.Add(nextSeries);
            }
            ViewBag.SeriesClass = mySeries;

            return View();
        }

        public ActionResult GetSerRegClas()
        {
            var seriesQuery = from eachSeries in myInvestment.Series
                              join eachRegistrant in myInvestment.RegistrantAddresses
                              on eachSeries.SeriesID equals eachRegistrant.SeriesID
                              join eachClass in myInvestment.Classes
                              on eachRegistrant.AddressID equals eachClass.AddressID
                              select new
                              {
                                  eachRegistrant.NameofRegistrant,
                                  eachSeries.SeriesName,
                                  eachClass.ClassName
                              };



            List<RegSerClas> myRegSerClas = new List<RegSerClas>();

            foreach (var item in seriesQuery)
            {
                RegSerClas nextSeries = new RegSerClas();
                nextSeries.NameofRegistrant = item.NameofRegistrant;
                nextSeries.SeriesName = item.SeriesName;
                nextSeries.ClassName = item.ClassName;
                myRegSerClas.Add(nextSeries);
            }
            ViewBag.SerReg = myRegSerClas;

            return View();
        }
    }
}