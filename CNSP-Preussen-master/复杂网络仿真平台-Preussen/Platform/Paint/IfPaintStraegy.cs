using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using CNSP.Platform;

namespace CNSP.Platform.Paint
{
    public interface IfPaintStrategy//绘制算法接口
    {
        StyleSet PaintStyle{get;}
        SortedList<int, Image> Images { get; }
        //更新网络样式集，并刷新节点图片列表
        void UpdateStyle(StyleSet GlobalStyle);
        //更新网络结构，节点坐标
        void UpdateLocation(XmlDocument doc);
        //刷新网络图片列表
        void UpdateImage();
        //绘制网络结构图，输入目标图元，和高亮节点编号（默认为没有）
        void Draw(ref Graphics GraCam, int intExclude);
        //绘制高亮节点和其相关连边
        void DrawHighLightNodeEdge(int iNum, Point newLoc, ref Graphics GraCam);
    }
}
