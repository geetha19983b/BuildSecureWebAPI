using ExpenseTracker.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using ExpenseTracker.WebClient.Helpers;

namespace ExpenseTracker.WebClient.Models
{
    public class ExpenseGroupsViewModel
    {
        public IPagedList<ExpenseGroup> ExpenseGroups { get; set; }
//        public IEnumerable<ExpenseGroup> ExpenseGroups { get; set; }

        public IEnumerable<ExpenseGroupStatus> ExpenseGroupStatusses { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }

}