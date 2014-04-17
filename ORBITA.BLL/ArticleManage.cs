using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using ORBITA.DAL;
using ORBITA.Model;

namespace ORBITA.BLL
{
    [DataObjectAttribute()]
    public static class ArticleManage
    {
        #region public methods

        /// <summary>
        /// 查询分类文章 带分页 所有数据.
        /// </summary>
        /// <param name="ac_id"></param>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static ArticleCollection GetList(int ac_id, int startRowIndex, int maximumRows)
        {
            return ArticleService.GetList(ac_id, startRowIndex, maximumRows, null);
        }

        /// <summary>查询分类文章 带分页 所有数据.</summary>
        /// <param name="ac_id">文章分类ID</param>
        /// <param name="startRowIndex">起始记录</param>
        /// <param name="maximumRows">最多记录数</param>
        /// <param name="orderBy">排序标志</param>
        /// <returns>文章 list</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static ArticleCollection GetList(int ac_id, int startRowIndex, int maximumRows, string orderBy)
        {
            return ArticleService.GetList(ac_id, startRowIndex, maximumRows, orderBy);
        }

        /// <summary>查询分类文章 无分页 所有数据.</summary>
        /// <param name="ac_id">文章分类ID</param>
        /// <returns>文章 list</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static ArticleCollection GetList(int ac_id)
        {
            return ArticleService.GetList(ac_id, 0, 0, null);
        }

        /// <summary>查询分类文章 无分页 所有数据.</summary>
        /// <returns>文章 list</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static ArticleCollection GetList(bool istop, bool iscommend)
        {
            return ArticleService.GetList(istop, iscommend);
        }



        /// <summary>查询文章记录.</summary>
        /// <param name="art_id">文章ID</param>
        /// <returns>Article模型 包含一条文章记录.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Article GetItem(int art_id)
        {
            return ArticleService.GetItem(art_id);


        }

        /// <summary>删除一条文章记录</summary>
        /// <param name="art_id">文章ID</param>
        /// <returns>返回 <c>true</c> 删除成功, 或 <c>false</c> 删除失败.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(int art_id)
        {
            return ArticleService.Delete(art_id);
        }

        /// <summary>增加文章点击数</summary>
        /// <param name="art_id">文章ID</param>
        /// <returns>返回 <c>true</c> 修改成功, 或 <c>false</c> 修改失败.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public static bool Update(int art_id)
        {
            return ArticleService.Update(art_id);

        }


        /// <summary>修改文章记录</summary>
        /// <param name="myArticle">Article模型</param>
        /// <returns>返回 <c>true</c> 修改成功, 或 <c>false</c> 修改失败.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static bool Update(Article myArticle)
        {
            if (myArticle.art_id > 0
                && !string.IsNullOrEmpty(myArticle.art_title)
                && !string.IsNullOrEmpty(myArticle.art_content)
                && myArticle.ac_id > 0)
            {
                myArticle.art_date = DateTime.Now;
                return ArticleService.Update(myArticle);
            }
            else
            {
                return false;
            }
        }


        /// <summary>插入文章记录</summary>
        /// <param name="myArticle">Article 模型</param>
        /// <returns>返回 <c>true</c> 插入成功, 或 <c>false</c> 插入失败.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static bool Insert(Article myArticle)
        {
            if (!string.IsNullOrEmpty(myArticle.art_title)
                && !string.IsNullOrEmpty(myArticle.art_content)
                && myArticle.ac_id > 0)
            {
                myArticle.art_date = DateTime.Now;
                return ArticleService.Insert(myArticle);
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
