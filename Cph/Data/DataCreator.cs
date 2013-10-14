using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Hosting;

namespace Cph.Data
{
    public class DataCreator : DropCreateDatabaseIfModelChanges<CphDb>
    {
        protected override void Seed(CphDb db)
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
            var stackoverflow = new SocialService
                {
                    Name = "StackOverflow"
                };

            // members, CPH
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
                            new SocialLink {Service = bitbucket, Url = "https://bitbucket.org/milax"},
                            new SocialLink {Service = stackoverflow, Url = "http://stackoverflow.com/users/883631/eugene-kuzmin"}
                        }
                };
            var pavel = new Member
                {
                    FullName = "Pavel Nezhencev",
                    Position = "Developer",
                    Email = "pavel.nezhencev@creuna.com",
                    Photo = CreateLocalImage("http://goo.gl/fnXFFJ"),
                    SocialLinks = new[]
                        {
                            new SocialLink {Service = twitter, Url = "https://twitter.com/pavelnezhencev"},
                            new SocialLink {Service = google, Url = "https://plus.google.com/u/0/113934605918189869048/"},
                            new SocialLink {Service = linkedin, Url = "http://www.linkedin.com/pub/pavel-nezhencev/4b/259/992"},
                            new SocialLink {Service = github, Url = "https://github.com/whyleee"},
                            new SocialLink {Service = bitbucket, Url = "https://bitbucket.org/whyleee"},
                            new SocialLink {Service = stackoverflow, Url = "http://stackoverflow.com/users/544587/whyleee"}
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
                            new SocialLink {Service = bitbucket, Url = "https://bitbucket.org/dmitriy_konovalov"},
                            new SocialLink {Service = stackoverflow, Url = "http://stackoverflow.com/users/1872045/dmitriy-konovalov"}
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
                            new SocialLink {Service = github, Url = "https://github.com/ElenaP"},

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
                            new SocialLink {Service = github, Url = "https://github.com/FoC-"},
                            new SocialLink {Service = stackoverflow, Url = "http://stackoverflow.com/users/1095657/foc"}
                        }
                };

            // members, others
            var mads = new Member
                {
                    FullName = "Mads Hofman Hansen",
                    Position = "Project manager",
                    Email = "mads.hofman@creuna.dk",
                    Photo = CreateLocalImage("http://goo.gl/RGXb7o"),
                    SocialLinks = new[]
                        {
                            new SocialLink {Service = facebook, Url = "http://www.facebook.com/hofmanhansen"},
                            new SocialLink {Service = twitter, Url = "https://twitter.com/HofmanHansen"},
                            new SocialLink {Service = google, Url = "https://plus.google.com/115474389095711721549/"},
                            new SocialLink {Service = linkedin, Url = "http://www.linkedin.com/in/hofmanhansen"}
                        }
                };
            var roman = new Member
                {
                    FullName = "Roman Mironets",
                    Position = "Developer",
                    Email = "roman.mironets@creuna.no",
                    Photo = CreateLocalImage("http://goo.gl/oBpYuh"),
                    SocialLinks = new[]
                        {
                            new SocialLink {Service = facebook, Url = "https://www.facebook.com/rmironets"},
                            new SocialLink {Service = google, Url = "https://plus.google.com/100776523061714378704/"},
                            new SocialLink {Service = linkedin, Url = "http://www.linkedin.com/in/romanmironets"}
                        }
                };
            var dmitriyn = new Member
                {
                    FullName = "Dmitrij Molodtsov",
                    Position = "Developer",
                    Email = "dmitrij.molodtsov@creuna.no",
                    Photo = CreateLocalImage("http://goo.gl/iA3o3B"),
                    SocialLinks = new[]
                        {
                            new SocialLink {Service = google, Url = "https://plus.google.com/u/0/108800541438516364854/"}
                        }
                };

            // teams
            var cphAlpha = new Team
                {
                    Name = "CPH Alpha Team",
                    Members = new[] {eugene, pavel, chris, dmitriyk, elena, dmitriym, nick}
                };
            var others = new Team
                {
                    Name = "Other",
                    Members = new[] {mads, roman, dmitriyn}
                };

            db.Members.Add(eugene);
            db.Members.Add(pavel);
            db.Members.Add(chris);
            db.Members.Add(dmitriyk);
            db.Members.Add(elena);
            db.Members.Add(dmitriym);
            db.Members.Add(nick);
            db.Members.Add(mads);
            db.Members.Add(roman);
            db.Members.Add(dmitriyn);

            db.Teams.Add(cphAlpha);
            db.Teams.Add(others);

            // projects
            var nobia = new Project
                {
                    Name = "Nobia",
                    Description = "Nordic kitchens",
                    Started = new DateTime(2011, 5, 13), // TODO: change to real
                    DevTeam = new[] {eugene, pavel}.ToList(),
                    ServiceTeam = new[] {chris, dmitriyk, elena}.ToList()
                };
            var nutrilett = new Project
                {
                    Name = "Nutrilett",
                    Description = "Nordic diet products",
                    Started = new DateTime(2011, 11, 1), // TODO: change to real
                    DevTeam = new[] {eugene, pavel}.ToList(),
                    ServiceTeam = new[] {chris, dmitriyk, elena}.ToList()
                };
            var qualiware = new Project
                {
                    Name = "QualiWare",
                    Description = "Software products",
                    Started = new DateTime(2013, 3, 24), // TODO: change to real
                    DevTeam = new[] {eugene, pavel, chris, dmitriyk, elena, dmitriym}.ToList(),
                    ServiceTeam = new[] {nick}.ToList()
                };
            var teller = new Project
                {
                    Name = "Teller",
                    Description = "Nordic payment terminals",
                    Started = new DateTime(2013, 5, 7), // TODO: change to real
                    DevTeam = new[] {eugene, pavel, mads, chris, dmitriyk, elena, dmitriym}.ToList()
                };
            var hay = new Project
                {
                    Name = "Hay",
                    Description = "High design furniture",
                    Started = new DateTime(2013, 8, 11), // TODO: change to real
                    DevTeam = new[] {eugene, pavel, chris, dmitriyk, elena, dmitriym, nick, roman, dmitriyn}.ToList()
                };

            db.Projects.Add(nobia);
            db.Projects.Add(nutrilett);
            db.Projects.Add(qualiware);
            db.Projects.Add(teller);
            db.Projects.Add(hay);

            db.SaveChanges();
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