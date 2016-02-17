using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using CNSP.Core;
using CNSP.Platform;
using CNSP.KeyWord;
using CNSP.DataBase;

namespace CNSP.Platform.IO
{
    /*
    struct result_t{
    int start; //start position,词语在输入句子中的开始位置
    int length; //length,词语的长度
    char  sPOS[POS_SIZE];//word type，词性ID值，可以快速的获取词性表
    int	iPOS;//词性标注的编号
    int word_ID; //该词的内部ID号，如果是未登录词，设成0或者-1
    int word_type; //区分用户词典;1，是用户词典中的词；0，非用户词典中的词
    int weight;//word weight,read weight
    };*/
    [StructLayout(LayoutKind.Explicit)]
    public struct result_t
    {
        [FieldOffset(0)] public int start;
        [FieldOffset(4)] public int length;
        [FieldOffset(8)] public int sPos1;
        [FieldOffset(12)] public int sPos2;
        [FieldOffset(16)] public int sPos3;
        [FieldOffset(20)] public int sPos4;
        [FieldOffset(24)] public int sPos5;
        [FieldOffset(28)] public int sPos6;
        [FieldOffset(32)] public int sPos7;
        [FieldOffset(36)] public int sPos8;
        [FieldOffset(40)] public int sPos9;
        [FieldOffset(44)] public int sPos10;
        [FieldOffset(48)] public int POS_id;
        [FieldOffset(52)] public int word_ID;
        [FieldOffset(56)] public int word_type;
        [FieldOffset(60)] public int weight;
    }

    public class KWTStrategy : IfIOStrategy//关键词网络读写算法类，用于读取和保存kwt文件
    {
        const string path = @"NLPIR.dll";//设定dll的路径
        //对函数进行申明
        [DllImport(path, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi, EntryPoint = "NLPIR_Init")]
        public static extern bool NLPIR_Init(String sInitDirPath, int encoding, String sLicenseCode);

        //特别注意，C语言的函数NLPIR_API const char * NLPIR_ParagraphProcess(const char *sParagraph,int bPOStagged=1);必须对应下面的申明
        [DllImport(path, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi, EntryPoint = "NLPIR_ParagraphProcess")]
        public static extern IntPtr NLPIR_ParagraphProcess(String sParagraph, int bPOStagged = 1);

        [DllImport(path, CharSet = CharSet.Ansi, EntryPoint = "NLPIR_Exit")]
        public static extern bool NLPIR_Exit();

        [DllImport(path, CharSet = CharSet.Ansi, EntryPoint = "NLPIR_ImportUserDict")]
        public static extern int NLPIR_ImportUserDict(String sFilename);

        [DllImport(path, CharSet = CharSet.Ansi, EntryPoint = "NLPIR_FileProcess")]
        public static extern bool NLPIR_FileProcess(String sSrcFilename, String sDestFilename, int bPOStagged = 1);

        [DllImport(path, CharSet = CharSet.Ansi, EntryPoint = "NLPIR_FileProcessEx")]
        public static extern bool NLPIR_FileProcessEx(String sSrcFilename, String sDestFilename);

        [DllImport(path, CharSet = CharSet.Ansi, EntryPoint = "NLPIR_GetParagraphProcessAWordCount")]
        static extern int NLPIR_GetParagraphProcessAWordCount(String sParagraph);
        //NLPIR_GetParagraphProcessAWordCount
        [DllImport(path, CharSet = CharSet.Ansi, EntryPoint = "NLPIR_ParagraphProcessAW")]
        static extern void NLPIR_ParagraphProcessAW(int nCount, [Out, MarshalAs(UnmanagedType.LPArray)] result_t[] result);

        [DllImport(path, CharSet = CharSet.Ansi, EntryPoint = "NLPIR_AddUserWord")]
        static extern int NLPIR_AddUserWord(String sWord);

        [DllImport(path, CharSet = CharSet.Ansi, EntryPoint = "NLPIR_SaveTheUsrDic")]
        static extern int NLPIR_SaveTheUsrDic();

