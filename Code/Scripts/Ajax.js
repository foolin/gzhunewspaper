
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
        }
        http.send("Ajax/GetPageId.aspx");
    }
    else if(paras["NewsID"]){
        http.onresponse = function(request){
            var p = request.responseText.split(',');
            ShowPageNav(p[0],p[1]);
        }
        http.send("Ajax/GetPageID.aspx?NewsID=" + paras["NewsID"]);
    }
    else if(paras["PaperID"] && paras["PageID"]){
      ShowPageNav(paras["PaperID"], paras["PageID"]);
    }
    else if(paras["PaperID"]){
        http.onresponse = function(request){
            var p = request.responseText.split(',');
            ShowPageNav(p[0],p[1]);
        }
        http.send("Ajax/GetPageID.aspx?PaperID=" + paras["PaperID"]);
    }
    else{
        http.onresponse = function(request){
            var p = request.responseText.split(',');
            ShowPageNav(p[0],p[1]);
        }
        http.send("Ajax/GetPageId.aspx");
    }
}

//获取版名
function ShowPageNav(paperID,pageID){
    var http=new HTTPRequest();
    http.onresponse=function(request){
        var pageNav=document .getElementById ("pageNav");
        pageNav.innerHTML =request.responseText;
        ChangePaperName(paperID);
    }
    http.send("Ajax/GetPageNav.aspx?PaperID=" + paperID + "&PageID=" + pageID,"","post")
}

function ChangePaperName(paperID){
    var span = document.getElementById("paperID");
    span.innerHTML = "第" + paperID + "期";
    var paperID2 = document.getElementById("currentPaperID");
    paperID2.innerHTML = "第" + paperID + "期:";
/*
    var http = new HTTPRequest();
    http.onresponse = function(request){
        var span = document.getElementById("paperID");
        span.innerHTML = "第" + request.responseText + "期";
    }
    http.send("Ajax/GetPaperID.aspx?PaperID=" + paperID);
*/
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
    /*
    else if(paras["word_news_id"] && paras["keyword"]){
        if(!paras["page"]){
            paras["page"] = "0";
        }
        showarticle(paras["word_news_id"],"keyword=" + paras["keyword"] + "&page=" + paras["page"]);
    }
    else if(paras["keyword"] && !paras["page"]){
        Paging("gopage","0",paras["keyword"]);
    }
    else if(paras["keyword"] && paras["page"]){
        Paging("gopage",paras["page"],paras["keyword"]);
    }
    else if(paras["page_id"]){
        shownews(paras["page_id"]);
    }
    */
    else{
        http.onresponse = function(request){
            var p = request.responseText.split(',');
            ShowNewsList(p[0],p[1]);
        }
        http.send("Ajax/GetPageID.aspx");
    }
}


function ShowNewsList(paperID, pageID){
    var newsList = document .getElementById("news");
    newsList.innerHTML = "<div style='height:500px'><p style='padding-top:50px;padding-left:50px'>加载中...</p></div>";
    var http=new HTTPRequest();
    http.onresponse=function(request){
        newsList.innerHTML=request.responseText;
        //document.getElementById("news").style.display = 'block';
    }
    http.send ("Ajax/GetNewsList.aspx?PaperID=" + paperID + "&PageID=" + pageID);
}

function ShowNews(newsID){
    var news = document.getElementById("news");
    news.innerHTML = "<div style='height:500px'><p style='padding-top:50px;padding-left:50px'>加载中...</p></div>";
    var http=new HTTPRequest();
        http.onresponse=function(request){
            
            news.innerHTML = request.responseText;
        }
    http.send ("Ajax/GetNews.aspx?NewsID=" + newsID);
    return false;
}

function Paging(word,page,keyword){
    var news=document .getElementById ("news");
    news.innerHTML = "<div style='height:500px'><p style='padding-top:50px;padding-left:50px'>加载中...</p></div>";
    var http=new HTTPRequest();
    http.onresponse=function(request){
        news.innerHTML =request.responseText;
	if(document.getElementById("newslist")){
            document.getElementById("newslist").style.display = 'block';
        }
    }
    if(word=="pre"){
        http.send ("http://weekly.hustnews.com/index/webajax/search.aspx?page=" + (page-1) + "&keyword=" + keyword,"","post");
        window.location.href = "#keyword=" + keyword + "&page=" + (page-1) + "&gopage=true";
    }
    else if(word=="next"){
        page++;
        http.send("http://weekly.hustnews.com/index/webajax/search.aspx?page=" + page + "&keyword=" + keyword,"","post");
        window.location.href = "#keyword=" + keyword + "&page=" + page + "&gopage=true";
    }
    else if(word=="gopage"){
        http.send("http://weekly.hustnews.com/index/webajax/search.aspx?page=" + page + "&keyword=" + keyword,"","post");
        window.location.href = "#keyword=" + keyword + "&page=" + page + "&gopage=true";
    }
    return false;
}