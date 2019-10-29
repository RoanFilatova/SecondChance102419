using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace BusinessLogicLayer
{
    public class ContextBLL : IDisposable
    {
        #region connection
        ContextDAL _dalcont = new ContextDAL();
        public ContextBLL()
        {
            _dalcont.ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        }
        public void Dispose()
        {
            _dalcont.Dispose();
        }
        #endregion connection
        #region Roles

        public List<RoleBLL> RoleGetAll(int Skip, int Take)
        {
            List<RoleBLL> proposedReturnValue = new List<RoleBLL>();
            try
            {
                List<RoleDAL> items = _dalcont.RoleGetALL(Skip, Take);
                foreach (RoleDAL item in items)
                {
                    RoleBLL correctedItem = new RoleBLL(item);
                    proposedReturnValue.Add(correctedItem);
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
            return proposedReturnValue;
        }
        public RoleBLL RoleFindByID(int RoleID)
        {
            RoleBLL proposedReturnValue = null;
            try
            {
                RoleDAL item = _dalcont.RoleFindbyID(RoleID);
                if (item != null)
                {
                    proposedReturnValue = new RoleBLL(item);
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
            return proposedReturnValue;
        }
        public int RoleObtainCount()
        {
            int item = _dalcont.RoleObtainCount();
            return item;
        }
        public int RoleCreate(string RoleName)
        {
            int expectedRV = _dalcont.RoleCreate(RoleName);

            return expectedRV;
        }
        public void RoleDelete(int RoleID)
        {
            try
            {
                _dalcont.RoleDelete(RoleID);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
        }
        public int RoleUpdateSafe(int RoleID, string OldRoleName, string NewRoleName)
        {
            int proposedRV = _dalcont.RoleUpdateSafe(RoleID, OldRoleName, NewRoleName);
            return proposedRV;
        } //This update safe is here just as a placeholder in case I decide to implement it at a later date.
        public void RoleUpdateJust(int RoleID, string RoleName)
        {
            try
            {
                _dalcont.RoleUpdateJust(RoleID, RoleName);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
        }
        #endregion
        #region User                         
        public List<UserBLL> UserGetAll(int Skip, int Take)
        {
            List<UserBLL> proposedReturnValue = new List<UserBLL>();
            try
            {
                List<UserDAL> items = _dalcont.UserGetAll(Skip, Take);
                foreach (UserDAL item in items)
                {
                    UserBLL correctedItem = new UserBLL(item);
                    proposedReturnValue.Add(correctedItem);
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
            return proposedReturnValue;

        }
        public UserBLL UserFindByID(int UserID)
        {
            UserBLL proposedReturnValue = null;
            try
            {
                UserDAL item = _dalcont.UserFindByID(UserID);
                if (item != null)
                {
                    proposedReturnValue = new UserBLL(item);
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
            return proposedReturnValue;
        }
        public UserBLL UserFindByEMail(string Email)
        {
            UserBLL proposedReturnValue = null;
            try
            {
                UserDAL item = _dalcont.UserFindByEmail(Email);
                if (item != null)
                {
                    proposedReturnValue = new UserBLL(item);
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
            return proposedReturnValue;
        }
        public int UserObtainCount()
        {
            int item = _dalcont.UserObtainCount();
            return item;
        }
        public int UserUpdateSafe(int UserID, string OldUserName, string NewUserName, string OldEmail, string NewEmail, string OldAddress, string NewAddress, string OldHash, string NewHash, string OldSalt, string NewSalt, int OldRoleID, int NewRoleID)
        {
            int proposedRV = _dalcont.UserUpdateSafe(UserID, OldUserName, NewUserName, OldEmail, NewEmail, OldAddress, NewAddress, OldHash, NewHash, OldSalt, NewSalt, OldRoleID, NewRoleID);
            return proposedRV;
        } //This update safe is here as a placeholder just to serve as a potential method to use later. 
        public void UserUpdateJust(int UserID, string UserName, string Email, string Address, string Hash, string Salt, int RoleID)
        {
            try
            {
                _dalcont.UserUpdateJust(UserID, UserName, Email, Address, Hash, Salt, RoleID);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
        }
        public void UserUpdateJust(UserBLL user)
        {
            try
            {
                _dalcont.UserUpdateJust(user.UserID, user.UserName, user.Email, user.Address, user.Hash, user.Salt, user.RoleID);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
        }
        public int UserCreate(string UserName, string Name, string Address, string Email, string Hash, string Salt, int RoleID)
        {
            int expectedRV = _dalcont.UserCreate(UserName, Name, Address, Email, Hash, Salt, RoleID);
            return expectedRV;
        }
        public int UserCreate(UserBLL user)
        {
            int expectedRV = _dalcont.UserCreate(user.UserName, user.Name, user.Address, user.Email, user.Hash, user.Salt, user.RoleID);
            return expectedRV;
        }

        public void UserDelete(int UserID)
        {
            try
            {
                _dalcont.UserDelete(UserID);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
        }
        #endregion
        #region Dogs
        public List<DogBLL> DogsGetAll(int Skip, int Take)
        {
            List<DogBLL> proposedRV = new List<DogBLL>();
            try
            {
                List<DogDAL> items = _dalcont.DogsGetAll(Skip, Take);
                foreach (DogDAL item in items)
                {
                    DogBLL correctedItem = new DogBLL(item);
                    proposedRV.Add(correctedItem);
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
            return proposedRV;
        }
        public DogBLL DogFindByID(int DogID)
        {
            DogBLL proposedRV = null;
            try
            {
                DogDAL item = _dalcont.DogFindByID(DogID);
                if (item != null)
                {
                    proposedRV = new DogBLL(item);
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
            return proposedRV;
        }
        public DogBLL DogFindByBreed(int BreedID)
        {
            DogBLL proposedRV = null;
            try
            {
                DogDAL item = _dalcont.DogFindByBreed(BreedID);
                if (item != null)
                {
                    proposedRV = new DogBLL(item);
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
            return proposedRV;
        }
        public int DogObtainCount(int Skip, int Take)
        {
            int item = _dalcont.DogObtainCount();
            return item;
        }
        public int DogUpdateSafe(int DogID, DateTime SurrenderDate, DateTime AdoptDate, string OldMedical, string NewMedical, string Medical)
        {
            int proposedRV = _dalcont.DogUpdateSafe(DogID, SurrenderDate, AdoptDate, OldMedical, NewMedical, Medical);
            return proposedRV;
        }
        public void DogUpdateJust(int DogID, string Name, bool IsSmallBreed, bool IsDogHairless, string Medical, DateTime AdoptDate, DateTime SurrenderDate)
        {
            try
            {
                _dalcont.DogUpdateJust(DogID, Name, IsSmallBreed, IsDogHairless, Medical, AdoptDate, SurrenderDate);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
        }
        public int DogCreate(string Name, int BreedID, bool IsSmallBreed, bool IsDogHairless, string Medical, DateTime AdoptDate, DateTime SurrenderDate)
        {
            int expectedRV = _dalcont.DogCreate(Name, BreedID, IsSmallBreed, IsDogHairless, Medical, AdoptDate, SurrenderDate);
            return expectedRV;
        }
        public void DogDelete(int DogID)
        {
            try
            {
                _dalcont.DogDelete(DogID);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
        }
        #endregion
        #region Breeds
        public List<BreedBLL> BreedGetAll(int Skip, int Take)
        {
            List<BreedBLL> proposedRV = new List<BreedBLL>();
            try
            {
                List<BreedDAL> items = _dalcont.BreedGetAll(Skip, Take);
                foreach (BreedDAL item in items)
                {
                    BreedBLL correctedItem = new BreedBLL(item);
                    proposedRV.Add(correctedItem);
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
            return proposedRV;
        }
        public int BreedCreate(string BreedName)
        {
            int expectedRV = _dalcont.BreedCreate(BreedName);
            return expectedRV;
        }
        public void BreedDelete(int BreedID)
        {
            try
            {
                _dalcont.BreedDelete(BreedID);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
        }
        public void BreedUpdateJust(int BreedID, string BreedName)
        {
            try
            {
                _dalcont.BreedUpdateJust(BreedID, BreedName);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
        }
        public BreedBLL BreedFindByID(int BreedID)
        {
            BreedBLL proposedReturnValue = null;
            try
            {
                BreedDAL item = _dalcont.BreedFindbyID(BreedID);
                if (item != null)
                {
                    proposedReturnValue = new BreedBLL(item);
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
            return proposedReturnValue;
        }
        public int BreedObtainCount(int Skip, int Take)
        {
            int item = _dalcont.BreedObtainCount();
            return item;
        }
        #endregion
        #region UserDogs
        public int UserDogsCreate(int UserID, int DogID)
        {
            int expectedRV = _dalcont.UserDogsCreate(UserID, DogID);
            return expectedRV;
        }
        public void UserDogsDelete(int UserID, int DogID)
        {
            try
            {
                _dalcont.UserDogsDelete(UserID, DogID);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
        }
        public UserBLL GetUsersByDogID(int DogID)
        {
            UserBLL proposedRV = null;
            try
            {
                UserDAL item = _dalcont.GetUsersByDogID(DogID);
                if (item != null)
                {
                    proposedRV = new UserBLL(item);
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
            return proposedRV;
        }
        public DogBLL GetDogsByUserID(int UserID)
        {
            DogBLL proposedRV = null;
            try
            {
                DogDAL item = _dalcont.GetDogsByUserID(UserID);
                if (item != null)
                {
                    proposedRV = new DogBLL(item);
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
            return proposedRV;
        }
        #endregion
    }
}