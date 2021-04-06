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
        public UserService() 
        {

        }
        //2.3
        public bool Edit(int id, User user) 
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

                    userDB.Address = user.Address;
                    userDB.BirthDate = user.BirthDate;
                    userDB.LastName = user.LastName;
                    userDB.Email = user.Email;
                    userDB.Name = user.Name;

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
    }
}