        [DllImport(path, CharSet = CharSet.Ansi, EntryPoint = "NLPIR_DelUsrWord")]
        static extern int NLPIR_DelUsrWord(String sWord);

        [DllImport(path, CharSet = CharSet.Ansi, EntryPoint = "NLPIR_NWI_Start")]
        static extern bool NLPIR_NWI_Start();

        [DllImport(path, CharSet = CharSet.Ansi, EntryPoint = "NLPIR_NWI_Complete")]
        static extern bool NLPIR_NWI_Complete();

        [DllImport(path, CharSet = CharSet.Ansi, EntryPoint = "NLPIR_NWI_AddFile")]
        static extern bool NLPIR_NWI_AddFile(String sText);

        [DllImport(path, CharSet = CharSet.Ansi, EntryPoint = "NLPIR_NWI_AddMem")]
        static extern bool NLPIR_NWI_AddMem(String sText);

        [DllImport(path, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi, EntryPoint = "NLPIR_NWI_GetResult")]
        public static extern IntPtr NLPIR_NWI_GetResult(bool bWeightOut = false);

        [DllImport(path, CharSet = CharSet.Ansi, EntryPoint = "NLPIR_NWI_Result2UserDict")]
        static extern uint NLPIR_NWI_Result2UserDict();

        [DllImport(path, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi, EntryPoint = "NLPIR_GetKeyWords")]
        public static extern IntPtr NLPIR_GetKeyWords(String sText, int nMaxKeyLimit = 50, bool bWeightOut = false);

        [DllImport(path, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi, EntryPoint = "NLPIR_GetFileKeyWords")]
        public static extern IntPtr NLPIR_GetFileKeyWords(String sFilename, int nMaxKeyLimit = 50, bool bWeightOut = false);


        const string strEncoding = "gb2312";
        const string strDataPath = "3rdLib/ICTCLA/";
        const string strWordPairPattern = @" [^ \]]+/[^ w]+";  //匹配目标"词语/词性"组合
        const string strWordPattern = @" [\u4e00-\u9fa5a-zA-Z0-9]+"; //匹配目标 中英文数字词语
        const string strSentencePattern = @"[\n|\t|.|,|!|;|。|，|！|；|……]";//匹配目标 所有中英文的换行符号
        const int intFollowUp = 2;              //参与连边的邻居数量
        List<String> InvalidWord;
        List<String> InvalidType;
        /*
         * Function: ReadFile
         * Description:KWTStrategy算法读取函数
         * Parameters:
         *      string sPath 文件路径
         *      StyleSet pStyle 绘制样式集
         * Return Value:cNet
         */
        cNet IfIOStrategy.ReadFile(string sPath)
        {
            cNet NewNet = null;
            List<WordResult> WordList;
            List<String> SentenceList;
            List<kNode> NodeList;
            StreamReader Reader;
            string strText;
            //0 数据库读入
            DatabaseInit();
            //1 读取sPath指向的文件，存入strText
            Reader = new StreamReader(sPath, Encoding.GetEncoding(strEncoding));
            if (Reader == null)
            {
                return null;
            }
            strText = Reader.ReadToEnd();
            Reader.Close();
            Reader.Dispose();
            //2.将文本划分为词性和词语的组合，存入WordList
            WordList = WordSplit(strText);
            if (WordList == null)
            {
                return null;
            }
            //3.根据标点符号将原文划分为句子
            SentenceList = SentenceSplit(strText);
            if (SentenceList == null)
            {
                return null;
            }
            //4.无效词语过滤
            NodeFilter(ref WordList);
            //5.定位每个词语在句中的位置，构建节点列表
            WordLocate(ref WordList, SentenceList);
            NodeList = BuildKeyWordNode(ref WordList);
            if (NodeList == null)
            {
                return null;
            }
            //6.构建网络并连边
            NewNet = BuildKeyWordNet(NodeList, WordList);
            if (NewNet == null)
            {
                return null;
            }
            return NewNet;
        }

        //数据库读入
        void DatabaseInit()
        {
            InvalidWordProxy WordReader = new InvalidWordProxy();
            InvalidTypeProxy TypeReader = new InvalidTypeProxy();
            InvalidWord = WordReader.ReadAll();
            InvalidType = TypeReader.ReadAll();
        }


