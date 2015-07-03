///////////////////////////////////////////////////////////////////////////
function CheckedAll(eventObj)
{		
	with(document.all)
	{
		var objs = document.getElementsByTagName("INPUT");
		for (var i = 0, j = objs.length; i < j; i++) {
		    if (objs[i].type.toLowerCase() == "checkbox" && objs[i].id.replace("chkSelect", "") != objs[i].id )
		    { objs[i].checked = eventObj.checked; }
        }
	} 
}

function ClearNoNumM(obj) { obj.value = obj.value.replace(/[^\d]/g, ""); }             //整数onkeyup="ClearNoNumM(this)" 
function ClearNoNum(obj) { obj.value = obj.value.replace(/[^(\-?\d*\.?\d*)]/g, ""); }  //onkeyup="ClearNoNumM(this)" 

function EnabledMe(obj,strBtnID) { obj.disabled="true"; document.getElementById(strBtnID).click(); }   //obj.disabled="disabled";
function hideMe(obj) { obj.style="display:none";}

function changeMeName(obj) {if (obj.value == "") { obj.value = "我的姓名"; } else {if (obj.value == "我的姓名") { obj.value = "";}} }
function changeMeTel(obj) { if (obj.value == "") { obj.value = "我的电话"; } else { if (obj.value == "我的电话") { obj.value = ""; } } }
///////////////////////////////////////////////////////////////////////////
function onTextBlue(vOk) {
    if (vOk != "" ) {
        document.getElementById(vOk).click(); 
    }
}
function onTextKeyDown(vUp, vDown, vLeft, vRight, vOk) { 
    if (event.keyCode == 13 && vOk != "") { 
        document.getElementById(vOk).click();  
    }
    if (event.keyCode == 38 && vUp != "") { 
        document.getElementById(vUp).focus();
    }
    if (event.keyCode == 40 && vDown != "") { 
        document.getElementById(vDown).focus(); 
    }
    if (event.keyCode == 37 && vLeft != "") { 
        document.getElementById(vLeft).focus();
    }
    if (event.keyCode == 39 && vRight != "") { 
        document.getElementById(vRight).focus();
    }
}
/////////////////////////////////////////////////////////////////////////// 
//获取下拉列表选中项的文本
function getSelectedText(name){
    var obj=document.getElementById(name);
    for(i=0;i<obj.length;i++){
       if(obj[i].selected==true){
        return obj[i].innerText;      //关键是通过option对象的innerText属性获取到选项文本
       }
    }
}
//获取下拉列表选中项的值
function getSelectedValue(name){
    var obj=document.getElementById(name);
    return obj.value;      //如此简单，直接用其对象的value属性便可获取到
}

//求单选按纽的值，传radio名字作为参数。未选返回false；有选择项，返回选项值。
function getRadioValue(name){
    var radioes = document.getElementsByName(name); 
    for(var i=0;i<radioes.length;i++)
    {
         if(radioes[i].checked){
          return radioes[i].value;
         }
    }
    return false;
}

//通过值修改所选中的单选按钮
function setRadio(name,sRadioValue){        //传入radio的name和选中项的值
    var oRadio = document.getElementsByName(name); 
    for(var i=0;i<oRadio.length;i++) //循环
    {
            if(oRadio[i].value==sRadioValue) //比较值
            { 
             oRadio[i].checked=true; //修改选中状态
             break; //停止循环
            }
    }
 }
 ///////////////////////////////////////////////////////////////////////////