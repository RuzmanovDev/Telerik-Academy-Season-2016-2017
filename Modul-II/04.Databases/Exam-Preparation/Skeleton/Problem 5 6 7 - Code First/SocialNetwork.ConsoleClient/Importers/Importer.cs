using SocialNetwork.ConsoleClient.Models;
using SocialNetwork.Data;
using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SocialNetwork.ConsoleClient.Importers
{
    public class Importer : IImporter
    {
        private DataProvider dataprovider;

        public Importer(DataProvider dataprovider)
        {
            this.dataprovider = dataprovider;
        }

        public void Import()
        {
            var friendships = this.Deserialize<FriendshipXML>("XmlFiles/Friendships.xml", "Friendships");
            this.ProcessFrienships(friendships);

            var posts = this.Deserialize<PostXML>("XmlFiles/Posts.xml", "Posts");
            this.ProcessPosts(posts);
        }

        private void ProcessPosts(IEnumerable<PostXML> posts)
        {
            var addedPosts = 0;
            foreach (var xmlPost in posts)
            {
                var userNames = xmlPost.Users.Split(',');

                var users = this.dataprovider.UserProfiles.GetAll<UserProfile>(u => userNames.Contains(u.Username), null);

                var newPost = new Post()
                {
                    Content = xmlPost.Content,
                    PostedOn = xmlPost.PostedOn,
                };


                foreach (var user in users)
                {
                    newPost.TaggedUsers.Add(user);
                }

                this.dataprovider.PostsRepo.Add(newPost);
                addedPosts++;

                if (addedPosts % 100 == 0)
                {
                    using (var uof = this.dataprovider.UnitOfWork())
                    {
                        uof.Commit();
                    }
                }
            }

            using (var uof = this.dataprovider.UnitOfWork())
            {
                uof.Commit();
            }
        }

        private void ProcessFrienships(IEnumerable<FriendshipXML> friendships)
        {
            var addedFs = 0;
            var addedUserSoFar = new HashSet<string>();

            foreach (var xmlFr in friendships)
            {
                var firstUser = this.GetUser(xmlFr.FirstUser, addedUserSoFar);
                var secondUser = this.GetUser(xmlFr.SecondUser, addedUserSoFar);

                var fs = new Friendship()
                {
                    Approved = xmlFr.Approved,
                    FirstUser = firstUser,
                    SecondUser = secondUser,
                    TimeOfApproval = xmlFr.FriendsSince
                };

                foreach (var message in xmlFr.Messages)
                {
                    this.dataprovider.MessagesRepo.Add(new Message()
                    {
                        Content = message.Content,
                        Friendship = fs,
                        SeenDate = message.SeenOn,
                        SendDate = message.SentOn,
                        Author = message.Author == firstUser.Username ? firstUser : secondUser
                    });
                }

                this.dataprovider.FriendshipsRepo.Add(fs);
                addedFs++;

                if (addedFs % 100 == 0)
                {
                    using (var uof = this.dataprovider.UnitOfWork())
                    {
                        uof.Commit();
                    }
                }
            }

            using (var uof = this.dataprovider.UnitOfWork())
            {
                uof.Commit();
            }
        }

        private UserProfile GetUser(UserProfileXML user, HashSet<string> addedUserSoFar)
        {
            if (addedUserSoFar.Contains(user.Username))
            {
                return this.dataprovider.UserProfiles.GetAll<UserProfile>(u => u.Username == user.Username, null).FirstOrDefault();
            }
            else
            {
                addedUserSoFar.Add(user.Username);
                var newUser = new UserProfile()
                {
                    FristName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.Username,
                    RegistrationDate = user.RegisteredOn
                };

                foreach (var image in user.Images)
                {
                    newUser.Images.Add(new Image()
                    {
                        FileExtension = image.FileExtension,
                        Url = image.ImageUrl
                    });
                }

                this.dataprovider.UserProfiles.Add(newUser);
                using (var uof = this.dataprovider.UnitOfWork())
                {
                    uof.Commit();
                }

                return newUser;
            }
        }

        private IEnumerable<TModel> Deserialize<TModel>(string fileName, string rootElement)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("File not found!", fileName);
            }

            var serializer = new XmlSerializer(typeof(List<TModel>), new XmlRootAttribute(rootElement));
            IEnumerable<TModel> result;
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                result = (IEnumerable<TModel>)serializer.Deserialize(fs);
            }

            return result;
        }
    }
}
