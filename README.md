# News-Fetching-Windows-Service-using-Csharp

RSS feeds enable publishers to syndicate data automatically. A standard XML file format ensures compatibility with many different machines/programs. RSS feeds also benefit users who want to receive timely updates from favorite websites or to aggregate data from many sites.I created a Windows Service which reads RSS feeds every 5 minutes from any two of the Pakistani New Web Site. The output is stored in one xml file sorted in descending order of date/time. The output format is similar to what is shown below: 

<NewsItem> 
<Title></Title> 
<Description></Description> 
<PublishedDate></PublishedDate> 
<NewsChannel></NewsChannel> 
</NewsItem>
