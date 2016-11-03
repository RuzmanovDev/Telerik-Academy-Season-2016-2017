using SocialNetwork.ConsoleClient.Models;
using SocialNetwork.Data;
using SocialNetwork.Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SocialNetwork.ConsoleClient
{
    public class Importer
    {
        private readonly TextWriter textWrite;

        private Importer(TextWriter textWritter)
        {
            this.textWrite = textWritter;
        }

        public static Importer Create(TextWriter textWrite)
        {
            return new Importer(textWrite);
        }

        private IEnumerable<TModel> Deserialize<TModel>(string fileName, string rootElement)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("File not found");
            }

            var serialier = new XmlSerializer(typeof(List<TModel>), new XmlRootAttribute(rootElement));

            IEnumerable<TModel> result;
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                result = (IEnumerable<TModel>)serialier.Deserialize(fs);
            }

            return result;
        }

        public void Import()
        {
            var friendships = this.Deserialize<FriendshipXmlModel>("XmlFiles/Friendships.xml", "Friendships");
            this.ProcessFrienships(friendships);
            this.textWrite.WriteLine();

            var posts = this.Deserialize<PostXmlModel>("XmlFiles/Posts-Test.xml", "Posts");
            this.ProcessPosts(posts);
            this.textWrite.WriteLine();
        }

        private void ProcessFrienships(IEnumerable<FriendshipXmlModel> friendships)
        {
            this.textWrite.Write("Importing friendships");

            var addedFriendships = 0;
            var db = new SocialDbContext();
            db.Configuration.AutoDetectChangesEnabled = false;
            db.Configuration.ValidateOnSaveEnabled = false;

            var savedUsers = new HashSet<string>();

            foreach (var friendship in friendships)
            {
                var firstUser = this.GetUser(db, friendship.FirstUser, savedUsers);
                var secondUser = this.GetUser(db, friendship.SecondUser, savedUsers);

                var newFriendship = new Friendship
                {
                    Approved = friendship.Approved,
                    FriendShipSince = friendship.FriendsSince,
                    FirstUser = firstUser,
                    SecondUser = secondUser,
                };

                foreach (var message in friendship.Messages)
                {
                    db.Messages.Add(new Message
                    {
                        Author = message.Author == firstUser.Username ? firstUser : secondUser,
                        Content = message.Content,
                        Friendship = newFriendship,
                        SeenOn = message.SeenOn,
                        SentOn = message.SentOn
                    });
                }

                addedFriendships++;

                if (addedFriendships % 10 == 0)
                {
                    this.textWrite.Write(".");
                }

                db.SaveChanges();

                if (addedFriendships % 100 == 0)
                {
                    db = new SocialDbContext();
                    db.Configuration.AutoDetectChangesEnabled = false;
                    db.Configuration.ValidateOnSaveEnabled = false;
                }
            }

            db.Configuration.AutoDetectChangesEnabled = true;
            db.Configuration.ValidateOnSaveEnabled = true;
        }

        private User GetUser(SocialDbContext db, UserXmlModel model, HashSet<string> addedUsersSoFar)
        {
            if (addedUsersSoFar.Contains(model.Username))
            {
                return db.Users.FirstOrDefault(u => u.Username == model.Username);
            }
            else
            {
                addedUsersSoFar.Add(model.Username);

                var user = new User
                {
                    Username = model.Username,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    RegisteredOn = model.RegisteredOn
                };

                foreach (var image in model.Images)
                {
                    user.Images.Add(new Image
                    {
                        ImageUrl = image.ImageUrl,
                        FileExtension = image.FileExtension
                    });
                }

                db.Users.Add(user);
                db.SaveChanges();

                return user;
            }
        }

        private void ProcessPosts(IEnumerable<PostXmlModel> posts)
        {
            this.textWrite.Write("Importing posts");
            var addedPosts = 0;
            var dbContext = new SocialDbContext();
            dbContext.Configuration.AutoDetectChangesEnabled = false;
            dbContext.Configuration.ValidateOnSaveEnabled = false;

            foreach (var post in posts)
            {
                var usernames = post.Users.Split(',');
                var users = dbContext.Users
                 .Where(u => usernames.Contains(u.Username))
                 .ToList();

                var newPost = new Post
                {
                    PostedOn = post.PostedOn,
                    Content = post.Content
                };

                foreach (var user in users)
                {
                    newPost.TaggedUsers.Add(user);
                }

                dbContext.Posts.Add(newPost);
                addedPosts++;

                if (addedPosts % 10 == 0)
                {
                    this.textWrite.Write(".");
                }

                if (addedPosts % 100 == 0)
                {
                    dbContext.SaveChanges();
                    dbContext = new SocialDbContext();
                    dbContext.Configuration.AutoDetectChangesEnabled = false;
                    dbContext.Configuration.ValidateOnSaveEnabled = false;
                }
            }

            dbContext.SaveChanges();
            dbContext.Configuration.AutoDetectChangesEnabled = true;
            dbContext.Configuration.ValidateOnSaveEnabled = true;
            Console.WriteLine();
        }

    }
}
