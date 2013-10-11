using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Hosting;

namespace Cph.Data
{
    public class DataCreator
    {
        public void Create()
        {
            using (var db = new CphDb())
            {
                if (db.Members.Any())
                {
                    return;
                }

                // social services
                var facebook = new SocialService
                    {
                        Name = "Facebook"
                    };
                var twitter = new SocialService
                    {
                        Name = "Twitter"
                    };
                var google = new SocialService
                    {
                        Name = "Google"
                    };
                var linkedin = new SocialService
                    {
                        Name = "LinkedIn"
                    };
                var github = new SocialService
                    {
                        Name = "GitHub"
                    };
                var bitbucket = new SocialService
                    {
                        Name = "Bitbucket"
                    };

                // members
                var eugene = new Member
                    {
                        FullName = "Eugene Kuzmin",
                        Position = "Team lead, developer",
                        Email = "eugene.kuzmin@creuna.com",
                        Photo = CreateLocalImage("http://goo.gl/hz3qJN"),
                        SocialLinks = new[]
                            {
                                new SocialLink {Service = facebook, Url = "https://www.facebook.com/milax"},
                                new SocialLink {Service = twitter, Url = "https://twitter.com/milax"},
                                new SocialLink {Service = google, Url = "https://plus.google.com/105449892652130958782/"},
                                new SocialLink {Service = linkedin, Url = "http://www.linkedin.com/in/eugenekuzmin"},
                                new SocialLink {Service = github, Url = "https://github.com/milax"},
                                new SocialLink {Service = bitbucket, Url = "https://bitbucket.org/milax"}
                            }
                    };
                var pavel = new Member
                    {
                        FullName = "Pavel Nezhencev",
                        Position = "Developer",
                        Email = "pavel.nezhencev@creuna.com",
                        Photo = CreateLocalImage("http://goo.gl/hHleIB"),
                        SocialLinks = new[]
                            {
                                new SocialLink {Service = twitter, Url = "https://twitter.com/pavelnezhencev"},
                                new SocialLink {Service = google, Url = "https://plus.google.com/u/0/113934605918189869048/"},
                                new SocialLink {Service = linkedin, Url = "http://www.linkedin.com/pub/pavel-nezhencev/4b/259/992"},
                                new SocialLink {Service = github, Url = "https://github.com/whyleee"},
                                new SocialLink {Service = bitbucket, Url = "https://bitbucket.org/whyleee"}
                            }
                    };
                var chris = new Member
                    {
                        FullName = "Christian Skjerning",
                        Position = "Project manager",
                        Email = "christian.skjerning@creuna.dk",
                        Photo = CreateLocalImage("http://goo.gl/JpeUpH"),
                        SocialLinks = new[]
                            {
                                new SocialLink {Service = facebook, Url = "https://www.facebook.com/christian.skjerning"},
                                new SocialLink {Service = google, Url = "https://plus.google.com/u/0/108080324039075355066/"},
                                new SocialLink {Service = linkedin, Url = "http://dk.linkedin.com/pub/christian-skjerning/3/4bb/792"}
                            }
                    };
                var dmitriyk = new Member
                    {
                        FullName = "Dmitriy Konovalov",
                        Position = "QA",
                        Email = "dmitriy.konovalov@creuna.com",
                        Photo = CreateLocalImage("http://goo.gl/EjcGOE"),
                        SocialLinks = new[]
                            {
                                new SocialLink {Service = facebook, Url = "https://www.facebook.com/people/Dmitriy-Konovalov/100000525312380"},
                                new SocialLink {Service = google, Url = "https://plus.google.com/u/0/115797605486221047446"},
                                new SocialLink {Service = linkedin, Url = "http://www.linkedin.com/pub/dmitrij-konovalov/39/aa0/b56"},
                                new SocialLink {Service = bitbucket, Url = "https://bitbucket.org/dmitriy_konovalov"}
                            }
                    };
                var elena = new Member
                    {
                        FullName = "Elena Pikaleva",
                        Position = "Developer",
                        Email = "elena.pikaleva@creuna.com",
                        Photo = CreateLocalImage("http://goo.gl/dNHE7S"),
                        SocialLinks = new[]
                            {
                                new SocialLink {Service = twitter, Url = "https://twitter.com/HelenPikaleva"},
                                new SocialLink {Service = google, Url = "https://plus.google.com/u/0/101953517997612024656/"},
                                new SocialLink {Service = github, Url = "https://github.com/ElenaP"}
                            }
                    };
                var dmitriym = new Member
                    {
                        FullName = "Dmitriy Martyscenko",
                        Position = "Developer",
                        Email = "dmitriy.martyscenko@creuna.com",
                        Photo = CreateLocalImage("http://goo.gl/m1fGtZ"),
                        SocialLinks = new[]
                            {
                                new SocialLink {Service = google, Url = "https://plus.google.com/u/0/114029184308754515242/"}
                            }
                    };
                var nick = new Member
                    {
                        FullName = "Nikolay Kush",
                        Position = "Developer",
                        Email = "nikolay.kush@creuna.com",
                        Photo = CreateLocalImage("http://goo.gl/WDSwMP"),
                        SocialLinks = new[]
                            {
                                new SocialLink {Service = facebook, Url = "https://www.facebook.com/nickolay.kush"},
                                new SocialLink {Service = twitter, Url = "https://twitter.com/_FoC_"},
                                new SocialLink {Service = google, Url = "https://plus.google.com/u/0/115983923736201689957/"},
                                new SocialLink {Service = linkedin, Url = "http://www.linkedin.com/pub/nikolay-kush/34/aa/826"},
                                new SocialLink {Service = github, Url = "https://github.com/FoC-"}
                            }
                    };

                db.Members.Add(eugene);
                db.Members.Add(pavel);
                db.Members.Add(chris);
                db.Members.Add(dmitriyk);
                db.Members.Add(elena);
                db.Members.Add(dmitriym);
                db.Members.Add(nick);

                db.SaveChanges();
            }
        }

        private string CreateLocalImage(string remoteImageUrl)
        {
            var imageUrl = "/img/" + Guid.NewGuid().ToString("N") + ".jpg";
            var imagePath = HostingEnvironment.MapPath(imageUrl);

            Directory.CreateDirectory(Path.GetDirectoryName(imagePath));
            new WebClient().DownloadFile(remoteImageUrl, imagePath);

            return imageUrl;
        }
    }
}