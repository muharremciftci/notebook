using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _00_BusinessLayer;
using _00_Entity;
using _00_WebMVC.Filter;

namespace _00_WebMVC.Controllers
{
    [LoginRequired]
    public class HomeController : Controller
    {
        UserBusiness userBll = new UserBusiness();
        NotebookBusiness notebooks = new NotebookBusiness();
        NoteBusiness notes = new NoteBusiness();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
      
        public PartialViewResult Notebook()
        {
            List<Notebook> notebook= notebooks.GetMyNotebook((int)Session["UserID"]);
            return PartialView(notebook);
        }
        public JsonResult NotebookADD(string id ,string name)
        {
            if (id=="")
            {
                Notebook notebook = new Notebook();
                notebook.Title = name;
                notebook.UserID = (int)Session["UserID"];
                bool result = notebooks.Add(notebook);
            }
            else
            {
                int ID = int.Parse(id);
                Notebook notebook = notebooks.GetMyNotebook((int)Session["UserID"]).Where(x=>x.ID==ID).FirstOrDefault();
                if (notebook!=null)
                {
                    notebook.Title = name;
                    notebooks.Update(notebook);
                }


            }
            
        
                List<Notebook> notebookss = notebooks.GetMyNotebook((int)Session["UserID"]);
                string icerik = "";
                foreach (Notebook item in notebookss)
                {
                    icerik += " <tr><td><a href='/Home/Note/" + item.ID + "' >" + item.Title + "</a></td><td><a href=''><span class='glyphicon glyphicon-edit'></span></a></td> <td><span data-id='" + item.ID + "' id='delete-notebook' class='glyphicon glyphicon-remove'></span></td></tr>";
                }
                return Json(icerik, JsonRequestBehavior.AllowGet);
               
        
           

        }

     
        public ActionResult Note(int id=1)
        {
            Notebook notebook = notebooks.Get(id);
            List<Note> note = notes.GetByNotebook(id);
            ViewBag.NotebookId = notebook.ID;
            ViewBag.NotebookName = notebook.Title;
            return View(note);
        }
        [HttpPost]
        public JsonResult NoteAdd(int notebookid,string title ,string context )
        {
            Note note = new Note();
            note.Title = title;
            note.Content = context;
            note.NoteBookID = notebookid;
            bool result = notes.Add(note);
            if (result)
            {
                return Json(note, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }


           
        }
       
        [HttpPost]
        public JsonResult PasswordEdit(string eskisifre,string yenisifre)
        {
            User user = userBll.Get((int)Session["UserID"]);
            if (eskisifre==user.Password)
            {
                user.Password = yenisifre;
                userBll.Update(user);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }


        }


        [HttpPost]
        public JsonResult NoteEdit(int notebookid, string title, string context,string noteID)
        {
            Note note= notes.Get(int.Parse(noteID));
            note.Title = title;
            note.Content = context;
            notes.Update(note);

            List<Note> listnote = notes.GetByNotebook(notebookid);
            string icerik = "";
            foreach (Note data in listnote)
            {
                icerik += "<div  class='col-md-12'><div class='panel panel-default'> <div class='panel-heading'><div class='row'><div class='col-md-6'>" + data.Title + "</div><div class='col-md-3'>Okunma Sasyısı :" + data.NumberOfReadings + "</div><div class='col-md-3'><span class='glyphicon glyphicon-star-empty' id='favorite' data-id='" + data.ID + "'>Favoriye Ekle</span></div> </div></div> <div data-notebookid='" + data.NoteBookID + "' id='note-edit'  data-toggle='modal' data-target='#editNote' data-context='" + data.Content + "' data-title='" + data.Title + "' data-noteid='" + data.ID + "' class='panel-body'>" + data.Content + "</div> </div></div>";

            }
            return Json(icerik, JsonRequestBehavior.AllowGet);



        }


        [HttpPost]
        public JsonResult AddFavorite(int id)
        {
            Note note = notes.Get(id);
            if (note.FavoriteStatus==false)
            {
                note.FavoriteStatus = true;
            }
            else
            {
                note.FavoriteStatus = false;
            }

            bool result=notes.Update(note);

            if (result)
            {
                return Json(note.FavoriteStatus, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }


        }

        public PartialViewResult Favoriler()
        {
            List<Note> notess = notes.GetMyNote((int)Session["UserID"]).Where(x=>x.FavoriteStatus==true).ToList();
            return PartialView(notess);

        }

        [HttpPost]
        public JsonResult DeleteNotebook(int id)
        {
            Notebook notebook = notebooks.Get(id);
            notebooks.Delete(notebook);
            List<Notebook> notebookss = notebooks.GetMyNotebook((int)Session["UserID"]);
            string icerik = "";
            foreach (Notebook item in notebookss)
            {
                icerik += " <tr><td><a href='/Home/Note/" + item.ID + "' >"+item.Title +"</a></td><td><a href=''><span class='glyphicon glyphicon-edit'></span></a></td> <td><span data-id='" + item.ID + "' id='delete-notebook' class='glyphicon glyphicon-remove'></span></td></tr>";            }
            return Json(icerik, JsonRequestBehavior.AllowGet);
        }

    }
}