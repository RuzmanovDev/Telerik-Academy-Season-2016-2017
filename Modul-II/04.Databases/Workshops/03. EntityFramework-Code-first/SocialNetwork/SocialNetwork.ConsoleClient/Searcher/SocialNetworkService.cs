namespace SocialNetwork.ConsoleClient.Searcher
{
    using Data;
    using SocialNetwork.Models.Models;
    using System;
    using System.Collections;
    using System.Linq;

    public class SocialNetworkService : ISocialNetworkService
    {
        private SocialDbContext db;

        public SocialNetworkService()
        {
            this.db = new SocialDbContext();
        }

        /// <summary>
        /// Get Username, FirstName, LastName, and number of images for
        /// all users which registration year is greater than or equal to the provided year
        /// </summary>
        public IEnumerable GetUsersAfterCertainDate(int year)
        {
            return this.db.Users
                 .Where(u => u.RegisteredOn.Year >= year)
                 .Select(u => new
                 {
                     Username = u.Username,
                     FirsName = u.FirstName,
                     LastName = u.LastName,
                     ImgeCount = u.Images.Count
                 })
                 .ToList();
        }

        /// <summary>
        /// Get all posts in which the user with the provided username is tagged.
        /// Select PostedOn, Content and all usernames of the tagged users in the post.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public IEnumerable GetPostsByUser(string username)
        {
            var posts = this.db.Posts.Where(x => x.TaggedUsers.Any(u => u.Username == username))
                .Select(nu => new
                {
                    PostedOn = nu.PostedOn,
                    Content = nu.Content,
                    UaserNames = nu.TaggedUsers.Select(u => u.Username)
                })
                .ToList();

            return posts;
        }

        /// <summary>
        /// Get all approved friendships, ordered ascending by the friendship date and
        /// paged by the provided numbers. Select FirstUserUsername, FirstUserImage,
        /// SecondUserUsername, SecondUserImage. Images are just the URLs of the first image for each user.
        /// </summary>
        public IEnumerable GetFriendships(int page = 1, int pageSize = 25)
        {
            var skip = (page - 1);
            var take = pageSize;

            return this.db.Friendship.Where(fs => fs.Approved == true)
                .OrderBy(o => o.FriendShipSince)
                .Skip(skip)
                .Take(take)
                .Select(f => new
                {
                    FirstUserName = f.FirstUser.Username,
                    FirstUserImage = f.FirstUser.Images.Select(i => i.ImageUrl.FirstOrDefault()),
                    SecondUserName = f.SecondUser.Username,
                    SecondUserImage = f.SecondUser.Images.Select(i => i.ImageUrl.FirstOrDefault())
                })
                .ToList();
        }


        /// <summary>
        /// Get all usernames of all the unique users with which the provided user by username
        /// has at least one chat message, ordered alphabetically.
        /// </summary>
        public IEnumerable GetChatUsers(string username)
        {
            return this.db.Users
                .Where(u => u.Messages.Count > 1)
                .Distinct()
                .Select(un => un.Username)
                .ToList();
        }
    }
}