        /*
         * Function: WordSplit
         * Description:分词函数
         * Parameters:
         *      string strText 文件文本
         * Return Value:List<WordResult>
         */
        List<WordResult> WordSplit(string strText)
        {
            List<WordResult> WordList = null;
            MatchCollection matches;
            Match mStr;
            Regex regObj;
            string strResult,strTmp, strWord, strType;
            int intPos;

            if (!NLPIR_Init(strDataPath, 0, ""))//给出Data文件所在的路径，注意根据实际情况修改。
            {
                return null;
            }

            int count = NLPIR_GetParagraphProcessAWordCount(strText);//先得到结果的词数
            result_t[] result = new result_t[count];//在客户端申请资源
            NLPIR_ParagraphProcessAW(count, result);//获取结果存到客户的内存中   
            IntPtr intPtr = NLPIR_ParagraphProcess(strText);//切分结果保存为IntPtr类型
            strResult = Marshal.PtrToStringAnsi(intPtr);//将切分结果转换为string

            regObj = new Regex(strWordPairPattern);//正则表达式初始化，载入匹配模式
            matches = regObj.Matches(strResult);//正则表达式对分词结果进行匹配
            if (matches.Count == 0)
            {
                return null;
            }
            WordList = new List<WordResult>();
            regObj = new Regex(strWordPattern);//初始化新的正则表达式，用于提取词语
            foreach (Match match in matches)//遍历”词语/词性“组合列表
            {
                strTmp = match.ToString();
                intPos = strTmp.IndexOf('/');
                strWord = strTmp.Substring(0, intPos);
                mStr = regObj.Match(strWord);   //中英文词语
                strType = strTmp.Substring(intPos + 1); //词性（英文缩写）
                WordList.Add(new WordResult(mStr.ToString().Trim(), strType.Trim())); //生成新的对象实例并加入列表
            }

            return WordList;
        }
        /*
         * Function: SentenceSplit
         * Description:分句函数
         * Parameters:
         *      string strText 文件文本
         * Return Value:List<String>
         */
        List<String> SentenceSplit(string strText)
        {
            List<String> SentenceList = null;
            string[] strSeg;
            Regex regObj;
            string strStore;

            regObj = new Regex(strSentencePattern);//正则表达式初始化，用于语句分割
            strSeg = regObj.Split(strText);
            if (strSeg.Length == 0)
            {
                return null;
            }
            SentenceList = new List<string>();
            foreach (string strTmp in strSeg)//遍历分割出的语句列表
            {
                strStore = strTmp.Trim();
                if (strStore != "")
                {
                    SentenceList.Add(strStore);//去除前后空格后不为空的才作为有效语句存入
                }
            }

            return SentenceList;
        }
        /*
         * Function: WordLocate
         * Description:词语定位函数
         * Parameters:
         *      ref List<WordResult> WordList   词语列表
         *      List<String> SentenceList           句子列表
         * Return Value:
         */
        void WordLocate(ref List<WordResult> WordList, List<String> SentenceList)
        {//核心算法A，词语定位。在每句中找到当前词语所述的句子索引和句中位置索引。
            WordResult word;
            int intWord, intLine, intPosition, intPointer, intFind;
            string strWord;
            
            intLine = 0;
            intPosition = 0;
            intPointer = 0;
            for (intWord = 0; intWord < WordList.Count;)//遍历词语列表
            {
                word = WordList[intWord];
                strWord = word.Word;        //获取当前词语的内容

                intFind = SentenceList[intLine].IndexOf(strWord, intPointer);//在当前句子中查找词语，起始位置是前一个词语之后。
                if (intFind >= 0)//如果找到则将句子索引和位置标号写入word对象，下次查找的起始位置后移
                {
                    word.Line = intLine;
                    word.Position = intPosition;
                    intPointer = intFind + strWord.Length;
                    intWord++;
                    if (word.IsIgnore == true)
                    {
                        continue;
                    }
                    intPosition++;
                }
                else //当前句子中没找到。
                {
                    if (SentenceList[intLine + 1].IndexOf(strWord) == 0)//出现在下一句的句首，则向下移动一句，部分变量清零。
                    {
                        intLine++;      
                        intPosition = 0;
                        intPointer = 0;//注意，这里intWord不++，因为下个循环还要用。
                        if (intLine == SentenceList.Count)
                        {
                            break;
                        }
                    }
                    else  //不在下一句的句首，直接记录当前句子索引和位置到word，放弃该词。
                    {
                        word.Line = intLine;
                        word.Position = intPosition;
                        intWord++;
                        if (word.IsIgnore == true)
                        {
                            continue;
                        }
                        intPosition++;
                    }
                }
            }
        }
        /*
         * Function: BuildKeyWordNode
         * Description:构建关键词节点
         * Parameters:
         *      ref List<WordResult> WordList
         * Return Value:List<kNode>
         */
        List<kNode> BuildKeyWordNode(ref List<WordResult> WordList)
        {
            List<kNode> NodeList = new List<kNode>();
            int intNumber;

            //1.合并节点
            NodeMerge(ref WordList);
            //2.创建节点列表
            intNumber = 0;
            foreach (WordResult word in WordList)
            {
                if (word.IsIgnore == false)//如果当前词语没被忽略，则为他构造一个借点对象并加入节点列表。
                {
                    NodeList.Add(new kNode(intNumber, word));
                    intNumber++;
                }
            }
            return NodeList;
        }
        /*
         * Function: NodeFilter
         * Description:过滤停用词和无效词性函数
         * Parameters:
         *      ref List<WordResult> WordList   词语节点
         * Return Value:
         */
        void NodeFilter(ref List<WordResult> NodeList)
        {
            //遍历分词结果列表
            foreach (WordResult sourWord in NodeList)
            {
                //已被忽略则跳过
                if(sourWord.IsIgnore == true)
                {
                    continue;
                }
                //过滤词性
                foreach (string strType in InvalidType)
                {
                    if (CheckType(sourWord, strType) == true)
                    {
                        sourWord.Ignore();
                        break;
                    }
                }
                //被过滤的跳到下一个词
                if (sourWord.IsIgnore == true)
                {
                    continue;
                }
                //过滤停用词
                foreach (string strTarget in InvalidWord)
                {
                    if (strTarget == sourWord.Word)
                    {
                        sourWord.Ignore();
                        break;
                    }
                }
            }
        }

