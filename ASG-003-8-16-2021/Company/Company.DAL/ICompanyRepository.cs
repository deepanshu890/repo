using System.Collections.Generic;
using System.Threading.Tasks;
using Company.DAL.Models;

namespace Company.DAL
{
    public interface ICompanyRepository
    {
        Task<int> AddAddress(Address e);
        Task<int> AddTeam(Team e);
        Task<bool> AddTeamMember(TeamMembers e);
        Task<bool> AddUsers(Users e);
        Task<bool> DeleteAddress(int addressId);
        Task<bool> DeleteForeignTeam(int teamId);
        Task<bool> DeleteForeignUser(int userId);
        Task<bool> DeleteTeam(int teamId);
        Task<bool> DeleteUser(int userId);
        Task<List<Team>> GetTeam();
        Task<List<AddressUsers>> getTeamMembers(int teamId);
        Task<List<Users>> GetUsers();
        Task<List<AddressUsers>> GetUsersDetails();
        Task<bool> UpdateAddress(Address dep);
        Task<bool> UpdateTeam(Team dep);
        Task<bool> UpdateUser(Users dep);
        Task<List<TeamMembers>> GetTeamUsers();
        Task<bool> AddAccount(Account e);
        Task<bool> UpdateAccount(Account dep);
        Task<bool> DeleteAccount(int accountId);
        Task<bool> DeleteForeignAccount(int accountid);
        Task<List<TeamAccount>> GetTeamAccount(int AccountId);
        Task<List<TeamAccount>> GetTeamOne(int AccountId);

        Task<List<Account>> GetAccount();
        bool ValidateCredentials(SuperUsers s);
        Task<List<AddressUsers>> getAccountUsers(int accountId);
        Task<bool> AddAccountTeam(AccountTeam e);
    }
}