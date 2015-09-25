<%@ WebHandler Language="C#" Class="UpLoadImgHandler" %>

using System;
using System.Web;
using System.IO;
using System.Drawing;
public class UpLoadImgHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";

        //获取上传的文件
        HttpPostedFile imgFile = context.Request.Files["imgFile"];

        //服务器端进行校验
        string fileName = imgFile.FileName;
        string fileExt = Path.GetExtension(fileName);
        if (!(fileExt == ".jpeg" || fileExt == ".jpg" || fileExt == ".bmp" || fileExt == ".png"))
        {

            context.Response.Write("文件错误");
            //停止该页面的执行,停止下面的代码的执行
            context.Response.End();
            return;
        }
        else
        {
            #region 我的生成缩略图
            ////=================制作缩略图,给原图加水印====================

            ////绘制水印
            ////获得原图
            //Image orginalImg = Image.FromStream(imgFile.InputStream);
            //Graphics bigImgG = Graphics.FromImage(orginalImg);
            ////设置绘制文字
            //string drawString = "我是水印";
            //bigImgG.DrawString(drawString, new Font("黑体", 100, GraphicsUnit.Pixel), Brushes.Blue, orginalImg.Width - drawString.Length * 100, orginalImg.Height - 100);

            ////保存文件到指定文件夹,用Guid构建唯一的文件名
            //string filePath = "UpLoadFiles/" + Guid.NewGuid().ToString() + fileName;
            //orginalImg.Save(context.Request.MapPath(filePath));

            ////绘制缩略图
            ////构建缩略图大小
            //Bitmap smalImage = new Bitmap(100, 100);

            ////把缩略图对象当做画布
            //Graphics g = Graphics.FromImage(smalImage);

            ////绘图,把原图绘制到画布上,并设置绘制大小
            ////函数参数:要用来绘制到画布上的图片,在画布上绘制的矩形的形状,从原图上截取的矩形的形状,绘制长度单位
            //g.DrawImage(orginalImg, new Rectangle(0, 0, 100, 100), new Rectangle(0, 0, orginalImg.Width, orginalImg.Height), GraphicsUnit.Pixel);

            ////保存缩略图
            //string smallImgPath = "UpLoadFiles/" + "small_" + Guid.NewGuid().ToString() + fileName;
            //smalImage.Save(context.Request.MapPath(smallImgPath));
            ////=============================================


            ////把保存的图片展示出来
            ////要用相对路径,否则显示不出来
            //context.Response.Write(string.Format(@"<html><meta http-equiv=Content-Type content='text/html;charset=utf-8'></meta><head><body><img src='{0}'/><img src='{1}'></body></head></html>", filePath, smallImgPath));

            ////其实吧context.Response.ContentType改为Image可以直接传输流,即把图片制作出来,用内存流把图片对象变成流,在传输回去

            //////用Guid构建唯一的文件名
            ////string imgFileSavePath = "UpLoadFiles/" + Guid.NewGuid().ToString() + imgFile.FileName;
            ////imgFile.SaveAs(context.Request.MapPath(imgFileSavePath));
            ////context.Response.Write("Ok");
            
            
            
            #endregion


            #region MyRegion通用方法生成缩略图
            
            //源图的相对路径
            string orginImgPath = "UpLoadFiles/" + Guid.NewGuid().ToString() + fileName;
            //原图的绝对路径
            string fullOrginImgPath = context.Request.MapPath(orginImgPath);
            //要保存源文件
            imgFile.SaveAs(fullOrginImgPath);
            
            //缩略图的相对路径
            string smallImgPath = "UpLoadFiles/small_" + Guid.NewGuid().ToString() + fileName;
            //缩略图的绝对路径
            string fullSmallImgPath = context.Request.MapPath(smallImgPath);

            MakeThumbnail(fullOrginImgPath, fullSmallImgPath,400, 400, "H");

            context.Response.Write(string.Format("<html><img src='{0}'</html>", smallImgPath));
            
            
            #endregion

        }

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    ///<summary> 
    /// 生成缩略图 
    /// </summary> 
    /// <param name="originalImagePath">源图路径（物理路径）</param> 
    /// <param name="thumbnailPath">缩略图路径（物理路径）</param> 
    /// <param name="width">缩略图宽度</param> 
    /// <param name="height">缩略图高度</param> 
    /// <param name="mode">生成缩略图的方式,HW:指定高宽缩放(可能变形),W:指定宽，高按比例,即宽度为指定高度自动适配,H:指定高，宽按比例,Cut:指定高宽裁减（不变形）</param>     
    public void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
    {
        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

        int towidth = width;
        int toheight = height;

        int x = 0;
        int y = 
        int ow = originalImage.Width;
        int oh = originalImage.Height;
        switch (mode)
        {
            case "HW"://指定高宽缩放（可能变形）                 
                break;
            case "W"://指定宽，高按比例                     
                toheight = originalImage.Height * width / originalImage.Width;
                break;
            case "H"://指定高，宽按比例 
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case "Cut"://指定高宽裁减（不变形）                 
                if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                {
                    oh = originalImage.Height;
                    ow = originalImage.Height * towidth / toheight;
                    y = 0;
                    x = (originalImage.Width - ow) / 2;
                }
                else
                {
                    ow = originalImage.Width;
                    oh = originalImage.Width * height / towidth;
                    x = 0;
                    y = (originalImage.Height - oh) / 2;
                }
                break;
            default:
                break;
        }

        //新建一个bmp图片 
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);
        //新建一个画板 
        Graphics g = System.Drawing.Graphics.FromImage(bitmap);
        //设置高质量插值法 
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        //设置高质量,低速度呈现平滑程度 
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //清空画布并以透明背景色填充 
        g.Clear(Color.Transparent);
        //在指定位置并且按指定大小绘制原图片的指定部分 
        g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
         new Rectangle(x, y, ow, oh),
         GraphicsUnit.Pixel);
        try
        {
            //以jpg格式保存缩略图 
            bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
    }
}