        //检查词性和词语是否一致
        bool CheckType(WordResult sWord, string sType)
        {
            string first;

            first = sWord.Type.Substring(0, 1);
            if (first == sType)
            {
                return true;
            }
            return false;
        }
        /*
         * Function: NodeMerge
         * Description:合并相似词语节点
         * Parameters:
         *      ref List<WordResult> WordList   词语节点
         * Return Value:
         */
        void NodeMerge(ref List<WordResult> WordList)
        {//节点合并操作，CheckSimilarity返回true的则合并
            foreach (WordResult sourWord in WordList)
            {
                foreach (WordResult tarWord in WordList)
                {
                    if (CheckSimilarity(sourWord, tarWord) == true)
                    {
                        tarWord.Merged(sourWord.Line, sourWord.Position);//执行合并
                    }
                }
            }
        }
        /*
         * Function: CheckSimilarity
         * Description:计算两个词语的相似度
         * Parameters:
         *      WordResult wSource  
         *      WordResult wTarget
         * Return Value:bool
         */
        bool CheckSimilarity(WordResult wSource, WordResult wTarget)
        {//核心算法B，检查相似度，暂时将内容相等节点合并，以后扩展。
            if (wSource == wTarget)
            {//传入的两个词语是同一个，返回false
                return false;
            }
            if ((wSource.IsIgnore == true) || (wTarget.IsIgnore == true))
            {//传入的两个词语有一个被忽略，返回false
                return false;
            }
            if (wSource.Word == wTarget.Word)
            {//传入的两个词语内容完全相等，返回true
                return true;
            }
            return false;//其他内容不相等的有效节点都返回false
        }
        /*
         * Function: BuildKeyWordNet
         * Description:构建关键词网络
         * Parameters:
         *      List<kNode> NodeList        待构建节点
         *      List<WordResult> WordList   词语列表
         *      StyleSet PaintStyle     绘制样式集
         * Return Value:cNet
         */
        cNet BuildKeyWordNet(List<kNode> NodeList, List<WordResult> WordList)
        {//核心算法C， 构造网络，主要任务是找到符合条件的两个节点，在他们之间加边。
            cNet NewNet = null;
            int intSource, intTarget, intSourLine, intSourPos;

            //1 构造网络并加入节点
            NewNet = new cNet(NodeList.Count);
            foreach (IfPlatform curNode in NodeList)
            {
                NewNet.Network.Add(curNode);
            }
            //遍历词语列表
            foreach (WordResult word in WordList)
            {
                if(word.IsIgnore == true)
                {//被忽略节点则直接跳到下一个。
                    continue;
                }
                intSourLine = word.Line;//获取词语的句号，位置，作为词语的唯一全局索引（每个词语都不同）
                intSourPos = word.Position;
                //查找对应索引在cNet中的节点的编号，查到返回，查不到返回-1
                intSource = FindNode(intSourLine, intSourPos, WordList, NewNet);
                for (int i = 1; i <= intFollowUp; i++)
                {//对当前节点的后面intFollowUp个邻居节点进行遍历
                    //返回对应索引的邻居节点在cNet中的节点的编号
                    intTarget = FindNode(intSourLine, intSourPos + i, WordList, NewNet);
                    if (intTarget < 0)
                    {//没有邻居则跳出
                        break;
                    }
                    //执行加边
                    NewNet.AddEdge(intSource, intTarget, 1);
                }

            }
            if (NewNet.intNumber == 0)
            {
                return null;
            }
            return NewNet;
        }
        /*
         * Function: FindNode
         * Description:查找Net中拥有目标索引的词语的节点编号
         * Parameters:
         *      int iLine   句子编号
         *      int iPos    位置索引
         *      List<WordResult> WordList  词语列表
         *      cNet newNet 待搜索网络
         * Return Value:int
         */
        int FindNode(int iLine, int iPos, List<WordResult> WordList, cNet newNet)
        {//核心算法D， 查找cNet中对应索引（句子号，句中位置）对应的节点编号
            int intOwnerLine, intOwnerPos;

            foreach (WordResult word in WordList)
            {//首先在WordList中找到该节点，WordList中信息最完整
                if ((word.Line != iLine) || (word.Position != iPos))
                {//两个索引不匹配，换下一个词语
                    continue;
                }
                if (word.IsIgnore == false)
                {//当前词语未被筛选掉或被兼并，在Net中查找节点编号。
                    return FindNodeinNet(iLine, iPos, newNet);
                }
                if (word.IsMerged == true)
                {//当前节点被兼并，返回其从属节点的句号，位置
                    intOwnerLine = word.Owner.Key;
                    intOwnerPos = word.Owner.Value;
                    //返回当前节点的宗主节点的编号
                    return FindNodeinNet(intOwnerLine, intOwnerPos, newNet);
                }
            }
            return -1;
        }
        /*
         * Function: FindNodeinNet
         * Description:查找Net中拥有目标索引的词语的节点编号
         * Parameters:
         *      int iLine   句子编号
         *      int iPos    位置索引
         *      cNet newNet 待搜索网络
         * Return Value:int
         */
        int FindNodeinNet(int iLine, int iPos, cNet newNet)
        {//遍历网络中的节点，找到对应索引（句号，句中位置）则返回节点编号
            foreach (IfKeyWord curNode in newNet.Network)
            {
                if ((curNode.Line == iLine) && (curNode.Position == iPos))
                {
                    return curNode.Number;
                }
            }
            return -1;
        }
        /*
         * Function: SaveFile
         * Description:文件保存函数（暂不支持）
         * Parameters:
         *      string strText 文件文本
         * Return Value:
         */
        void IfIOStrategy.SaveFile(XmlDocument doc, string sPath)
        {

        }
    }
}
