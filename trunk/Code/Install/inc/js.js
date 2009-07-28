/**************************/
/* Author：Foolin         */
/* E-mail:Foolin@126.com  */
/* Create on:2009-7-26    */
/**************************/

function $(o){ return typeof(o)=="string" ? document.getElementById(o) : o;}
//获取URL
function GetUrl(ProtoString){
    var paraString =  ProtoString.split('#');
    if(!paraString[1]){
        return null;
    }
    var paras = paraString[1].split('&');
    var allParas = new Array(paras.length);
    for(var i = 0; i<paras.length; i++){
           allParas[GetPara(paras[i])[0]] = GetPara(paras[i])[1];
    }
    return allParas;
}

//获取Para
function GetPara(word){
    if(!word){
        return null;
    }
    var onePara = word.split('=');
    return onePara;
}

function initStep(){
    var url = document.location.href;
    var paras = new Array();
    paras = GetUrl(url);
	if(paras == null)
		step1();
	else if(paras["step"]){
		switch(paras["step"]){
			case "step1":
				step1(); break;
			case "step2":
				step2(); break;
			case "step3":
				step3(); break;
			case "hasInstall":
				hasInstall(); break;
			case "cancel":
				cancel(); break;
			default:
				step1(); break;
		}
	}
	else
		step1();
		
}

function cancel(){
	$("step1").style.display = "none";
	$("step2").style.display = "none";
	$("step3").style.display = "none";
	$("cancel").style.display = "block";
	$("hasInstall").style.display = "none";
	window.location.href='#step=cancel';return false; 
}

function step1(){
	$("step1").style.display = "block";
	$("step2").style.display = "none";
	$("step3").style.display = "none";
	$("cancel").style.display = "none";
	$("hasInstall").style.display = "none";
	window.location.href='#step=step1';return false; 
}

function step2(){
	$("step1").style.display = "none";
	$("step2").style.display = "block";
	$("step3").style.display = "none";
	$("cancel").style.display = "none";
	$("hasInstall").style.display = "none";
	window.location.href='#step=step2';return false; 
}

function step3(){
	$("step1").style.display = "none";
	$("step2").style.display = "none";
	$("step3").style.display = "block";
	$("cancel").style.display = "none";
	$("hasInstall").style.display = "none";
	window.location.href='#step=step3';
	return false; 
}

function hasInstall(){
	$("step1").style.display = "none";
	$("step2").style.display = "none";
	$("step3").style.display = "none";
	$("cancel").style.display = "none";
	$("hasInstall").style.display = "block";
	window.location.href='#step=hasInstall';return false; 
}
