using SocialNetwork.Data.Repositories;
using SocialNetwork.Data.UnitOfWorks;
using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Data
{
    public class DataProvider
    {
        private IGenericRepository<Friendship> friendshipsRepo;
        private IGenericRepository<Image> imagesrepo;
        private IGenericRepository<Post> postsRepo;
        private IGenericRepository<Message> messagesRepo;
        private IGenericRepository<UserProfile> userProfiles;
        private Func<IUnitOfWork> unitOfWork;

        public DataProvider(IGenericRepository<Friendship> frRepo,
            IGenericRepository<Image> imgRepo,
            IGenericRepository<Post> postRepo,
            IGenericRepository<Message> msgRepo,
            IGenericRepository<UserProfile> profiles,
            Func<IUnitOfWork> unitOfWork)
        {
            this.FriendshipsRepo = frRepo;
            this.Imagesrepo = imgRepo;
            this.PostsRepo = postRepo;
            this.MessagesRepo = msgRepo;
            this.UserProfiles = profiles;
            this.UnitOfWork = unitOfWork;

        }
        public IGenericRepository<Friendship> FriendshipsRepo
        {
            get
            {
                return friendshipsRepo;
            }

            set
            {
                friendshipsRepo = value;
            }
        }

        public IGenericRepository<Image> Imagesrepo
        {
            get
            {
                return imagesrepo;
            }

            set
            {
                imagesrepo = value;
            }
        }

        public IGenericRepository<Post> PostsRepo
        {
            get
            {
                return postsRepo;
            }

            set
            {
                postsRepo = value;
            }
        }

        public IGenericRepository<Message> MessagesRepo
        {
            get
            {
                return messagesRepo;
            }

            set
            {
                messagesRepo = value;
            }
        }

        public IGenericRepository<UserProfile> UserProfiles
        {
            get
            {
                return userProfiles;
            }

            set
            {
                userProfiles = value;
            }
        }

        public Func<IUnitOfWork> UnitOfWork
        {
            get
            {
                return unitOfWork;
            }

            set
            {
                unitOfWork = value;
            }
        }
    }
}
