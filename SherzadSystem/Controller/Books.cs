using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SherzadSystem.Controller
{
    internal class Books
    {
        #region Book
        internal static object GetBooks()
        {
            object books = null;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    books = s.Books.Include("BookCategories").ToList();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return books;
        }
        internal static object GetBooks(string Keywords)
        {
            object books = null;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    books = s.Books.Include("BookCategories").Where(x => x.BookName.Contains(Keywords) && x.BookAuthor.Contains(Keywords) && x.BookFile.Contains(Keywords)).ToList();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return books;
        }
        internal static bool AddBook(Model.Books book, string FileName, string FilePath)
        {
            bool ret = true;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                using (var transaction = s.Database.BeginTransaction())
                {
                    try
                    {
                        string GeneralPath = @"\Assets\Books";
                        s.Books.Add(book);
                        s.SaveChanges();
                        if (Directory.Exists(Environment.CurrentDirectory + GeneralPath))
                        {
                            if(!File.Exists(Environment.CurrentDirectory + GeneralPath + @"\" + FileName))
                            {
                                File.Copy(FilePath, Environment.CurrentDirectory + GeneralPath + @"\" + FileName);
                                transaction.Commit();
                            }else
                            {
                                Defaults.SimpleMessageBox("فایل موجود دی");
                                transaction.Rollback();
                                ret = false;
                            }
                        }
                        else
                        {
                            Directory.CreateDirectory(Environment.CurrentDirectory + GeneralPath);
                            if (!File.Exists(Environment.CurrentDirectory + GeneralPath + @"\" + FileName))
                            {
                                File.Copy(FilePath, Environment.CurrentDirectory + GeneralPath + @"\" + FileName);
                                transaction.Commit();
                            }
                            else
                            {
                                Defaults.SimpleMessageBox("فایل موجود دی");
                                transaction.Rollback();
                                ret = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Defaults.SetLog(ex);
                        transaction.Rollback();
                        ret = false;
                    }
                }
            }
            return ret;
        }
        internal static bool Update(Model.Books b)
        {
            bool u = true;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    var book = s.Books.FirstOrDefault(x => x.Bid == b.Bid);
                    book.BookName = b.BookName;
                    book.BookAuthor = b.BookAuthor;
                    book.PublishYear = b.PublishYear;
                    book.PublishingIndustry = b.PublishingIndustry;

                    s.SaveChanges();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                    u = false;
                }
            }
            return u;
        }
        #endregion

        #region Book Categories

        public static bool AddCategory(string BCName)
        {
            bool ret = true;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    var cat = new Model.BookCategories();
                    cat.CategoryName = BCName;
                    s.BookCategories.Add(cat);
                    s.SaveChanges();

                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                    ret = false;
                }
            }
            return ret;
        }

        public static bool UpdateCategory(Model.BookCategories b)
        {
            bool ret = true;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    var cat = s.BookCategories.FirstOrDefault(x => x.Cid == b.Cid);
                    cat.CategoryName = b.CategoryName;
                    
                    s.SaveChanges();

                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                    ret = false;
                }
            }
            return ret;
        }
        public static object GetBookCategories()
        {
            object cats = null;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    cats = s.BookCategories.ToList();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return cats;
        }

        #endregion
    }
}
