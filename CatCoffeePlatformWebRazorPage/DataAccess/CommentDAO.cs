using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CommentDAO
    {
        private CatCoffeePlatformContext _context = new CatCoffeePlatformContext();
        private static CommentDAO instance;
        private static readonly object instanceLock = new object();
        private CommentDAO() { }
        public static CommentDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CommentDAO();
                    }
                }
                return instance;
            }
        }

        public async Task<IList<CommentInformation>> GetAllCommentOItem(int shopId)
        {
            var getAllData = await (from cmt in _context.Comments.AsNoTracking()
                                    join acc in _context.Accounts.AsNoTracking()
                                    on cmt.AccountId equals acc.AccountId
                                    where shopId == cmt.ShopId
                                    select new CommentInformation
                                    {
                                        AccountId = cmt.AccountId,
                                        Context = cmt.Context,
                                        UserName = acc.UserName,
                                        ShopId = shopId
                                    }).ToListAsync();
            return getAllData;
        }

        public async Task<IList<CommentInformation>> GetAllCommentByAdmin()
        {
            var getAllData = await (from cmt in _context.Comments.AsNoTracking()
                                    join acc in _context.Accounts.AsNoTracking()
                                    on cmt.AccountId equals acc.AccountId
                                    select new CommentInformation
                                    {
                                        AccountId = cmt.AccountId,
                                        Context = cmt.Context,
                                        UserName = acc.UserName,
                                        Status = cmt.Status
                                    }).ToListAsync();
            return getAllData;
        }

        public async void CreateCommentByUser(Comment request)
        {
            _context.Comments.Add(request);
            await _context.SaveChangesAsync();  
        }

        public async void UpdateCommentByUser(Comment request)
        {
            _context.Comments.Update(request);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ChangeStatusByAdmin (int commentId)
        {
            var checkCmt = await _context.Comments.AsNoTracking()
                                .FirstOrDefaultAsync(a => a.CommentId == commentId);
            if(checkCmt == null)
            {
                return false;
            }else
            {
                if (checkCmt.Status == true)
                {
                    checkCmt.Status = false;
                    return true;
                }
                else if (checkCmt.Status == false)
                {
                    checkCmt.Status = true;
                    return true;
                }
            }
            return true;
        }
    }
}
