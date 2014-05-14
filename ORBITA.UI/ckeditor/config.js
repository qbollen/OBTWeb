/*
Copyright (c) 2003-2011, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
//-------------------- 外观样式 --------------------//
    config.language = "zh-cn";  //设备说话
    config.uiColor = "＃FFF";    //靠山色彩
    config.width = "auto";      //宽度   
    config.height = "250px";    //高度   
    config.skin = "office2003"; //界面：v2、kama、office2003
    config.toolbar = "Full";    //对象栏风格：Full、Basic
    config.font_names = "宋体;楷体_GB2312;新宋体;黑体;隶书;幼圆;微软雅黑;Arial;Comic Sans MS;Courier New;Tahoma;Times New Roman;Verdana"; //字体

//-------------------- 上传路径 --------------------//
    config.filebrowserBrowseUrl = "/ckfinder/ckfinder.html";                  //上传文件的查看路径
    config.filebrowserImageBrowseUrl = "/ckfinder/ckfinder.html?Type=Images"; //上传图片的查看路径
    config.filebrowserFlashBrowseUrl = "/ckfinder/ckfinder.html?Type=Flash";  //上传Flash的查看路径
    config.filebrowserUploadUrl = "/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";        //上传文件的保存路径
    config.filebrowserImageUploadUrl = "/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images"; //上传图片的保存路径
    config.filebrowserFlashUploadUrl = "/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";  //上传Flash的保存路径
};
