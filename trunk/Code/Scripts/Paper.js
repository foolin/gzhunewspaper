// File:    Paper.js
// Author:  Foolin
// Created: 2009年6月10日13:32:49
// Purpose: Script for Default.aspx

//载入数据
function LoadData(){
    var url = document.location.href;
    var paras = new Array();
    paras = GetUrl(url);
    GetPageNav(paras);
    GetPageImage(paras);
    GetNews(paras);
}

//选择期刊
function ChangePaper(paperID){
    if(paperID == "0"){return;}
    window.location.href = "#PaperID=" + paperID;
    LoadData();
}


//搜索
function Search(word, page){
    var news = document.getElementById("news");
    news.innerHTML = "<div id=\"loading\"><p style='padding-top:50px;padding-left:50px'>加载中...</p></div>";
    var http=new HTTPRequest();
    http.onresponse=function(request){
        news.innerHTML = request.responseText;
    }
    var keyword=document.getElementById ("keyword");
    if(word && page){
        http.send("Ajax/search.aspx?Keyword=" + escape(word) + "&Page=" + page);
        window.location.href = "#Keyword=" + unescape(word) + "&Page=" + page;
    }
    else if(word){
        http.send("Ajax/search.aspx?Keyword=" + unescape(word));
    }
    else{
        if(keyword.value.replace(/(^\s*)|(\s*$)/g,"") == ""){
            news.innerHTML = "";
            alert("请输入关键词");
            return false;
        }
        http.send("Ajax/search.aspx?Keyword="+escape(keyword.value));
        window.location.href = "#Keyword=" + unescape(keyword.value);
    }
    return false;
}


//判断浏览器是否是ie
var isIE = navigator.userAgent.indexOf("MSIE") > 0;
var isFF = navigator.userAgent.indexOf("Firefox") > 0;
//主页
function HomePage(){
    if(isIE){
        this.style.behavior='url(#default#homepage)';this.setHomePage('http://weekly.hustnews.com');
    }
    return false;
}

//收藏
function Love(){
    if(isIE){
        window.external.AddFavorite('http://weekly.hustnews.com','校报电子版');
    }
    if(isFF){
        alert("你的浏览器是Firefox，收藏可按 Ctrl + D");
    }
    return false;
}