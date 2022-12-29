using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikWpfApp1.Models;

namespace TelerikWpfApp1.Data
{
    public class ProblemGridData
    {
        public static SortedList<string, string> GetHeaderNames()
        {
            var headerNames = new SortedList<string , string>();

            headerNames.Add("ProblemId", "شناسه دوشواری");
            headerNames.Add("ProblemDesc", "توضیحات");
            headerNames.Add("Date", "تاریخ");
            headerNames.Add("Time", "زمان");
            headerNames.Add("Keywords", "کلمات کلیدی");
            headerNames.Add("IsSolved", "حل شده");

            return headerNames;
        }
        public static List<ProblemGridViewModel> GetData()
        {
            var dataList = new List<ProblemGridViewModel>();

            dataList.Add(new ProblemGridViewModel()
            {
                ProblemId = 1,
                ProblemDesc = "مشکل قمبل زاده اردبیلی طبابایی",
                Date = "1401/01/01",
                Time = "08:26",
                Keywords = "Mitra،اردبیل"
            });
            dataList.Add(new ProblemGridViewModel()
            {
                ProblemId = 2,
                ProblemDesc = "مشکل قمبل زاده اردبیلی طبابایی 02",
                Date = "1401/01/02",
                Time = "08:56",
                Keywords = "Sarina،اردبیل"
            });
            dataList.Add(new ProblemGridViewModel()
            {
                ProblemId = 3,
                ProblemDesc = "مشکل قمبل زاده اردبیلی طبابایی 03",
                Date = "1401/01/06",
                Time = "08:26",
                Keywords = "Sara،اردبیل",
                IsSolved = true
            });
            dataList.Add(new ProblemGridViewModel()
            {
                ProblemId = 4,
                ProblemDesc = "مشکل قمبل زاده اردبیلی طبابایی 04",
                Date = "1401/01/10",
                Time = "09:26",
                Keywords = "Helia،اردبیل",
                IsSolved = true
            });
            dataList.Add(new ProblemGridViewModel()
            {
                ProblemId = 5,
                ProblemDesc = "مشکل قمبل زاده اردبیلی طبابایی 05",
                Date = "1401/01/09",
                Time = "02:56",
                Keywords = "Tina،اردبیل"
            });
            dataList.Add(new ProblemGridViewModel()
            {
                ProblemId = 6,
                ProblemDesc = "مشکل قمبل زاده اردبیلی طبابایی 06",
                Date = "1401/01/08",
                Time = "09:32",
                Keywords = "F.Gh،اردبیل"
            });
            dataList.Add(new ProblemGridViewModel()
            {
                ProblemId = 7,
                ProblemDesc = "مشکل قمبل زاده اردبیلی طبابایی 07",
                Date = "1401/01/17",
                Time = "16:31",
                Keywords = "eli،اردبیل"
            });
            dataList.Add(new ProblemGridViewModel()
            {
                ProblemId = 8,
                ProblemDesc = "مشکل قمبل زاده اردبیلی طبابایی 08",
                Date = "1401/01/29",
                Time = "23:03",
                Keywords = "amir mohamad،اردبیل",
                IsSolved = true
            });
            dataList.Add(new ProblemGridViewModel()
            {
                ProblemId = 9,
                ProblemDesc = "مشکل قمبل زاده اردبیلی طبابایی 09",
                Date = "1401/01/20",
                Time = "19:48",
                Keywords = "hamed،اردبیل",
                IsSolved = true
            });
            dataList.Add(new ProblemGridViewModel()
            {
                ProblemId = 10,
                ProblemDesc = "مشکل قمبل زاده اردبیلی طبابایی 10",
                Date = "1401/01/30",
                Time = "09:34",
                Keywords = "omid،اردبیل"
            });

            return dataList;
        }
    }
}
