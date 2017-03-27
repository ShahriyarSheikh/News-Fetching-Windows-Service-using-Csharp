using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Timers;


namespace qtwoserviceone
{
    public partial class Service1 : ServiceBase
    {
        System.Timers.Timer timeDelay;
        public Service1()
        {
            InitializeComponent();
            timeDelay = new Timer();
            timeDelay.Interval = (5000 * 60);
            timeDelay.Elapsed += new System.Timers.ElapsedEventHandler(readRSS);

           
        }

        protected override void OnStart(string[] args)
        {
            timeDelay.Enabled = true;
            
            
        }

        protected override void OnStop()
        {
            timeDelay.Enabled = false;
        }

        public void readRSS(object sender, ElapsedEventArgs e)
        {

            string url1 = "http://feeds.feedburner.com/GeoBulletins";
            string url2 = "https://tribune.com.pk/pakistan/sindh/feed/";
            XmlReader reader;
            reader = XmlReader.Create(url1);
            XmlReader reader2 = XmlReader.Create(url2);

            generateRSS(reader);
            generateRSS(reader2);
        
        }

        public void generateRSS(XmlReader reader)
        {

            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            foreach (SyndicationItem item in feed.Items)
            {
                //Please change the directory, i tried to include this in app.config but unfortunately there were some security errors
                // so i had to remove that idea and work with hardcoding
                // the rest works fine
                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\Shahriyar\Desktop\newsRSS.xml", true))
                {

                    file.WriteLine("<NewsItem>");
                    file.WriteLine("<Title>");
                    String subject = item.Title.Text;
                    file.WriteLine(subject);
                    file.WriteLine("</Title>");

                    file.WriteLine("<Summary>");
                    String summary = item.Summary.Text;
                    file.WriteLine(summary);
                    file.WriteLine("</Summary>");

                    file.WriteLine("<PubDate>");
                    String pubdate = item.PublishDate.DateTime.ToString();
                    file.WriteLine(pubdate);
                    file.WriteLine("</PubDate>");

                    file.WriteLine("<NewsChannel>");
                    //file.WriteLine(item.Authors.ToString());
                    file.WriteLine("</NewsChannel>");


                    file.WriteLine("</NewsItem>");

                }
            }

        }
    }
}
