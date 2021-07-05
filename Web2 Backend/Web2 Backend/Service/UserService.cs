using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Model;
using Web2_Backend.Model.Request;
using Web2_Backend.Repository;

namespace Web2_Backend.Service
{
    public class UserService
    {

        private EmailService emailService = new EmailService();

        public UserService() 
        {

        }

        public PageResponse<User> GetAll(int page, int perPage, string search, string sort) 
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    return unitOfWork.Users.GetAll(page, perPage, search, sort);
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return null;
        }

        public bool VerifyUser(long id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    User userDB = unitOfWork.Users.Get(id);

                    if (userDB == null)
                    {
                        return false;
                    }

                    unitOfWork.Users.Update(userDB);
                    userDB.AdminNeedApproved = false;

                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public List<User> GetVerificationUsers()
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    return unitOfWork.Users.GetVerificationUsers();
                }
            }
            catch (Exception e)
            {
                return new List<User>();
            }

        }

        public User GetUserWithEmail(string email) 
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context())) 
                {
                    return unitOfWork.Users.GetUserWithEmail(email);
                }
            }
            catch (Exception e) 
            {
                return null;
            }

            return null;
        }

        public User GetUserWithEmailAndPassword(string email, string password)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    return unitOfWork.Users.GetUserWithUsernameAndPassword(email, password);
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return null;
        }


        //2.3
        public bool Edit(User user) 
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context())) 
                {
                    User userDB = unitOfWork.Users.Get(user.Id);

                    if (userDB == null) 
                    {
                        return false;
                    }

                    unitOfWork.Users.Update(userDB);

                    userDB.Address = user.Address;
                    userDB.LastName = user.LastName;
                    userDB.Email = user.Email;
                    userDB.Name = user.Name;
                    userDB.AdminNeedApproved = userDB.UserType != user.UserType;
                    userDB.UserType = user.UserType;

                    unitOfWork.Complete();
                }
            }
            catch (Exception e) 
            {
                return false;
            }

            return true;
        }

        public bool ChangeUserType(ChangeUserTypeRequest request) 
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    User userDB = unitOfWork.Users.Get(request.Id);

                    if (userDB == null)
                    {
                        return false;
                    }

                    unitOfWork.Users.Update(userDB);

                    userDB.NewUserType = request.UserType;
                    userDB.AdminNeedApproved = true;

                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool AdminNeedApproved(AdminNeedApprovedRequest request) 
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    User userDB = unitOfWork.Users.Get(request.Id);

                    if (userDB == null)
                    {
                        return false;
                    }

                    unitOfWork.Users.Update(userDB);

                    if (request.AdminApproved)
                    { 
                        userDB.UserType = userDB.NewUserType;
                    }
                    
                    userDB.AdminNeedApproved = false;
                    
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool Add(User user) 
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context())) 
                {
                    User userDB = new User();

                    userDB.Address = user.Address;
                    userDB.BirthDate = user.BirthDate;
                    userDB.LastName = user.LastName;
                    userDB.Email = user.Email;
                    userDB.Name = user.Name;
                    userDB.Username = user.Username;
                    userDB.Password = user.Password;
                    userDB.UserType = user.UserType;
                    userDB.UserStatus = UserStatus.PROCESSING;
                    userDB.AdminNeedApproved = true;

                    unitOfWork.Users.Add(userDB);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e) 
            {
                return false;
            }

            return true;
        }

        public bool ChangeUserStatus(ChangeUserStatusRequest request)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    User userDB = unitOfWork.Users.Get(request.Id);

                    if (userDB == null)
                    {
                        return false;
                    }

                    unitOfWork.Users.Update(userDB);

                    userDB.UserStatus = request.UserStatus;

                    unitOfWork.Complete();

                    emailService.SendMessage(userDB.Email, "Status changed", "");
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool ChangePassword(string password, long id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    User userDB = unitOfWork.Users.Get(id);

                    if (userDB == null)
                    {
                        return false;
                    }

                    unitOfWork.Users.Update(userDB);

                    userDB.Password = password;

                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        
    }
}
