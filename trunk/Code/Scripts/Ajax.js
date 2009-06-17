// File:    Ajax.js
// Author:  Foolin
// Created: 2009年6月10日13:32:49
// Purpose: Get paper's data for Default.aspx by ajax

//获取期刊和版面ID，再调用获取图片函数
function GetPageImage(paras){
    var http = new HTTPRequest();
    if(paras == null){
        http.onresponse = function(request){
            var p = request.responseText.split(',');
            ShowPageImage(p[0],p[1]);
        }
        http.send("Ajax/GetPageID.aspx");
    }
    else if(paras["NewsID"]){
        http.onresponse = function(request){
            var p = request.responseText.split(',');
            ShowPageImage(p[0],p[1], paras["NewsID"]);
        }
        http.send("Ajax/GetPageID.aspx?NewsID=" + paras["NewsID"]);
    }
    else if(paras["PaperID"] && paras["PageID"]){
         ShowPageImage(paras["PaperID"], paras["PageID"]);
    }
    else if(paras["PaperID"]){
        var http = new HTTPRequest();
        http.onresponse = function(request){
            var p = request.responseText.split(',');
            ShowPageImage(p[0],p[1]);
        }
        http.send("Ajax/GetPageID.aspx?PaperID=" + paras["PaperID"]);
    }
    else{
        http.onresponse = function(request){
            var p = request.responseText.split(',');
            ShowPageImage(p[0],p[1]);
        }
        http.send("Ajax/GetPageID.aspx");
    }
}
//显示图片
function ShowPageImage(paperID, pageID, newsID){
    var http=new HTTPRequest();
    http.onresponse=function(request){
        var showPageImage=document .getElementById ("pageImage");
        showPageImage.innerHTML=request.responseText;
    }
    http.send ("Ajax/GetPageImage.aspx?PaperID=" + paperID + "&PageID=" + pageID + "&NewsID=" + newsID,"","post");
}

function GetPageNav(paras){
    var http = new HTTPRequest();
    if(paras == null){
        http.onresponse = function(request){
            var p = request.responseText.split(',');
            ShowPageNav(p[0],p[1]);
            ShowPaperNav(p[0],p[1]);
        }
        http.send("Ajax/GetPageId.aspx");
    }
    else if(paras["NewsID"]){
        http.onresponse = function(request){
            var p = request.responseText.split(',');
            ShowPageNav(p[0],p[1]);
            ShowPaperNav(p[0],p[1]);
        }
        http.send("Ajax/GetPageID.aspx?NewsID=" + paras["NewsID"]);
    }
    else if(paras["PaperID"] && paras["PageID"]){
        ShowPaperNav(paras["PaperID"], paras["PageID"]);
        ShowPageNav(paras["PaperID"], paras["PageID"]);
    }
    else if(paras["PaperID"]){
        http.onresponse = function(request){
            var p = request.responseText.split(',');
            ShowPageNav(p[0],p[1]);
            ShowPaperNav(p[0],p[1]);
        }
        http.send("Ajax/GetPageID.aspx?PaperID=" + paras["PaperID"]);
    }
    else{
        http.onresponse = function(request){
            var p = request.responseText.split(',');
            ShowPageNav(p[0],p[1]);
            ShowPaperNav(p[0],p[1]);
        }
        http.send("Ajax/GetPageId.aspx");
    }
}

//期刊导航
function ShowPaperNav(paperID,pageID){
    var http=new HTTPRequest();
    http.onresponse=function(request){
        var pageNav=document .getElementById ("paperNavbar");
        pageNav.innerHTML =request.responseText;
        ChangePaperName(paperID);
    }
    http.send("Ajax/GetPaperNav.aspx?PaperID=" + paperID + "&PageID=" + pageID,"","post")
}

//期刊版面导航
function ShowPageNav(paperID,pageID){
    var http=new HTTPRequest();
    http.onresponse=function(request){
        var pageNav=document .getElementById ("pageNav");
        pageNav.innerHTML =request.responseText;
    }
    http.send("Ajax/GetPageNav.aspx?PaperID=" + paperID + "&PageID=" + pageID,"","post")
}

function ChangePaperName(paperID){
    var span = document.getElementById("paperID");
    span.innerHTML = "第" + paperID + "期";
    var paperID2 = document.getElementById("currentPaperID");
    paperID2.innerHTML = "第" + paperID + "期:";
}

//文章、新闻list
function GetNews(paras){
    var http = new HTTPRequest();
    if(paras == null){
        http.onresponse = function(request){
            var p = request.responseText.split(',');
            ShowNewsList(p[0],p[1]);
        }
        http.send("Ajax/GetPageID.aspx");
    }
    else if(paras["NewsID"]){
          ShowNews(paras["NewsID"]);
    }
    else if(paras["Keyword"] && paras["Page"]){
        Search(paras["Keyword"], paras["Page"]);
    }
    else if(paras["Keyword"]){
        Search(paras["Keyword"]);
    }
    else if(paras["PaperID"] && paras["PageID"]){
            ShowNewsList(paras["PaperID"], paras["PageID"]);
    }
    else if(paras["PaperID"] && !paras["PageID"]){
        var http =new HTTPRequest();
        http.onresponse = function(request){
            var p = request.responseText.split(',');
            ShowNewsList(p[0],p[1]);
        }
        http.send("Ajax/GetPageID.aspx?PaperID=" + paras["PaperID"]);
    }
    else{
        http.onresponse = function(request){
            var p = request.responseText.split(',');
            ShowNewsList(p[0],p[1]);
        }
        http.send("Ajax/GetPageID.aspx");
    }
}


//显示新闻列表
function ShowNewsList(paperID, pageID){
    var newsList = document .getElementById("news");
    newsList.innerHTML = "<div id=\"loading\"><p style='padding-top:50px;padding-left:50px'>加载中...</p></div>";
    var http=new HTTPRequest();
    http.onresponse=function(request){
        newsList.innerHTML=request.responseText;
    }
    http.send ("Ajax/GetNewsList.aspx?PaperID=" + paperID + "&PageID=" + pageID);
}

//显示新闻
function ShowNews(newsID){
    var news = document.getElementById("news");
    news.innerHTML = "<div id=\"loading\"><p style='padding-top:50px;padding-left:50px'>加载中...</p></div>";
    var http=new HTTPRequest();
        http.onresponse=function(request){
            
            news.innerHTML = request.responseText;
        }
    http.send ("Ajax/GetNews.aspx?NewsID=" + newsID);
    return false;
}


